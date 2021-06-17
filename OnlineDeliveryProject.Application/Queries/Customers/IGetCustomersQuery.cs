using OnlineDeliveryProject.Application.Queries;
using OnlineDeliveryProject.Application.DataTransfer.Customers;
using OnlineDeliveryProject.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Queries.Customers
{
    public interface IGetCustomersQuery : IQuery<CustomerSearch, PagedResponse<CustomerDto>>
    {
    }
}
