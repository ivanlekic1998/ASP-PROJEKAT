using AutoMapper;
using OnlineDeliveryProject.Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using OnlineDeliveryProject.Application.DataTransfer.Customers;
using OnlineDeliveryProject.Application.Queries.Customers;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Queries.Customers
{
    public class EfGetOneCustomerQuery : IGetOneCustomerFrontQuery
    {
        private readonly OnlineDeliveryContext _context;
        private readonly IMapper _mapper;

        public EfGetOneCustomerQuery(OnlineDeliveryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 11;

        public string Name => "EfGetOneCustomerQuery";

        public OneCustomerWithOrdersDto Execute(int search)
        {
            var c = _context.Customers.Find(search);

            if(c == null)
            {
                throw new EntityNotFoundException(search, typeof(Customer));
            }

            var queryUser = _context.Customers.Include(u => u.CustomerUseCases)
                .Include(u => u.City).Include(x => x.Orders)
                .Where(u => u.Id == search).First();

            var customer = _mapper.Map<OneCustomerWithOrdersDto>(queryUser);

            return customer;
        }
    }
}
