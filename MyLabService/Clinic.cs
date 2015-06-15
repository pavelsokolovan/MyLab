using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLabService
{
    class Clinic: Item
    {
        // Property Location
        public string Location { get; set; }

        // Constructor
        public Clinic(string code, string name, string location): base(code, name)
        {
            this.Location = location;
        }
     }
}
