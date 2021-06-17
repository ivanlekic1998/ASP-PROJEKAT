using OnlineDeliveryProject.Application.Exceptions;
using FluentValidation;
using OnlineDeliveryProject.Application.Commands.Customers;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using OnlineDeliveryProject.Implementation.Validators.Customers;
using System;

namespace OnlineDeliveryProject.Implementation.Commands.Customers
{
    public class EfDeleteCustomerCommand : IDeleteCustomerCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly DeleteCustomerValidator _validator;

        public EfDeleteCustomerCommand(OnlineDeliveryContext context, DeleteCustomerValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 6;

        public string Name => "EfDeleteCustomerCommand";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);
            var user = _context.Customers.Find(request);

            if (user == null)
            {
                throw new EntityNotFoundException(request, typeof(Customer));
            }

            user.IsDeleted = true;
            user.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
