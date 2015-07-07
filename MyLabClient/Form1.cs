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
    public partial class Form1 : Form
    {
        ToolTip toolTip;
        
        // Constructor  
        public Form1()
        {
            InitializeComponent();
            this.buttonTubeSave.Enabled = false;        // Disable buttonTubeSave button befor fill textBoxTubeCode field
            this.toolTip = new ToolTip();
        }

        // Handler - Save Tube button 
        private void buttonTubeSave_Click(object sender, EventArgs e)
        {
            TubeCollectorProxy tubeCollector = new TubeCollectorProxy();
            int tubeVolumeInt;
            tubeCollector.Add(this.textBoxTubeCode.Text, this.textBoxTubeName.Text,
                (int.TryParse(this.textBoxTubeVolume.Text, out tubeVolumeInt) ? tubeVolumeInt : 0));    // set tubeVolume to 0 if no ability to parse string from textBoxTubeVolume to int
            // Prepare form for new input
            this.buttonTubeSave.Enabled = false;
            this.ClearTextBoxes();
        }

        // Handler - textBox Empty
        private void textBoxEmpty_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textBoxTubeCode.Text.Length == 0)    // textBox is empty
            {
                this.textBoxTubeCode.BackColor = Color.Red;
                buttonTubeSave.Enabled = false;                
                this.toolTip.SetToolTip(this.textBoxTubeCode, "Code should be filled");
            }
            else                                     // textBox isn't empty 
            {
                // Remove toolTip
                this.toolTip.RemoveAll();    // Remove toolTip
                // Checks if code is unique
                TextBoxTubeCodeUnique();
            }            
        }

        // Method - textBox Code should be Unique
        private void TextBoxTubeCodeUnique()
        {
            TubeCollectorProxy tubeCollector = new TubeCollectorProxy();
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

        // Method to clear all text boxes
        private void ClearTextBoxes()
        {
            textBoxTubeCode.Clear();
            textBoxTubeName.Clear();
            textBoxTubeVolume.Clear();
        }
    }
}
