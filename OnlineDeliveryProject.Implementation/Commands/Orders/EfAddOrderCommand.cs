using AutoMapper;
using FluentValidation;
using OnlineDeliveryProject.Application.Commands.Orders;
using OnlineDeliveryProject.Application.Requests.Orders;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using OnlineDeliveryProject.Implementation.Validators.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Commands.Orders
{
    public class EfAddOrderCommand : IAddOrderCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly IMapper _mapper;
        private readonly AddOrderValidator _validator;
        public EfAddOrderCommand(OnlineDeliveryContext context, IMapper mapper, AddOrderValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }
        public int Id => 10;

        public string Name => "EfAddOrderCommand";

        public void Execute(AddOrderRequest reqeust)
        {
            _validator.ValidateAndThrow(reqeust);

            var post = _mapper.Map<Order>(reqeust);

            _context.Orders.Add(post);

            _context.SaveChanges();
        }
    }
}
