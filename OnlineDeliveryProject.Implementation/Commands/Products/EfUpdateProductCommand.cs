using AutoMapper;
using OnlineDeliveryProject.Application.Exceptions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineDeliveryProject.Application;
using OnlineDeliveryProject.Application.Commands.Products;
using OnlineDeliveryProject.Application.Requests.Products;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using OnlineDeliveryProject.Implementation.Validators.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Commands.Products
{
    public class EfUpdateProductCommand : IUpdateProductCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly IMapper _mapper;
        private readonly IApplicationActor _actor;
        private readonly UpdateProductValidator _validator;

        public EfUpdateProductCommand(OnlineDeliveryContext context, IMapper mapper, IApplicationActor actor, UpdateProductValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _actor = actor;
            _validator = validator;
        }
        public int Id => 9;

        public string Name => "EfUpdateProductValidator";

        public void Execute(UpdateProductRequest request)
        {
            _validator.ValidateAndThrow(request);

            var findProduct = _context.Products.Find(request.Id);

            if (findProduct == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Product));
            }

            if (_actor.Id != findProduct.Id)
            {
                throw new ForbiddenAccessException(_actor, this.Name);
            }

            var product = _context.Products.Include(x => x.ProductOrders).Include(x => x.Category)
                .Where(x => x.Id == request.Id).FirstOrDefault();

            _mapper.Map(request, product);

            _context.SaveChanges();
        }
    }
}
