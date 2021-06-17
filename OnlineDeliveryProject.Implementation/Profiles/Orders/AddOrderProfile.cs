using AutoMapper;
using OnlineDeliveryProject.Application.Requests.Orders;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Profiles.Orders
{
    public class AddOrderProfile : Profile
    {
        public AddOrderProfile()
        {
            CreateMap<Order, AddOrderRequest>();
            CreateMap<AddOrderRequest, Order>();
        }
    }
}
