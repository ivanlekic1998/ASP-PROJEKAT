using OnlineDeliveryProject.Application.DataTransfer;
using OnlineDeliveryProject.Application.Searches;
using OnlineDeliveryProject.Application;
using OnlineDeliveryProject.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Queries
{
    public interface IGetLogsExceptionQuery : IQuery<LogExceptionSearch, PagedResponse<LogExceptionDto>>
    {
    }
}
