using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLabService
{
    internal class Tube : Item
    {
        // Property Volume
        public double Volume { get; set; }

        // Constructor
        public Tube(string code, string name, double volume): base(code, name)
        {
            this.Volume = volume;
        }
    }
}
