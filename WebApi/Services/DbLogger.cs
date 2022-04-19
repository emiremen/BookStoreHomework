using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public class DbLogger : Logger
    {
        public DbLogger(string message) : base(message, loggerName: "DbLogger")
        {

        }
    }
}