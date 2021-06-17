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
    public class EfGetLogQuery : IGetLogsQuery
    {
        private readonly OnlineDeliveryContext _context;
        private readonly IMapper _mapper;
        public EfGetLogQuery(OnlineDeliveryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 700;

        public string Name => "EfGetLogQuest";

        public PagedResponse<LogDto> Execute(LogSearch search)
        {
            var query = _context.UseCaseLogs.OrderByDescending(x => x.Id).AsQueryable();

            if (!string.IsNullOrEmpty(search.Actor) || !string.IsNullOrWhiteSpace(search.Actor))
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.Actor.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.UseCaseName) || !string.IsNullOrWhiteSpace(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }

            if (search.DateFrom != DateTime.MinValue)
            {
                query = query.Where(x => x.CreatedAt.Date >= search.DateFrom.Date);
            }

            if (search.DateTo != DateTime.MinValue && search.DateTo >= search.DateFrom)
            {
                query = query.Where(x => x.CreatedAt.Date <= search.DateTo.Date);
            }

            return query.Paged<LogDto, UseCaseLog>(search, _mapper);



        }

    }
}
