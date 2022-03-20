using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Common.Contracts.Results
{
    public class OperationLog
    {
        public string Message { get; set; }
        public string MessageKey { get; set; }
        public OperationLogType LogType { get; set; }
        public Dictionary<OperationArgumentType,string> Parameters { get; set; }
    }

    public enum OperationLogType
    {
        Error=1,
        Warning=2,
        CriticalError=3
    }

    public enum OperationArgumentType
    {
        Undefined=0
    }
}
