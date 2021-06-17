using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Domain
{
    public class Restaurant : Entity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string WorkingHours { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
