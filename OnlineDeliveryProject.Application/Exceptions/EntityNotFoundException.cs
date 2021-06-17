using OnlineDeliveryProject.Application.Requests.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public UpdateCategoryRequest request;
        public Type type;

        public EntityNotFoundException(int id, Type type)
            : base($"Entity of type {type.Name} with and id of {id} was not found")
        {
        }

        public EntityNotFoundException(UpdateCategoryRequest request, Type type)
        {
            this.request = request;
            this.type = type;
        }
    }
}
