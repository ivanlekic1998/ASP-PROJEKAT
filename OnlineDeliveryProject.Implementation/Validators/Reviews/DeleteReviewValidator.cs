using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Reviews
{
    public class DeleteReviewValidator : AbstractValidator<int>
    {
        public DeleteReviewValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}
