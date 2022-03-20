using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Apps.Common.Session
{
    public interface IUserPrincipal
    {
        int AccountId { get; }
        string UserName { get; }
        string FullName { get; }
        string Email { get; }
        int Market { get; }
        int Client { get; }
        string Type { get; }
        string PreferredLanguageId { get; }
        ApplicationRole[] ApplicationRole { get; set; }
    }
}
