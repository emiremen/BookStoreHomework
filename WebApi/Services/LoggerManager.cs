using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public class LoggerManager : ILoggerService
    {
        public void Write(Logger logger)
        {
            Console.WriteLine("[{0}] - {1}",logger.LoggerName, logger.Message);
        }
    }
}