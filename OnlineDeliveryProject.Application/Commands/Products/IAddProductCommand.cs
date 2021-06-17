using OnlineDeliveryProject.Application.Requests.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Commands.Products
{
    public interface IAddProductCommand : ICommand<AddProductRequest>
    {
    }
}
