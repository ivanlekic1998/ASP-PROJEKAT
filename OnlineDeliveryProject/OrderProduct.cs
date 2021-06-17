using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Domain
{
    public class OrderProduct
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
