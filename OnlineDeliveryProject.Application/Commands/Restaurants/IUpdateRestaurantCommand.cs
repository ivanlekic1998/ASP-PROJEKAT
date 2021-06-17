using OnlineDeliveryProject.Application.Requests.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Commands.Restaurants
{
    public interface IUpdateRestaurantCommand : ICommand<UpdateRestaurantRequest>
    {
    }
}
