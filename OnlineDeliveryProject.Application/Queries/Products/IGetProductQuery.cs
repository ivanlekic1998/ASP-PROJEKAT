using OnlineDeliveryProject.Application.DataTransfer.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Queries.Products
{
    public interface IGetProductQuery : IQuery<int, ProductDto>
    {
    }
}
