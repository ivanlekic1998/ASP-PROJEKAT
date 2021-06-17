using OnlineDeliveryProject.Application.Requests.Reviews;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Commands.Reviews
{
    public interface IAddReviewCommand : ICommand<AddReviewRequest>
    {
    }
}
