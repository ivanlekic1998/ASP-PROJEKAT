using FluentValidation;
using OnlineDeliveryProject.Application.Requests.Products;
using OnlineDeliveryProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Products
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductValidator(OnlineDeliveryContext _context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is not valid."); ;
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is not valid."); ;
            RuleFor(x => x.Size).NotEmpty().WithMessage("Size is not valid."); ;
            RuleFor(x => x.ProductId).NotEmpty().Must(category => _context.Categories.Any(p => p.Id == category)).WithMessage("ProductId is not valid.");
            RuleFor(x => x.RestaurantId).NotEmpty().Must(restaurant => _context.Restaurants.Any(p => p.Id == restaurant)).WithMessage("RestaurantId is not valid.");
        }
    }
}
