using OnlineDeliveryProject.Application.DataTransfer.Cities;
using OnlineDeliveryProject.Application.DataTransfer.Orders;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.DataTransfer.Customers
{
    public class OneCustomerWithOrdersDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
