using AutoMapper;
using OnlineDeliveryProject.Application.Exceptions;
using OnlineDeliveryProject.Application.Requests.Cities;
using FluentValidation;
using OnlineDeliveryProject.Application.Commands.Cities;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using OnlineDeliveryProject.Implementation.Validators.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Commands.Cities
{
    public class EfUpdateCityCommand : IUpdateCityCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly UpdateCityValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateCityCommand(OnlineDeliveryContext context, UpdateCityValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }
        public int Id => 4;

        public string Name => "EfUpdateCityCommand";

        public void Execute(UpdateCityRequest request)
        {
            _validator.ValidateAndThrow(request);
            var findCategory = _context.Categories.Find(request.Id);
            if (findCategory == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(City));
            }

            var category = _context.Cities.Where(x => x.Id == request.Id).FirstOrDefault();
            _mapper.Map(request, category);
            _context.SaveChanges();
        }
    }
}
