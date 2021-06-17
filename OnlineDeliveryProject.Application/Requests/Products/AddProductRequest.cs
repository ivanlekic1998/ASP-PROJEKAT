using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Requests.Products
{
    public class AddProductRequest
    {
        public string Name { get; set; }
        public int RestaurantId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public decimal Size { get; set; }
        public int CategoryId { get; set; }
    }
}
