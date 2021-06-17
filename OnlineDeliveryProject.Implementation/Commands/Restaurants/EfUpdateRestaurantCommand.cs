using AutoMapper;
using OnlineDeliveryProject.Application.Exceptions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineDeliveryProject.Application;
using OnlineDeliveryProject.Application.Commands.Restaurants;
using OnlineDeliveryProject.Application.Requests.Restaurants;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using OnlineDeliveryProject.Implementation.Validators.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Commands.Restaurants
{
    public class EfUpdateRestaurantCommand : IUpdateRestaurantCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly IMapper _mapper;
        private readonly IApplicationActor _actor;
        private readonly UpdateRestaurantValidator _validator;

        public EfUpdateRestaurantCommand(OnlineDeliveryContext context, IMapper mapper, IApplicationActor actor, UpdateRestaurantValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _actor = actor;
            _validator = validator;
        }
        public int Id => 10;

        public string Name => "EfUpdateRestaurantCommand";

        public void Execute(UpdateRestaurantRequest request)
        {
            _validator.ValidateAndThrow(request);

            var restaurant = _context.Restaurants.Find(request.Id);

            if (restaurant == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Restaurant));
            }

            _mapper.Map(request, restaurant);

            _context.SaveChanges();
        }
    }
}
