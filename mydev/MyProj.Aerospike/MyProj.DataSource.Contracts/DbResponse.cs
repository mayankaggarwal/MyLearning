using System;

namespace MyProj.DataSource.Contracts
{
    public class DbResponse
    {
        public bool Success { get; set; }
        public DbResponseStatus Status { get; set; }
        public string Message { get; set; }
    }
}
