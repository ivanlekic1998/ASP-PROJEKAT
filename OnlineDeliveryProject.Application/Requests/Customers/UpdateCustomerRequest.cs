using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Requests.Customers
{
    public class UpdateCustomerRequest
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<int> CustomerUseCases { get; set; } = new List<int>();
    }
}
