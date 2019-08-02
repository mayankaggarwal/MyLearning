using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerModule
{
    public interface ICustomLogger
    {
        void Log(string message);
    }
}
