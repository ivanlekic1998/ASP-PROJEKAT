using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public int RestaurantId { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public decimal Size { get; set; }
        public virtual Category Category { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<OrderProduct> ProductOrders { get; set; } = new HashSet<OrderProduct>();
    }
}
