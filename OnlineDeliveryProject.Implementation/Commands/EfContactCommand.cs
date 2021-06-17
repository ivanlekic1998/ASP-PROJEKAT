using AutoMapper;
using OnlineDeliveryProject.Application.DataTransfer;
using OnlineDeliveryProject.Application.Email;
using OnlineDeliveryProject.Implementation.Validators;
using FluentValidation;
using OnlineDeliveryProject.Application.Commands;
using OnlineDeliveryProject.Application.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Commands
{
    public class EfContactCommand : IContactCommand
    {
        private readonly IEmailSender _sender;
        private readonly IMapper _mapper;
        private readonly ContactValidator _validator;

        public EfContactCommand(IEmailSender sender, IMapper mapper, ContactValidator validator)
        {
            _sender = sender;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 400;

        public string Name => "ContactCommand";

        public void Execute(ContactRequest request)
        {

            _validator.ValidateAndThrow(request);


            var info = _mapper.Map<SendEmailDto>(request);
            info.Subject = $"Title: {request.Subject} Send From: {request.SendFrom}";
            info.SendTo = "ivanlekic11@gmail.com";
            _sender.Send(info);
        }
    }
}
