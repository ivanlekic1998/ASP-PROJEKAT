using OnlineDeliveryProject.Application.DataTransfer.Cities;
using OnlineDeliveryProject.Application.DataTransfer.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.DataTransfer.Resturants
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public CityDto City { get; set; }
        public ICollection<ProductDto> Products { get; set; }
    }
}
