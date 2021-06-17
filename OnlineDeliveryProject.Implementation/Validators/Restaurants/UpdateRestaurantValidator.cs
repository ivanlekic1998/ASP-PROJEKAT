using FluentValidation;
using OnlineDeliveryProject.Application.Requests.Restaurants;
using OnlineDeliveryProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Restaurants
{
    public class UpdateRestaurantValidator : AbstractValidator<UpdateRestaurantRequest>
    {
        public UpdateRestaurantValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
