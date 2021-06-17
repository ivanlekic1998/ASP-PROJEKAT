using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Customers
{
    public class DeleteCustomerValidator : AbstractValidator<int>
    {
        public DeleteCustomerValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}
