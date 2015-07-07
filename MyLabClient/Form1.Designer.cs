namespace MyLabClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.buttonTubeSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTubeCode = new System.Windows.Forms.TextBox();
            this.textBoxTubeName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTubeVolume = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tube Setup";
            // 
            // buttonTubeSave
            // 
            this.buttonTubeSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTubeSave.Location = new System.Drawing.Point(144, 133);
            this.buttonTubeSave.Name = "buttonTubeSave";
            this.buttonTubeSave.Size = new System.Drawing.Size(75, 23);
            this.buttonTubeSave.TabIndex = 1;
            this.buttonTubeSave.Text = "Save";
            this.buttonTubeSave.UseVisualStyleBackColor = true;
            this.buttonTubeSave.Click += new System.EventHandler(this.buttonTubeSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Code:";
            // 
            // textBoxTubeCode
            // 
            this.textBoxTubeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxTubeCode.Location = new System.Drawing.Point(74, 46);
            this.textBoxTubeCode.Name = "textBoxTubeCode";
            this.textBoxTubeCode.Size = new System.Drawing.Size(145, 20);
            this.textBoxTubeCode.TabIndex = 3;
            this.textBoxTubeCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTubeCode_KeyPress);
            this.textBoxTubeCode.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxEmpty_Validating);            
            // 
            // textBoxTubeName
            // 
            this.textBoxTubeName.Location = new System.Drawing.Point(74, 72);
            this.textBoxTubeName.Name = "textBoxTubeName";
            this.textBoxTubeName.Size = new System.Drawing.Size(145, 20);
            this.textBoxTubeName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name:";
            // 
            // textBoxTubeVolume
            // 
            this.textBoxTubeVolume.Location = new System.Drawing.Point(74, 98);
            this.textBoxTubeVolume.MaxLength = 3;
            this.textBoxTubeVolume.Name = "textBoxTubeVolume";
            this.textBoxTubeVolume.Size = new System.Drawing.Size(145, 20);
            this.textBoxTubeVolume.TabIndex = 7;
            this.textBoxTubeVolume.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTubeVolume_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Volume:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 172);
            this.Controls.Add(this.textBoxTubeVolume);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxTubeName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxTubeCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonTubeSave);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "MyLab";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTubeSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTubeCode;
        private System.Windows.Forms.TextBox textBoxTubeName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTubeVolume;
        private System.Windows.Forms.Label label4;

    }
}

