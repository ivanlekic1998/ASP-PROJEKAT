using OnlineDeliveryProject.Application.Queries;
using OnlineDeliveryProject.Application.DataTransfer.Orders;
using OnlineDeliveryProject.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Queries.Orders
{
    public interface IGetOrdersQuery : IQuery<OrderSearch, PagedResponse<OrderDto>>
    {
    }
}
