using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Entity
{
    public class Client:Helpers.Entity
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ClientTypeId { get; set; }
        public int? RetailClientId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UpdatedByUserId { get; set; }
        public bool IsArchived { get; set; }
        public string Group { get; set; }
        public virtual RetailClient RetailClient { get; set; }
        public virtual Account CreatedBy { get; set; }
        public virtual Account UpdatedBy { get; set; }
        public ClientType ClientType { get; set; }
    }
}
