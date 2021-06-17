using OnlineDeliveryProject.Application.Exceptions;
using FluentValidation;
using OnlineDeliveryProject.Application.Commands.Restaurants;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using OnlineDeliveryProject.Implementation.Validators.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Commands.Restaurants
{
    public class EfDeleteRestaurantCommand : IDeleteRestaurantCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly DeleteRestaurantValidator _validator;

        public EfDeleteRestaurantCommand(OnlineDeliveryContext context, DeleteRestaurantValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 10;

        public string Name => "EfDeleteRestaurantCommand";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var post = _context.Restaurants.Find(request);

            if (post == null)
            {
                throw new EntityNotFoundException(request, typeof(Restaurant));
            }


            post.IsDeleted = true;
            post.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
