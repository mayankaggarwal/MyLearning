using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProj.CM.Common.Contracts.Results
{
    public class OperationResult
    {
        public bool Successful { get; set; }
        public IEnumerable<OperationLog> Logs { get; set; }
        public IEnumerable<string> Errors
        {
            get { return Logs?.Where(x => x.LogType.Equals(OperationLogType.Error)).Select(x => x.Message); }
        }

        public IEnumerable<string> Warnings
        {
            get { return Logs?.Where(x => x.LogType.Equals(OperationLogType.Warning)).Select(x => x.Message); }
        }
    }
}
