using FluentValidation;
using OnlineDeliveryProject.Application.Requests.Orders;
using OnlineDeliveryProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Validators.Orders
{
    public class AddOrderValidator : AbstractValidator<AddOrderRequest>
    {
        public AddOrderValidator()
        {
            RuleFor(x => x.CustomerId).NotNull().WithMessage("Customer should exist for each order");
            RuleFor(x => x.RestaurantId).NotNull().WithMessage("Restaurant should exist for each order");
        }
    }
}
