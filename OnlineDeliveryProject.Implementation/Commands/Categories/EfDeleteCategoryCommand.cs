using AutoMapper;
using OnlineDeliveryProject.Application.Commands.Categories;
using OnlineDeliveryProject.Application.Exceptions;
using FluentValidation;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using OnlineDeliveryProject.Implementation.Validators.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Commands.Categories
{
    public class EfDeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly DeleteCategoryValidator _validator;
        public EfDeleteCategoryCommand(OnlineDeliveryContext context, DeleteCategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 3;

        public string Name => "EfDeleteCategoryCommand";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var findCategory = _context.Categories.Find(request);
            if (findCategory == null)
            {
                throw new EntityNotFoundException(request, typeof(Category));
            }

            findCategory.IsDeleted = true;
            findCategory.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
