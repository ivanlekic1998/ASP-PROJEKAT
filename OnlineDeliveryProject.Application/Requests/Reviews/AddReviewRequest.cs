using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Requests.Reviews
{
    public class AddReviewRequest
    {
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
    }
}
