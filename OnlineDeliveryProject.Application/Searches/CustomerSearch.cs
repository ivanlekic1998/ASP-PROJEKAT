using OnlineDeliveryProject.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Searches
{
    public class CustomerSearch : PagedSearch
    {
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
