using OnlineDeliveryProject.Application.Requests.Cities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Commands.Cities
{
    public interface IAddCityCommand : ICommand<AddCityRequest>
    {
    }
}
