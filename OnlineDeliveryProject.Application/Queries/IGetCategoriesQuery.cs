using OnlineDeliveryProject.Application.DataTransfer;
using OnlineDeliveryProject.Application;
using OnlineDeliveryProject.Application.Queries;
using OnlineDeliveryProject.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Queries
{
    public interface IGetCategoriesQuery : IQuery<CategoriesSearch, PagedResponse<CategoriesDto>>
    {
    }
}
