using OnlineDeliveryProject.Application.Requests.Customers;
using OnlineDeliveryProject.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Customers
{
    public class RegisterCustomerValidator : AbstractValidator<RegisterCustomerRequest>
    {
        public RegisterCustomerValidator(OnlineDeliveryContext _context)
        {
            RuleFor(x => x.FullName).NotEmpty().MinimumLength(2).WithMessage("Full name minimum 2 characters");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().Must(email => !_context.Customers.Any(x => x.Email == email)).WithMessage("Email is taken.");
        }
    }
}
