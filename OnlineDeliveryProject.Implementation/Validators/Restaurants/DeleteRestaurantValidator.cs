using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Restaurants
{
    public class DeleteRestaurantValidator : AbstractValidator<int>
    {
        public DeleteRestaurantValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}
