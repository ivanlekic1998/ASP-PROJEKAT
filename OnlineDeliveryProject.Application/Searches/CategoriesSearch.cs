using OnlineDeliveryProject.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Searches
{
    public class CategoriesSearch : PagedSearch
    {
        public string Name { get; set; }
    }
}
