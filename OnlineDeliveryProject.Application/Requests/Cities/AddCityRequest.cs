using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Requests.Cities
{
    public class AddCityRequest
    {
        public string Name { get; set; }
        public string PostCode { get; set; }
    }
}
