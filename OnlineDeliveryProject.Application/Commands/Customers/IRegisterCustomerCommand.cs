using OnlineDeliveryProject.Application.Requests.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Commands.Customers
{
    public interface IRegisterCustomerCommand : ICommand<RegisterCustomerRequest>
    {
    }
}
