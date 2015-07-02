using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLabService
{
    internal class Test : Item
    {
        // Property Type
        public TestType Type { get; set; }

        // Constructor
        public Test(string code, string name, TestType type): base(code, name)
        {
            this.Type = type;
        }
    }
}
