using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Hankey;

namespace testlogin
{
    public class Class1
    {
        [Test]
        public void test1()
        {
            login az = new login("azaza@gmail.com", "asddsa", "asddsa");
            Assert.AreEqual(az.verificate(az.username),true);
        }
    }
}
