using FluentValidation;
using OnlineDeliveryProject.Application.Requests.Customers;
using OnlineDeliveryProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Customers
{
    public class AddCustomerValidator : AbstractValidator<AddCustomerRequest>
    {
        public AddCustomerValidator(OnlineDeliveryContext _context)
        {
            RuleFor(x => x.FullName).NotEmpty().MinimumLength(5).Matches("[A-z]*").WithMessage("Full name should be minimium 5 characters");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().Must(email => !_context.Customers.Any(x => x.Email == email)).WithMessage("Email is taken.");
            RuleFor(x => x.CustomerUseCases).NotEmpty();
        }
    }
}
