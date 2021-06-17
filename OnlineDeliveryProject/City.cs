using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Domain
{
    public class City : Entity
    {
        public string Name { get; set; }
        public int PostCode { get; set; }
        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
        public virtual ICollection<Restaurant> Restaurants { get; set; } = new HashSet<Restaurant>();
    }
}
