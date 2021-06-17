using AutoMapper;
using OnlineDeliveryProject.Application.Requests.Orders;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Profiles.Orders
{
    public class UpdateOrderProfile : Profile
    {
        public UpdateOrderProfile()
        {
            CreateMap<UpdateOrderRequest, Order>();
            CreateMap<Order, UpdateOrderRequest>();
        }
    }
}
