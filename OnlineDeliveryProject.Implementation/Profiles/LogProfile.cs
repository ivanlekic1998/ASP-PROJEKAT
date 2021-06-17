using AutoMapper;
using OnlineDeliveryProject.Application.DataTransfer;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Profiles
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<UseCaseLog, LogDto>();
            CreateMap<LogDto, UseCaseLog>();

        }
    }
}
