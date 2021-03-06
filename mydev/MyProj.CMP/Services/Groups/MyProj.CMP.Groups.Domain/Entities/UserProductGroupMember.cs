﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Groups.Domain.Entities
{
    public class UserProductGroupMember:Contracts.Entity
    {
        public override long Id { get => base.Id; set => base.Id = value; }
        public int UserProductGroupId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsValid { get; set; }
        public string AltCode { get; set; }
        public string HierarchyKey { get; set; }
        public double TotalSpend { get; set; }
        public double TotalQuantity { get; set; }

        public virtual UserProductGroup UserProductGroup { get; set; }
    }
}
