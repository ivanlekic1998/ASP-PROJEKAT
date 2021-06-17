using OnlineDeliveryProject.Application.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Commands
{
    public interface IContactCommand : ICommand<ContactRequest>
    {
    }
}
