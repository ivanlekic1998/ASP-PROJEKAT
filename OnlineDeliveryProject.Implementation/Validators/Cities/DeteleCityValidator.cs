using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Cities
{
    public class DeteleCityValidator : AbstractValidator<int>
    {
        public DeteleCityValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}
