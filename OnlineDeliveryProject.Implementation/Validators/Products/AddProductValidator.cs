using FluentValidation;
using OnlineDeliveryProject.Application.Requests.Products;
using OnlineDeliveryProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Products
{
    public class AddProductValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductValidator(OnlineDeliveryContext _context)
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty().NotEmpty().Must(cat => _context.Categories.Any(x => x.Id == cat)).WithMessage("Not valid Category.");
            RuleFor(x => x.RestaurantId).NotEmpty().NotEmpty().Must(cat => _context.Restaurants.Any(x => x.Id == cat)).WithMessage("Not valid Restaurant.");
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Size).NotEmpty();
        }
    }
}
