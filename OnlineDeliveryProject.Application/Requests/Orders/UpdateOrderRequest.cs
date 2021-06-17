using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Requests.Orders
{
    public class UpdateOrderRequest
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public int EstimatedDeliveryTimeMins { get; set; }
        public string Notes { get; set; }
    }
}
