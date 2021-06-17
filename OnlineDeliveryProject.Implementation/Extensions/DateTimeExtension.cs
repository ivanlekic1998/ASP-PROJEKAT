using OnlineDeliveryProject.Application.Exceptions;
using OnlineDeliveryProject.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Extensions
{
    public static class DateTimeExtension
    {
        public static void CheckDateTime<TEntity>(this IQueryable<TEntity> query, PagedSearch search)
        {
            if(search.DateFrom > search.DateTo)
            {
                throw new DateFromLessDateToException(search.DateFrom, search.DateTo);
            }
        }
    }
}
