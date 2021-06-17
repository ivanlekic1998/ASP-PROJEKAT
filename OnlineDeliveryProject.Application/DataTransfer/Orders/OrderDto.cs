using OnlineDeliveryProject.Application.DataTransfer.Customers;
using OnlineDeliveryProject.Application.DataTransfer.Products;
using OnlineDeliveryProject.Application.DataTransfer.Resturants;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.DataTransfer.Orders
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public CustomerFrontDto Customer { get; set; }
        public RestaurantDto Restaurant { get; set; }
        public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
