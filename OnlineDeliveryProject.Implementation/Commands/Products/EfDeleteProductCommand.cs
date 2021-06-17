using OnlineDeliveryProject.Application.Exceptions;
using FluentValidation;
using OnlineDeliveryProject.Application.Commands.Products;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using OnlineDeliveryProject.Implementation.Validators.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Commands.Products
{
    public class EfDeleteProductCommand : IDeleteProductCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly DeleteProductValidator _validator;


        public EfDeleteProductCommand(OnlineDeliveryContext context, DeleteProductValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var post = _context.Products.Find(request);

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
