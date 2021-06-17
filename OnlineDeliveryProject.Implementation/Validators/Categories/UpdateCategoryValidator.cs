using OnlineDeliveryProject.Application.Requests.Categories;
using FluentValidation;
using OnlineDeliveryProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Categories
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryValidator(OnlineDeliveryContext _context)
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).Must((request, n) => !_context.Categories.Any(x => x.Name == request.Name && x.Id != request.Id));
        }
    }
}
