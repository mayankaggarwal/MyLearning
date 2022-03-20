using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Apps.Common.Session
{
    public class UserPrincipal : IUserPrincipal
    {
        internal UserPrincipal() { }
        public int AccountId { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public int Market { get; set; }

        public int Client { get; set; }

        public string Type { get; set; }

        public string PreferredLanguageId { get; set; }

        public ApplicationRole[] ApplicationRole { get; set; }

        public static IUserPrincipal GetSystemUserPrincipal()
        {
            return new UserPrincipal
            {
                AccountId = 1,
                UserName = "System"
            };
        }
    }
}
