using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Orders
{
    public class DeleteOrderValidator : AbstractValidator<int>
    {
        public DeleteOrderValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}
