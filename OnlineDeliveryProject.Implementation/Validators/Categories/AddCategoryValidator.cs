using OnlineDeliveryProject.Application.Requests.Categories;
using FluentValidation;
using OnlineDeliveryProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Categories
{
    public class AddCategoryValidator : AbstractValidator<AddCategoryRequest>
    {
        public AddCategoryValidator(OnlineDeliveryContext _context)
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).Must(x => !_context.Categories.Any(c => c.Name == x)).WithMessage("Category name must be unique!");
        }
    }
}
