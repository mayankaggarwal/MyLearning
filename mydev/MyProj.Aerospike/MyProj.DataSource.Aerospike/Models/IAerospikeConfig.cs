using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.DataSource.Aerospike.Models
{
    public interface IAerospikeConfig
    {
        string _namespace { get; }
        string _setname { get; }
        string _binname { get; }

    }
}
