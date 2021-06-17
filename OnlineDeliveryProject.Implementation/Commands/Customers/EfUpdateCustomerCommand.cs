using AutoMapper;
using FluentValidation;
using OnlineDeliveryProject.Application.Commands.Customers;
using OnlineDeliveryProject.Application.Requests.Customers;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Implementation.Validators.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using OnlineDeliveryProject.Application.Exceptions;
using OnlineDeliveryProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace OnlineDeliveryProject.Implementation.Commands.Customers
{
    public class EfUpdateCustomerCommand : IUpdateCustomerCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly UpdateCustomerValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateCustomerCommand(OnlineDeliveryContext context, UpdateCustomerValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }
        public int Id => 5;

        public string Name => "EfUpdateCustomerCommand";

        public void Execute(UpdateCustomerRequest request)
        {

            _validator.ValidateAndThrow(request);

            var findUser = _context.Customers.Find(request.Id);
            if (findUser == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Customer));
            }


            var customers = _context.Customers.Include(x => x.CustomerUseCases).Where(x => x.Id == request.Id).First();

            foreach (var id in customers.CustomerUseCases)
            {
                _context.Remove(id);
            }

            foreach (var idUc in request.CustomerUseCases)
            {
                _context.CustomerUseCases.Add(new CustomerUseCase
                {
                    UseCaseId = idUc,
                    UserId = request.Id
                });
            }

            _mapper.Map(request, customers);
            _context.SaveChanges();

        }

        public void Execute(AddCustomerRequest reqeust)
        {
            throw new NotImplementedException();
        }
    }
}
