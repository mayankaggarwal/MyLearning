using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerModule
{
    public class CustomLogger: ICustomLogger
    {
        private bool isConsole = false;
        public CustomLogger()
        {

        }
        public CustomLogger(bool isConsole)
        {
            this.isConsole = isConsole;
        }
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public void Log(string message)
        {
            if(isConsole)
            {
                Console.WriteLine(message);
            }
            else
            {
                logger.Info(message);
            }
            
        }
    }
}
