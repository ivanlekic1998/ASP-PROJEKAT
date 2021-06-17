using FluentValidation;
using OnlineDeliveryProject.Application.Requests.Restaurants;
using OnlineDeliveryProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Restaurants
{
    public class AddRestaurantValidator : AbstractValidator<AddRestaurantRequest>
    {
        public AddRestaurantValidator(OnlineDeliveryContext _context)
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).Matches("[A-z0-9]*").WithMessage("Restaurant name must contains numbers and letters");
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty().Must(email => !_context.Restaurants.Any(x => x.Email == email)).WithMessage("Email is taken."); ;
            RuleFor(x => x.Email).EmailAddress().Must(email => !_context.Restaurants.Any(x => x.Email == email)).WithMessage("Email is taken."); ;
        }
    }
}
