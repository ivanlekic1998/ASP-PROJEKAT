using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.DataTransfer
{
    public class LogExceptionDto
    {
        public string Response { get; set; }
        public int StatusCode { get; set; }
        public string Exception { get; set; }
    }
}
