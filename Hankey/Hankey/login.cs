using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hankey
{
    public class login
    {
        public string username;
        public string password;
        public string provider;
        public login(string name, string pass, string prov)
        {
            username = name;
            password = pass;
            provider = prov;
        }
        public bool verificate(string a)
        {
            if ((a.Contains("@gmail.com")) || (a.Contains("@mail.ru")) || (a.Contains("@ukr.net")))
                return true;
            else return false;
        }
    }
}
