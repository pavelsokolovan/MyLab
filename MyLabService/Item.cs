using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLabService
{
    public abstract class Item
    {
        private string code;    // code of Item

        // Property Code
        public string Code
        {
            get
            {
                return code;
            }
        }

        // Property Name
        public string Name { get; set; }

        // Constructor 0
        public Item()
        { }
        
        // Constructor 1
        public Item(string code, string name)
        {
            this.code = code;
            this.Name = name;
        }
    }
}
