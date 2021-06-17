using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Requests.Restaurants
{
    public class AddRestaurantRequest
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string WorkingHours { get; set; }
        public int CityId { get; set; }
    }
}
