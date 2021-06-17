using OnlineDeliveryProject.Application.Requests.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Commands.Orders
{
    public interface IUpdateOrderCommand : ICommand<UpdateOrderRequest>
    {
    }
}
