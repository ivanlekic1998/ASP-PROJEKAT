using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Requests
{
    public class ContactRequest
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string SendFrom { get; set; }
    }
}
