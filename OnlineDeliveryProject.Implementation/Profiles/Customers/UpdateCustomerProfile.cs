using AutoMapper;
using OnlineDeliveryProject.Application.Requests.Customers;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Profiles.Customers
{
    public class UpdateCustomerProfile : Profile
    {
        public UpdateCustomerProfile()
        {
            CreateMap<UpdateCustomerRequest, Customer>();
            CreateMap<Customer, UpdateCustomerRequest>();
        }
    }
}
