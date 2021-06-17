using FluentValidation;
using OnlineDeliveryProject.Application.Requests.Customers;
using OnlineDeliveryProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Customers
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerValidator(OnlineDeliveryContext _context)
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
