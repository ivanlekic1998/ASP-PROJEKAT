using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Domain
{
    public class CustomerUseCase : Entity
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
