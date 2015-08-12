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
    public partial class Browser : Form
    {
        private string tableNameInDB;               // The name of table for browsing 
        private TubeCollectorProxy tubeCollector;   // Object to get access to services
        private BrowserResults browserResult;       // see BrowserResult property

        // Property to show results of brousing
        // Return "none" - Cancel or X button is pressed - nothing to do
        // Return "OK" - Ok button is pressed - open exist item with Code. Code is in selected row in dataGridView1
        // Return "New" - New button is pressed - create new item
        public BrowserResults BrowserResult
        {
            get
            {
                return browserResult;
            }
        }

        // Property CodeOfSelectedRow
        public string CodeOfSelectedRow
        {
            get
            {
                return (string)dataGridView1.SelectedRows[0].Cells[1].Value;
            }
        }

        // Constructor - get the name of table for browsing
        public Browser(string tableNameInDB)
        {
            InitializeComponent();
            this.tableNameInDB = tableNameInDB;
            this.browserResult = BrowserResults.None;     // browserResult by default

            // Settings for dataGridView1
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;

            //  Load all rows from table to dataGridView1
            this.tubeCollector = new TubeCollectorProxy();
            LoadDataInDataGridView("");
        }

        // Handler for Find button - reload rows from DB to DataGridView according to code from textBoxTubeCode
        private void buttonFind_Click(object sender, EventArgs e)
        {
            LoadDataInDataGridView(this.textBoxTubeCode.Text);
        }

        // Method to load rows from DB to DataGridView
        // codeToFind is used for specefy search criteria
        private void LoadDataInDataGridView(string codeToFind)
        {
            codeToFind = string.Concat("%", codeToFind, "%");        // Add % for correct work of sql request with operator Like in GetDataSetForTable method (TubeCollector service)
            DataSet dataSet = tubeCollector.GetDataSetForTable(tableNameInDB, codeToFind);
            this.dataGridView1.DataSource = dataSet;
            this.dataGridView1.DataMember = dataSet.Tables[0].TableName;
        }

        // Handler for Cancel button - just hide browser screen
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // Handler for OK button - we wont ot open exist item with Code. Code is in selected row in dataGridView1
        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.browserResult = BrowserResults.OK;
            this.Hide();
        }

        // Handler for New button - we wont ot create new item
        private void buttonNew_Click(object sender, EventArgs e)
        {
            this.browserResult = BrowserResults.New;
            this.Hide();
        }

        // Handler KeyPress in textBoxTubeCode
        // 1. Forbids to enter Space
        // 2. Load Data In DataGridView when Enter key is pressed
        private void textBoxTubeCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32)
                e.Handled = true;
            else if(e.KeyChar == 13)
                LoadDataInDataGridView(this.textBoxTubeCode.Text);
        }

        // Handler Double Click on DataGridView1 - do the same as press OK button
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.browserResult = BrowserResults.OK;
            this.Hide();
        }
    }
}
