using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLabClient
{
    // Enumeration for browser
    public enum BrowserResults
    {
        None,   // Cancel or X button is pressed - nothing to do
        OK,     // Ok button is pressed - open exist item with Code. Code is in selected row in dataGridView1
        New     // New button is pressed - create new item
    }
}
