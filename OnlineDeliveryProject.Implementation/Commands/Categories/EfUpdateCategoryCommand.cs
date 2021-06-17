using AutoMapper;
using OnlineDeliveryProject.Application.Commands.Categories;
using OnlineDeliveryProject.Application.Exceptions;
using OnlineDeliveryProject.Application.Requests.Categories;
using FluentValidation;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using OnlineDeliveryProject.Implementation.Validators.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Commands.Categories
{
    public class EfUpdateCategoryCommand : IUpdateCategoryCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly IMapper _mapper;
        private readonly UpdateCategoryValidator _validator;
        public EfUpdateCategoryCommand(OnlineDeliveryContext context, IMapper mapper, UpdateCategoryValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }
        public int Id => 3;

        public string Name => "EfUpdateCategoryCommand";

        public void Execute(UpdateCategoryRequest request)
        {
            _validator.ValidateAndThrow(request);
            var findCategory = _context.Categories.Find(request.Id);
            if (findCategory == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Category));
            }

            var category = _context.Categories.Where(x => x.Id == request.Id).FirstOrDefault();
            _mapper.Map(request, category);
            _context.SaveChanges();
        }
    }
}
