using AutoMapper;
using FluentValidation;
using OnlineDeliveryProject.Application.Commands.Customers;
using OnlineDeliveryProject.Application.Requests.Customers;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using OnlineDeliveryProject.Implementation.Validators.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Commands.Customers
{
    public class EfAddCustomerCommand : IAddCustomerCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly AddCustomerValidator _validator;
        private readonly IMapper _mapper;

        public EfAddCustomerCommand(OnlineDeliveryContext context, AddCustomerValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }
        public int Id => 5;

        public string Name => "EfUpdateCustomerCommand";

        public void Execute(AddCustomerRequest request)
        {
            _validator.ValidateAndThrow(request);

            var user = _mapper.Map<Customer>(request);

            _context.Add(user);
            _context.SaveChanges();

            int id = user.Id;

            foreach (var c in request.UserUseCases)
            {
                _context.CustomerUseCases.Add(new CustomerUseCase
                {
                    UserId = id,
                    UseCaseId = c
                });
            }

            _context.SaveChanges();

        }
    }
}
