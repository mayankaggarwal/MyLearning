using MyProj.CM.Common.Contracts.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Common.Contracts.Data.Client
{
    public class Client
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long ClientTypeId { get; set; }
        public long? RetailClientId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long CreatedByUserId { get; set; }
        public string CreatedUserName { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long UpdatedByUserId { get; set; }
        public string UpdatedUserName { get; set; }
        public bool IsArchived { get; set; }
        public string Group { get; set; }
        public long BrandCount { get; set; }
        public ClientType? ClientType { get; set; }
    }
}
