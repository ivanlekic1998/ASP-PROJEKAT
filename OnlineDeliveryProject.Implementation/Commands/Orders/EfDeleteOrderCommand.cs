using OnlineDeliveryProject.Application.Exceptions;
using FluentValidation;
using OnlineDeliveryProject.Application.Commands.Orders;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using OnlineDeliveryProject.Implementation.Validators.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Commands.Orders
{
    public class EfDeleteOrderCommand : IDeleteOrderCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly DeleteOrderValidator _validator;


        public EfDeleteOrderCommand(OnlineDeliveryContext context, DeleteOrderValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 7;

        public string Name => "EfDeleteOrderCommand";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var post = _context.Orders.Find(request);

            if (post == null)
            {
                throw new EntityNotFoundException(request, typeof(Order));
            }


            post.IsDeleted = true;
            post.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
