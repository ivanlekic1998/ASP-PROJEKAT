using AutoMapper;
using OnlineDeliveryProject.Application.Requests.Restaurants;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Profiles.Restaurants
{
    public class AddRestaurantProfile : Profile
    {
        public AddRestaurantProfile()
        {
            CreateMap<Restaurant, AddRestaurantRequest>();
            CreateMap<AddRestaurantRequest, Restaurant>();
        }
    }
}
