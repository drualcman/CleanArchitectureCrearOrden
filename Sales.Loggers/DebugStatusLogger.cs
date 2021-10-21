using Sales.Entities.Interfaces;
using System;
using System.Diagnostics;

namespace Sales.Loggers
{
    public class DebugStatusLogger : IApplicationStatusLogger
    {
        public void Log(string message)
        {
            Debug.WriteLine($"*** Debug Status Logger: {message}");
        }
    }
}
