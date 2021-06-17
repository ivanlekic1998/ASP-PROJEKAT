using AutoMapper;
using FluentValidation;
using OnlineDeliveryProject.Application;
using OnlineDeliveryProject.Application.Commands.Reviews;
using OnlineDeliveryProject.Application.Requests.Reviews;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using OnlineDeliveryProject.Implementation.Validators.Reviews;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Commands.Reviews
{
    public class EfAddReviewCommand : IAddReviewCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly IApplicationActor _actor;
        private readonly AddReviewValidator _validator;
        private readonly IMapper _mapper;


        public EfAddReviewCommand(OnlineDeliveryContext context, IApplicationActor actor, AddReviewValidator validator, IMapper mapper)
        {
            _context = context;
            _actor = actor;
            _validator = validator;
            _mapper = mapper;
        }
        public int Id => 7;

        public string Name => "EfAddReviewCommand";

        public void Execute(AddReviewRequest request)
        {
            _validator.ValidateAndThrow(request);
            request.CustomerId = _actor.Id;
            var comment = _mapper.Map<Review>(request);

            _context.Add(comment);
            _context.SaveChanges();
        }
    }
}
