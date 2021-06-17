using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Domain
{
    public class Customer : Entity
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<CustomerUseCase> CustomerUseCases { get; set; } = new HashSet<CustomerUseCase>();
    }
}
