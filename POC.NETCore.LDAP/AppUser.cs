using System;
using System.Collections.Generic;
using System.Text;

namespace POC.NETCore.LDAP
{
    public class AppUser
    {
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
    }
}
