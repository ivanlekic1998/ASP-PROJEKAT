using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Categories
{
    public class DeleteCategoryValidator : AbstractValidator<int>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}
