using AutoMapper;
using OnlineDeliveryProject.Application.Requests.Customers;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Profiles.Customers
{
    public class AddCustomerProfile : Profile
    {
        public AddCustomerProfile()
        {
            CreateMap<Customer, AddCustomerRequest>();
            CreateMap<AddCustomerRequest, Customer>()
                .ForMember(x => x.CustomerUseCases, opt => opt.Ignore());
        }
    }
}
