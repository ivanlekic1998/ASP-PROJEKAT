using OnlineDeliveryProject.Application.DataTransfer.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Queries.Orders
{
    public interface IGetOneOrderQuery : IQuery<int, OrderDto>
    {
    }
}
