using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Entity
{
    public class UserProductGroup:Helpers.Entity
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public int RetailClientId { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public int ValidMemberCount { get; set; }
        public int TotalMemberCount { get; set; }
        public string InputFilter { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UpdatedByUserId { get; set; }

        public virtual RetailClient RetailClient { get; set; }
        public virtual Account CreatedBy { get; set; }
        public virtual Account UpdatedBy { get; set; }
        public virtual ICollection<UserProductGroupMember> Members { get; set; }
    }
}
