using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Requests.Customers
{
    public class AddCustomerRequest
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<int> UserUseCases { get; set; } = new List<int>();
        public object CustomerUseCases { get; set; }
    }
}
