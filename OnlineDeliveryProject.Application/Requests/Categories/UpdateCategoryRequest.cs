using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Requests.Categories
{
    public class UpdateCategoryRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
