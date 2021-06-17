using OnlineDeliveryProject.Application.Exceptions;
using FluentValidation;
using OnlineDeliveryProject.Application.Commands.Reviews;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using OnlineDeliveryProject.Implementation.Validators.Reviews;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Commands.Reviews
{
    public class EfDeleteReviewCommand : IDeleteReviewCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly DeleteReviewValidator _validator;

        public EfDeleteReviewCommand(OnlineDeliveryContext context, DeleteReviewValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 2;

        public string Name => "EfDeleteReviewCommand";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var review = _context.Reviews.Find(request);
            if (review == null)
            {
                throw new EntityNotFoundException(request, typeof(Review));
            }

            review.IsDeleted = true;
            review.DeletedAt = DateTime.UtcNow;


            _context.SaveChanges();
        }
    }
}
