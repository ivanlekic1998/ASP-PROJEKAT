﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application
{
    public interface IExceptionLogger
    {
        void LogEx(string resposne, int statusCode, string exception);
    }
}
