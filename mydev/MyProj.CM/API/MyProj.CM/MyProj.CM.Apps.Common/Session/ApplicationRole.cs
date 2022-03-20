using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Apps.Common.Session
{
    public class ApplicationRole
    {
        public ApplicationRole(string application, string role)
        {
            Application = application;
            Role = role;
        }

        public string Application { get; private set; }
        public string Role { get; private set; }
    }
}
