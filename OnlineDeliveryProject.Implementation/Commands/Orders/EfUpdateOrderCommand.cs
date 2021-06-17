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
    public class EfUpdateOrderCommand : IUpdateOrderCommand
    {
        private readonly OnlineDeliveryContext _context;
        private readonly IMapper _mapper;
        private readonly UpdateOrderValidator _validator;
        public EfUpdateOrderCommand(OnlineDeliveryContext context, IMapper mapper, UpdateOrderValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }
        public int Id => 9;

        public string Name => "EfUpdateOrderCommand";

        public void Execute(UpdateOrderRequest reqeust)
        {
            _validator.ValidateAndThrow(reqeust);

            var post = _mapper.Map<Order>(reqeust);

            _context.Orders.Add(post);

            _context.SaveChanges();
        }
    }
}
