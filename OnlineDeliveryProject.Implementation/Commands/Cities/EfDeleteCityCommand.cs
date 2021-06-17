using OnlineDeliveryProject.Application.Exceptions;
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
    public class EfDeleteCityCommand : IDeleteCityCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly DeteleCityValidator _validator;

        public EfDeleteCityCommand(OnlineDeliveryContext context, DeteleCityValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 4;

        public string Name => "EfDeleteCityCommand";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var findCity = _context.Cities.Find(request);
            if (findCity == null)
            {
                throw new EntityNotFoundException(request, typeof(City));
            }

            findCity.IsDeleted = true;
            findCity.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
