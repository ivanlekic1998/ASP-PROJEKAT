using OnlineDeliveryProject.Application;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Logging
{
    public class DatabaseExceptionLogger : IExceptionLogger
    {
        private readonly OnlineDeliveryContext _context;
        public DatabaseExceptionLogger(OnlineDeliveryContext context)
        {
            _context = context;
        }

        public void LogEx(string response, int statusCode, string exception)
        {
            var newException = new ExceptionLog
            {
                Response = response,
                StatusCode = statusCode,
                Exception = exception
            };

            _context.ExceptionLogs.Add(newException);
            _context.SaveChanges();
        }
    }
}
