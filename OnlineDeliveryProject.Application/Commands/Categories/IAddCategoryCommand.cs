using OnlineDeliveryProject.Application.Requests.Categories;
using OnlineDeliveryProject.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Commands.Categories
{
    public interface IAddCategoryCommand : ICommand<AddCategoryRequest>
    {
    }
}
