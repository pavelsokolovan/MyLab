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
    public partial class TubeSetup : Form
    {
        private ToolTip toolTip;
        private TubeCollectorProxy tubeCollector;
        private string tableNameInDB = "TUBE";      // The name of table in DB

        // Constructor 1 - empty Setup screen for new item
        public TubeSetup(MyLabClient.MainScreen parent)
        {
            InitializeComponent();
            this.MdiParent = parent;
            this.buttonTubeSave.Enabled = false;        // Disable buttonTubeSave button befor fill textBoxTubeCode field
            this.buttonTubeEdit.Enabled = false;        // Disable buttonTubeEdit button befor new Item will be saved
            this.buttonTubeNew.Enabled = false;         // Disable buttonTubeNew button befor new Item will be saved
            this.textBoxTubeCode.Tag = true;            // Save button haven't been pressed yet. When pressed = false
            this.toolTip = new ToolTip();
            this.tubeCollector = new TubeCollectorProxy();
        }

        // Constructor 2 - Setup screen with item which was selected in browser
        public TubeSetup(MyLabClient.MainScreen parent, string codeOfSelectedRow): this(parent)
        {
            // Get DataSet with proper row accordint to Code
            DataSet dataSet = tubeCollector.GetDataSetForTable(tableNameInDB, codeOfSelectedRow);
            DataRow dataRow = dataSet.Tables[tableNameInDB].Rows[0];
            // Fill textBoxes with data from dataRow
            this.textBoxTubeCode.Text = (string)dataRow["TUBE_CODE"];
            this.textBoxTubeName.Text = (string)dataRow["TUBE_NAME"];
            this.textBoxTubeVolume.Text = dataRow["TUBE_VOLUME"].ToString();
            // Move to edit mode
            MoveToEditMode();
        }

        // Handler - New button 
        private void buttonTubeNew_Click(object sender, EventArgs e)
        {
            // Disable New and Edit buttons
            this.buttonTubeNew.Enabled = false;
            this.buttonTubeEdit.Enabled = false;  
            // Clear all fields
            this.textBoxTubeCode.Clear();
            this.textBoxTubeName.Clear();
            this.textBoxTubeVolume.Clear();  
            // Enable all fields
            this.textBoxTubeCode.Enabled = true;
            this.textBoxTubeName.Enabled = true;
            this.textBoxTubeVolume.Enabled = true;
            // Set focus to textBoxTubeCode
            this.textBoxTubeCode.Focus();
        }

        // Handler - Save button 
        private void buttonTubeSave_Click(object sender, EventArgs e)
        {
            int tubeVolumeInt;
            // Add new row to DB
            bool isNewRowAdded = tubeCollector.Add(this.textBoxTubeCode.Text, this.textBoxTubeName.Text,    // return true if row was added. Return false if row already exists in DB
                (int.TryParse(this.textBoxTubeVolume.Text, out tubeVolumeInt) ? tubeVolumeInt : 0));        // set tubeVolume to 0 if no ability to parse string from textBoxTubeVolume to int
            // Update row if it is exist in DB
            if (!isNewRowAdded)
                tubeCollector.Update(this.textBoxTubeCode.Text, this.textBoxTubeName.Text,
                    (int.TryParse(this.textBoxTubeVolume.Text, out tubeVolumeInt) ? tubeVolumeInt : 0));        // set tubeVolume to 0 if no ability to parse string from textBoxTubeVolume to int
            // 
            this.buttonTubeSave.Enabled = false;
            this.buttonTubeNew.Enabled = true;            
            this.buttonTubeEdit.Enabled = true;
            this.textBoxTubeCode.Tag = false;   // to avoid validation of textBoxTubeCode
            this.textBoxTubeCode.Enabled = false;
            this.textBoxTubeCode.Tag = true;    // to avoid validation of textBoxTubeCode - return to normal
            this.textBoxTubeName.Enabled = false;
            this.textBoxTubeVolume.Enabled = false;
        }

        // Handler - Edit button 
        private void buttonTubeEdit_Click(object sender, EventArgs e)
        {
            MoveToEditMode();
        }

        // Handler - textBoxCode field Empty
        // if yes - paint textBoxCode field to red disable save button and turn on toolTip
        // if no - Remove toolTip and Checks if code in textBoxCode field is unique
        private void textBoxEmpty_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textBoxTubeCode.Text.Length == 0)    // textBox is empty
            {
                this.textBoxTubeCode.BackColor = Color.Red;
                buttonTubeSave.Enabled = false;                
                this.toolTip.SetToolTip(this.textBoxTubeCode, "Code should be filled");
            }
            else if((bool)textBoxTubeCode.Tag)                                    // textBox isn't empty 
            {
                // Remove toolTip
                this.toolTip.RemoveAll();    // Remove toolTip
                // Checks if code in textBoxCode field is unique
                TextBoxTubeCodeUnique();
            }            
        }

        // Method - textBox Code should be Unique
        private void TextBoxTubeCodeUnique()
        {
            if (tubeCollector.Contains(this.textBoxTubeCode.Text))       // Code is presented in DB
            {
                this.textBoxTubeCode.BackColor = Color.Red;
                buttonTubeSave.Enabled = false;                
                this.toolTip.SetToolTip(this.textBoxTubeCode, "Code should be unique");
            }
            else                // Code isn't presented in DB 
            {
                this.toolTip.RemoveAll();        // Remove toolTip
                this.textBoxTubeCode.BackColor = System.Drawing.SystemColors.Window;
                buttonTubeSave.Enabled = true;
            }
        }        

        // Handler - forbids to enter Space in textBoxTubeCode field 
        private void textBoxTubeCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32)
                e.Handled = true;
        }

        // Handler - allows to enter digits only in textBoxTubeVolume field 
        private void textBoxTubeVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Delete entered symbol if it is not a digit or not a BackSpace
            if((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;   // Delete symbol 
        }

        // Handler - Enable Save button if some changes are done in textBoxes (not for textBoxTubeCode)
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (textBoxTubeCode.Enabled == false && this.buttonTubeSave.Enabled == false)
            {
                this.buttonTubeSave.Enabled = true;
            }
        }            

        // Method to move to edit mode
        private void MoveToEditMode()
        {
            // Disable New, Save and Edit buttons
            this.buttonTubeNew.Enabled = false;
            this.buttonTubeSave.Enabled = false;
            this.buttonTubeEdit.Enabled = false;
            // Disable Code field
            this.textBoxTubeCode.Enabled = false;
            // Enable Name and Volume fields
            this.textBoxTubeName.Enabled = true;
            this.textBoxTubeVolume.Enabled = true;
            // Set focus to textBoxTubeName
            this.textBoxTubeName.Focus();
        }
    }
}
