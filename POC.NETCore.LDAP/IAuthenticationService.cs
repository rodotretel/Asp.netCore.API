using System;
using System.Collections.Generic;
using System.Text;

namespace POC.NETCore.LDAP
{
    public interface IAuthenticationService
    {
        AppUser Login(string username, string password);
    }
}
