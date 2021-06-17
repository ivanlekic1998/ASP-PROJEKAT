using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Products
{
    public class DeleteProductValidator : AbstractValidator<int>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}
