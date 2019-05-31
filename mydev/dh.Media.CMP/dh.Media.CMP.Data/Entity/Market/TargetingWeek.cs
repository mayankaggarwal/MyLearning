using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Entity
{
    public class TargetingWeek : Helpers.Entity
    {
        public override int Id { get; set; }
        public int WeekNumber { get; set; }
        public string Description { get; set; }
        public int RetailClientId { get; set; }
        public virtual RetailClient RetailClient { get; set; }

    }
}
