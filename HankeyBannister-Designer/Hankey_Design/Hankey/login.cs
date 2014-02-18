using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hankey
{
    public class login
    {
        public string username;
        string password;
        string provider;
        public login(string a, string b, string c)
        {
            username = a;
            password = b;
            provider = c;
        }
        public bool verificate(string a)
        {
            if ((a.Contains("@gmail.com")) || (a.Contains("@mail.ru")) || (a.Contains("@ukr.net")))
                return true;
            else return false;
        }
    }
}
