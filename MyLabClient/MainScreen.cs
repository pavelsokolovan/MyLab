using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLabClient
{
    public partial class MainScreen : Form
    {
        // Constructor
        public MainScreen()
        {
            InitializeComponent();
        }

        // Hendler for Menu/Setups/Tube
        private void tubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open Browser for searching item
            Browser browser = OpenBrowser("TUBE");
            // Open Setup screen
            if (browser.BrowserResult == BrowserResults.New)        // New button was pressed - open empty Setup screen for new item
            {
                TubeSetup tubeSetup = new TubeSetup(this);
                tubeSetup.Show();
            }
            else if(browser.BrowserResult == BrowserResults.OK)     // OK button was pressed - open Setup screen with item which was selected in browser
            {
                TubeSetup tubeSetup = new TubeSetup(this, browser.CodeOfSelectedRow);
                tubeSetup.Show();
            }
        }

        // Method to open Browser
        private Browser OpenBrowser(string tableNameInDB)
        {
            Browser browser = new Browser(tableNameInDB);
            browser.Owner = this;
            browser.ShowDialog();
            return browser;
        }
    }
}
