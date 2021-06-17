using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Requests.Cities
{
    public class UpdateCityRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostCode { get; set; }
    }
}
