using AutoMapper;
using OnlineDeliveryProject.Application.Exceptions;
using FluentValidation;
using OnlineDeliveryProject.Application;
using OnlineDeliveryProject.Application.Commands.Reviews;
using OnlineDeliveryProject.Application.Requests.Reviews;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using OnlineDeliveryProject.Implementation.Validators.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Commands.Reviews
{
    public class EfUpdateReviewCommand : IUpdateReviewCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly UpdateReviewValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfUpdateReviewCommand(OnlineDeliveryContext context, UpdateReviewValidator validator, IApplicationActor actor, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
            _mapper = mapper;
        }
        public int Id => 2;

        public string Name => "EfUpdateReviewCommand";

        public void Execute(UpdateReviewRequest request)
        {
            _validator.ValidateAndThrow(request);

            var comment = _context.Reviews.Find(request.Id);
            if (comment == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Review));
            }

            if (_actor.Id != comment.CustomerId)
            {
                throw new ForbiddenAccessException(_actor, this.Name);
            }

            var commentQuery = _context.Reviews.Where(x => x.Id == request.Id).FirstOrDefault();

            _mapper.Map(request, commentQuery);

            _context.SaveChanges();
        }
    }
}
