using OnlineDeliveryProject.Application.Queries;
using OnlineDeliveryProject.Application.DataTransfer.Resturants;
using OnlineDeliveryProject.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Queries.Restaurants
{
    public interface IGetRestaurantsQuery : IQuery<RestaurantSearch, PagedResponse<RestaurantDto>>
    {
    }
}
