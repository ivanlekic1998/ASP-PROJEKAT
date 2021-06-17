using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Requests.Orders
{
    public class AddOrderRequest
    {
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public int? EstimatedDeliveryTimeMins { get; set; }
        public string Notes { get; set; }
        public ICollection<int> ProductIDs { get; set; }
    }
}
