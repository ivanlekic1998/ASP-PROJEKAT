using AutoMapper;
using OnlineDeliveryProject.Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using OnlineDeliveryProject.Application.DataTransfer.Resturants;
using OnlineDeliveryProject.Application.Queries;
using OnlineDeliveryProject.Application.Queries.Restaurants;
using OnlineDeliveryProject.Application.Searches;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Queries.Restaurants
{
    public class EfGetRestaurantsQuery : IGetRestaurantsQuery
    {
        public readonly OnlineDeliveryContext _context;
        private readonly IMapper _mapper;

        public EfGetRestaurantsQuery(OnlineDeliveryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 9;

        public string Name => "EfGetRestaurantsQuery";

        public PagedResponse<RestaurantDto> Execute(RestaurantSearch search)
        {
            var query = _context.Restaurants.OrderByDescending(x => x.Id).AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(x => x.Email.ToLower().Contains(search.Keyword.ToLower()) || x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

         return query.Paged<RestaurantDto, Restaurant>(search, _mapper);
        }
    }
}
