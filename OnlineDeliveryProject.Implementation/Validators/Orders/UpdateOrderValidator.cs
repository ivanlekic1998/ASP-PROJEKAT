using FluentValidation;
using OnlineDeliveryProject.Application.Requests.Orders;
using OnlineDeliveryProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Orders
{
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderRequest>
    {
        public UpdateOrderValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
