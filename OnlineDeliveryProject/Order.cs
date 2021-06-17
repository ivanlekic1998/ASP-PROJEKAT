using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Domain
{
    public class Order : Entity
    {
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public int? EstimatedDeliveryTimeMins { get; set; }
        public string Notes { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
    }
}
