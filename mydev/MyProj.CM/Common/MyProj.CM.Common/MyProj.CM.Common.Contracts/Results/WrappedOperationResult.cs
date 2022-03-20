using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Common.Contracts.Results
{
    public class WrappedOperationResult<T>:OperationResult
    {
        public T Data { get; set; }
    }
}
