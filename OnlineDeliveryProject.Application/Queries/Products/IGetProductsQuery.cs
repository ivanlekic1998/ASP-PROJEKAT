using OnlineDeliveryProject.Application.Queries;
using OnlineDeliveryProject.Application.DataTransfer.Products;
using OnlineDeliveryProject.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Queries.Products
{
    public interface IGetProductsQuery : IQuery<ProductSearch, PagedResponse<ProductDto>>
    {
    }
}
