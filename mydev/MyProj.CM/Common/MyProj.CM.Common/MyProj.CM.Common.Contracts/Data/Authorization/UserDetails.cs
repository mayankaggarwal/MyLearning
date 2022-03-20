using MyProj.CM.Common.Contracts.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Common.Contracts.Data.Authorization
{
    public class UserDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int MarketId { get; set; }
        public int ClientId { get; set; }
        public ClientType ClientType { get; set; }
        public bool IsSupplier { get; set; }
        public AppRole[] AppRoles { get; set; }
        public int? PreferredLanguageId { get; set; }
        public bool MailReceivePreferrence { get; set; }
        public virtual string Group { get; set; }
    }
}
