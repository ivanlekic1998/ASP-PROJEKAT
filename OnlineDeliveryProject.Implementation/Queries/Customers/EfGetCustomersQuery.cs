using AutoMapper;
using OnlineDeliveryProject.Application.Exceptions;
using OnlineDeliveryProject.Application.Queries;
using OnlineDeliveryProject.Implementation.Extensions;
using OnlineDeliveryProject.Application;
using OnlineDeliveryProject.Application.DataTransfer.Customers;
using OnlineDeliveryProject.Application.Queries.Customers;
using OnlineDeliveryProject.Application.Searches;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Queries.Customers
{
    public class EfGetCustomersQuery : IGetCustomersQuery
    {
        public readonly OnlineDeliveryContext _context;
        private readonly IMapper _mapper;
        public EfGetCustomersQuery(OnlineDeliveryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 9;

        public string Name => "EfGetCustomersQuery";

        public PagedResponse<CustomerDto> Execute(CustomerSearch search)
        {
            var query = _context.Customers.OrderByDescending(x => x.Id).AsQueryable();

            if (!string.IsNullOrEmpty(search.FullName) || !string.IsNullOrWhiteSpace(search.FullName))
            {
                query = query.Where(x => x.Email.ToLower().Contains(search.FullName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.Email) || !string.IsNullOrWhiteSpace(search.Email))
            {
                query = query.Where(x => x.Email.ToLower().Contains(search.Email.ToLower()));
            }


            return query.Paged<CustomerDto, Customer>(search, _mapper);
        }
    }
}
