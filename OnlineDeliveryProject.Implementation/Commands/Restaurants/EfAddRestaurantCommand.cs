using AutoMapper;
using FluentValidation;
using OnlineDeliveryProject.Application.Commands.Restaurants;
using OnlineDeliveryProject.Application.Requests.Restaurants;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using OnlineDeliveryProject.Implementation.Validators.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Commands.Restaurants
{
    public class EfAddRestaurantCommand : IAddRestaurantCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly IMapper _mapper;
        private readonly AddRestaurantValidator _validator;
        public EfAddRestaurantCommand(OnlineDeliveryContext context, IMapper mapper, AddRestaurantValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }
        public int Id => 10;

        public string Name => "EfAddRestaurantCommand";

        public void Execute(AddRestaurantRequest reqeust)
        {
            _validator.ValidateAndThrow(reqeust);

            var post = _mapper.Map<Restaurant>(reqeust);

            _context.Restaurants.Add(post);

            _context.SaveChanges();
        }
    }
}
