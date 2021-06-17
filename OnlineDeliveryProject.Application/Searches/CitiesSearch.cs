using OnlineDeliveryProject.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Searches
{
    public class CitiesSearch : PagedSearch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PostCode { get; set; }
    }
}
