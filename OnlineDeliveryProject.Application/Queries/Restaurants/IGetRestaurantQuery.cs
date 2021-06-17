using OnlineDeliveryProject.Application.DataTransfer.Resturants;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Queries.Restaurants
{
    public interface IGetRestaurantQuery : IQuery<int, RestaurantDto>
    {
    }
}
