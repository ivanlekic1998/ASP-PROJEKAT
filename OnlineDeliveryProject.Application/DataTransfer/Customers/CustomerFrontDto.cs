using OnlineDeliveryProject.Application.DataTransfer.Cities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.DataTransfer.Customers
{
    public class CustomerFrontDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public CityDto City { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<int> CustomerUseCase { get; set; } = new List<int>();
    }
}
