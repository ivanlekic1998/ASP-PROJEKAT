using FluentValidation;
using OnlineDeliveryProject.Application.Requests.Reviews;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Reviews
{
    public class AddReviewValidator : AbstractValidator<AddReviewRequest>
    {
        public AddReviewValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId couldn't be empty");
            RuleFor(x => x.RestaurantId).NotEmpty().WithMessage("RestaurantId couldn't be empty");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description couldn't be empty");
        }
    }
}
