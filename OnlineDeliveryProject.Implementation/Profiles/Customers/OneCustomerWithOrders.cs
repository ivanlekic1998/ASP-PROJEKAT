using AutoMapper;
using OnlineDeliveryProject.Application.DataTransfer.Customers;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Profiles.Customers
{
    public class OneCustomerWithOrders : Profile
    {
        public OneCustomerWithOrders()
        {
            CreateMap<Customer, OneCustomerWithOrdersDto>();
            CreateMap<OneCustomerWithOrdersDto, Customer>();
        }
    }
}
