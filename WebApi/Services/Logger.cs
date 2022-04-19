using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public class Logger
    {
        public string Message { get; set; }
        public string LoggerName {get;set;}
        public Logger(string message, string loggerName)
        {
            Message = message;
            LoggerName = loggerName;
        }
    }
}