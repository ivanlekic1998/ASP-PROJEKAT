using OnlineDeliveryProject.Application.DataTransfer.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Queries.Customers
{
    public interface IGetOneCustomerFrontQuery : IQuery<int, OneCustomerWithOrdersDto>
    {
    }
}
