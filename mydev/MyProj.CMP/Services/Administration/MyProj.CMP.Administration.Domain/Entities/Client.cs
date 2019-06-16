using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Administration.Domain.Entities
{
    public class Client:Contracts.Entity
    {
        public override long Id { get => base.Id; set => base.Id = value; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long ClientTypeId { get; set; }
        public long? RetailClientId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long UpdatedByUserId { get; set; }
        public bool IsArchived { get; set; }
        public string Group { get; set; }
        public virtual RetailClient RetailClient { get; set; }
        public virtual Account CreatedBy { get; set; }
        public virtual Account UpdatedBy { get; set; }
        public ClientType ClientType { get; set; }
    }
}
