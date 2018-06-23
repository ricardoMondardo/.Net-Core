using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public class TestableService : ITestableService
    {

        public TestableService()
        {

        }

        public string SayHi()
        {
            return "Hi I am obj: " + GetHashCode();
        }
    }
}
