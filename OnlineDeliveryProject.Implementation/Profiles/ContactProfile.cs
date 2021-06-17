using AutoMapper;
using OnlineDeliveryProject.Application.DataTransfer;
using OnlineDeliveryProject.Application.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<SendEmailDto, ContactRequest>();
            CreateMap<ContactRequest, SendEmailDto>();
        }
    }
}
