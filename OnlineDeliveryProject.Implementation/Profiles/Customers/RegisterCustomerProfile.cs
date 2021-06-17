using AutoMapper;
using OnlineDeliveryProject.Application.Requests.Customers;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Profiles.Customers
{
    public class RegisterCustomerProfile : Profile
    {
        public RegisterCustomerProfile()
        {
            CreateMap<Customer, RegisterCustomerRequest>();
            CreateMap<RegisterCustomerRequest, Customer>()
                .ForMember(x => x.CustomerUseCases, opt => opt.Ignore());
        }
    }
}
