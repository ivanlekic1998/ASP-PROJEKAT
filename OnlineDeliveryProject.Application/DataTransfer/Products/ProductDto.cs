using OnlineDeliveryProject.Application.DataTransfer.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.DataTransfer.Products
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Size { get; set; }
        public CategoryDto Category { get; set; }
    }
}
