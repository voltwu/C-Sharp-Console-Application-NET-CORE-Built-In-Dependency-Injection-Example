using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public class ConsoleLog : ILog
    {
        public void Write(string message)
        {
            Console.Write(message);
        }
    }
}
