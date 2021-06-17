using OnlineDeliveryProject.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Searches
{
    public class RestaurantSearch : PagedSearch
    {
        public string Keyword { get; set; }
    }
}
