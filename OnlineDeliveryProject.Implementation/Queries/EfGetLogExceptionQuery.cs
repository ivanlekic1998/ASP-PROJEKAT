using AutoMapper;
using OnlineDeliveryProject.Application.DataTransfer;
using OnlineDeliveryProject.Application.Queries;
using OnlineDeliveryProject.Application.Searches;
using OnlineDeliveryProject.Implementation.Extensions;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Queries
{
    public class EfGetLogExceptionQuery : IGetLogsExceptionQuery
    {
        private readonly OnlineDeliveryContext _context;
        private readonly IMapper _mapper;
        public EfGetLogExceptionQuery(OnlineDeliveryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 701;

        public string Name => "EfGetLogExceptionQuery";

        public PagedResponse<LogExceptionDto> Execute(LogExceptionSearch search)
        {

            var query = _context.ExceptionLogs.OrderByDescending(x => x.Id).AsQueryable();

            if (!string.IsNullOrEmpty(search.Response) || !string.IsNullOrWhiteSpace(search.Response))
            {
                query = query.Where(x => x.Response.ToLower().Contains(search.Response.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.StatusCode.ToString()) || !string.IsNullOrWhiteSpace(search.StatusCode.ToString()))
            {
                query = query.Where(x => x.StatusCode.ToString().ToLower().Contains(search.StatusCode.ToString().ToLower()));
            }

            if (!string.IsNullOrEmpty(search.Exception) || !string.IsNullOrWhiteSpace(search.Exception))
            {
                query = query.Where(x => x.Exception.ToLower().Contains(search.Exception.ToLower()));
            }


            if (search.DateFrom != DateTime.MinValue)
            {
                query = query.Where(x => x.CreatedAt.Date >= search.DateFrom.Date);
            }

            if (search.DateTo != DateTime.MinValue && search.DateTo >= search.DateFrom)
            {
                query = query.Where(x => x.CreatedAt.Date <= search.DateTo.Date);
            }

            return query.Paged<LogExceptionDto, ExceptionLog>(search, _mapper);
        }
    }
}
