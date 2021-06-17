using FluentValidation;
using OnlineDeliveryProject.Application.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators
{
    public  class ContactValidator : AbstractValidator<ContactRequest>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Content).NotEmpty();

            RuleFor(x => x.SendFrom).NotEmpty().EmailAddress();

            RuleFor(x => x.Subject).NotEmpty();
        }
    }
}
