using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.DataSource.Aerospike.Models
{
    public class AerospikeConfig : IAerospikeConfig
    {
        public AerospikeConfig(string namepace,string setname,string binname)
        {
            _namespace = namepace;
            _setname = setname;
            _binname = binname;
        }

        //public const string Namepsace= Configuration
        public string _namespace { get ; private set; }
        public string _setname { get ; private set; }
        public string _binname { get ; private set; }
    }
}
