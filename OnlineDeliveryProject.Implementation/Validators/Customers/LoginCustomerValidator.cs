using FluentValidation;
using OnlineDeliveryProject.Application.Requests.Customers;
using OnlineDeliveryProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Customers
{
    public class LoginCustomerValidator : AbstractValidator<LoginRequest>
    {
        public LoginCustomerValidator(OnlineDeliveryContext _context)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is not entered")
                .Must(x => _context.Customers.Any(customer => customer.Email == x)).WithMessage("Customer doesn't exist!");
        }
    }
}
