using OnlineDeliveryProject.Application.DataTransfer.Cities;
using OnlineDeliveryProject.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Queries
{
    public interface IGetCitiesQuery : IQuery<CitiesSearch, PagedResponse<CityDto>>
    {
    }
}
