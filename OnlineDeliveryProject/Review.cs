using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Domain
{
    public class Review : Entity
    {
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public string Description { get; set; }
        public decimal? Rating { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
