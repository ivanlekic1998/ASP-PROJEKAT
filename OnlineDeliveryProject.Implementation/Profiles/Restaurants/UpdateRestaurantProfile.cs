using AutoMapper;
using OnlineDeliveryProject.Application.Requests.Restaurants;
using OnlineDeliveryProject.Domain;

namespace OnlineDeliveryProject.Implementation.Profiles.Restaurants
{
    public class UpdateRestaurantProfile : Profile
    {
        public UpdateRestaurantProfile()
        {
            CreateMap<UpdateRestaurantRequest, Restaurant>();
            CreateMap<Restaurant, UpdateRestaurantRequest>();
        }
    }
}