using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application.Exceptions
{
    public class DateFromLessDateToException : Exception
    {
        public DateFromLessDateToException(DateTime DateFrom, DateTime DateTo)
           : base($"DateTo: {DateTo.Date} cant be before DateFrom: {DateFrom.Date}")
        {

        }
    }
}
