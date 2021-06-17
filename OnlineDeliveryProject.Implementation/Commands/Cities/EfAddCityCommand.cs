using AutoMapper;
using OnlineDeliveryProject.Application.Requests.Cities;
using FluentValidation;
using OnlineDeliveryProject.Application.Commands.Cities;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using OnlineDeliveryProject.Implementation.Validators.Cities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Commands.Cities
{
    public class EfAddCityCommand : IAddCityCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly IMapper _mapper;
        private readonly AddCityValidator _validator;

        public EfAddCityCommand(OnlineDeliveryContext context, IMapper mapper, AddCityValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 4;

        public string Name => "EfAddCityCommand";

        public void Execute(AddCityRequest request)
        {
            _validator.ValidateAndThrow(request);

            var city = _mapper.Map<City>(request);
            _context.Cities.Add(city);

            _context.SaveChanges();
        }
    }
}
