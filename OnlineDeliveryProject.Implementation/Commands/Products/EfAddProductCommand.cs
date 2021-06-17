using AutoMapper;
using FluentValidation;
using OnlineDeliveryProject.Application.Commands.Products;
using OnlineDeliveryProject.Application.Requests.Products;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using OnlineDeliveryProject.Implementation.Validators.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Commands.Products
{
    public class EfAddProductCommand : IAddProductCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly IMapper _mapper;
        private readonly AddProductValidator _validator;
        public EfAddProductCommand(OnlineDeliveryContext context, IMapper mapper, AddProductValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 9;

        public string Name => "EfAddProductCommand";

        public void Execute(AddProductRequest reqeust)
        {
            _validator.ValidateAndThrow(reqeust);

            var post = _mapper.Map<Product>(reqeust);

            _context.Products.Add(post);

            _context.SaveChanges();
        }
    }
}
