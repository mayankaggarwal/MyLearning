﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Audiences.Domain.Entities
{
    public class TargetingWeek : Contracts.Entity
    {
        public override long Id { get; set; }
        public int WeekNumber { get; set; }
        public string Description { get; set; }
        public int RetailClientId { get; set; }
        //public virtual RetailClient RetailClient { get; set; }

    }
}
