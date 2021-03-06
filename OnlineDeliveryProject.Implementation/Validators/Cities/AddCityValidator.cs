using OnlineDeliveryProject.Application.Requests.Cities;
using FluentValidation;
using OnlineDeliveryProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Cities
{
    public class AddCityValidator : AbstractValidator<AddCityRequest>
    {

        public AddCityValidator(OnlineDeliveryContext _context)
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).Must(x => !_context.Categories.Any(c => c.Name == x)).WithMessage("City name must be unique!");

        }
    }
}
