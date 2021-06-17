using AutoMapper;
using OnlineDeliveryProject.Application.Email;
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
    public class EfRegisterCustomerCommand : IRegisterCustomerCommand
    {
        public int Id => 9;

        public string Name => "EfRegisterCustomerCommand";
        private IEnumerable<int> useCasesForUser = new List<int> { 16, 17, 18, 20, 30, 31, 32, 33, 35, 42, 43, 45, 400 };
        private readonly OnlineDeliveryContext _context;
        private readonly RegisterCustomerValidator _validator;
        private readonly IEmailSender _sender;
        private readonly IMapper _mapper;

        public EfRegisterCustomerCommand(OnlineDeliveryContext context, RegisterCustomerValidator validator, IEmailSender sender, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _sender = sender;
            _mapper = mapper;
        }

        public void Execute(RegisterCustomerRequest request)
        {
            _validator.ValidateAndThrow(request);

            var user = _mapper.Map<Customer>(request);

            _context.Add(user);
            _context.SaveChanges();

            int id = user.Id;

            foreach (var c in useCasesForUser)
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