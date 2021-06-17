using AutoMapper;
using OnlineDeliveryProject.Application.DataTransfer.Resturants;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Profiles.Restaurants
{
    public class OneRestaurantProfile : Profile
    {
        public OneRestaurantProfile()
        {
            CreateMap<RestaurantDto, Restaurant>();
            CreateMap<Restaurant, RestaurantDto>();
        }
    }
}
