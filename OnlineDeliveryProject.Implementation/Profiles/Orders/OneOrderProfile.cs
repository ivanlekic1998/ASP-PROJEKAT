using AutoMapper;
using OnlineDeliveryProject.Application.DataTransfer.Orders;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Profiles.Orders
{
    public class OneOrderProfile : Profile
    {
        public OneOrderProfile()
        {
            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>();
        }
    }
}
