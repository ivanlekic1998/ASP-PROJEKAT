using AutoMapper;
using OnlineDeliveryProject.Application.DataTransfer.Customers;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Profiles.Customers
{
    public class OneCustomerProfile : Profile
    {
        public OneCustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(
                dto => dto.CustomerUseCase,
                opt => opt.MapFrom(x =>
                x.CustomerUseCases.Select(y => y.UseCaseId).ToList()
                ));
            CreateMap<CustomerDto, Customer>();
        }
    }
}
