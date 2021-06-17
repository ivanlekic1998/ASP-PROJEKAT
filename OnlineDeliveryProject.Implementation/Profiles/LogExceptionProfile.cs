using AutoMapper;
using OnlineDeliveryProject.Application.DataTransfer;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Profiles
{
    public class LogExceptionProfile : Profile
    {
        public LogExceptionProfile()
        {
            CreateMap<LogExceptionDto, ExceptionLog>();
            CreateMap<ExceptionLog, LogExceptionDto>();

        }
    }
}
