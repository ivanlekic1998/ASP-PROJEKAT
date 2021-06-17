using AutoMapper;
using OnlineDeliveryProject.Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using OnlineDeliveryProject.Application.DataTransfer.Resturants;
using OnlineDeliveryProject.Application.Queries.Restaurants;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Queries.Restaurants
{
    public class EfGetOneRestaurantQuery : IGetRestaurantQuery
    {
        private readonly OnlineDeliveryContext _context;
        private readonly IMapper _mapper;
        public EfGetOneRestaurantQuery(OnlineDeliveryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 10;

        public string Name => "EfGetOneRestaurantQuery";

        public RestaurantDto Execute(int search)
        {
            var u = _context.Restaurants.Find(search);

            if (u == null)
            {
                throw new EntityNotFoundException(search, typeof(Restaurant));
            }
            var queryUser = _context.Restaurants.Include(u => u.Products).ThenInclude(c => c.Category).Where(u => u.Id == search).First();

            var user = _mapper.Map<RestaurantDto>(queryUser);

            return user;
        }
    }
}
