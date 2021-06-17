using AutoMapper;
using OnlineDeliveryProject.Application.Commands.Categories;
using OnlineDeliveryProject.Application.Requests.Categories;
using FluentValidation;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using OnlineDeliveryProject.Implementation.Validators.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Commands.Categories
{
    public class EfAddCategoryCommand : IAddCategoryCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly IMapper _mapper;
        private readonly AddCategoryValidator _validator;
        public EfAddCategoryCommand(OnlineDeliveryContext context, IMapper mapper, AddCategoryValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }
        public int Id => 3;

        public string Name => "EfAddCategoryCommand";

        public void Execute(AddCategoryRequest request)
        {
            _validator.ValidateAndThrow(request);

            var category = _mapper.Map<Category>(request);
            _context.Categories.Add(category);

            _context.SaveChanges();
        }
    }
}
