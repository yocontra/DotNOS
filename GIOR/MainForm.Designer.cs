namespace GIOR
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FileSelectButton = new System.Windows.Forms.Button();
            this.asmlabel = new System.Windows.Forms.Label();
            this.fileSelectTextBox = new System.Windows.Forms.TextBox();
            this.HeavyWorker = new System.ComponentModel.BackgroundWorker();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FileSelectButton
            // 
            this.FileSelectButton.Location = new System.Drawing.Point(226, 8);
            this.FileSelectButton.Name = "FileSelectButton";
            this.FileSelectButton.Size = new System.Drawing.Size(75, 23);
            this.FileSelectButton.TabIndex = 0;
            this.FileSelectButton.Text = "Select File...";
            this.FileSelectButton.UseVisualStyleBackColor = true;
            this.FileSelectButton.Click += new System.EventHandler(this.FileSelectButton_Click);
            // 
            // asmlabel
            // 
            this.asmlabel.AutoSize = true;
            this.asmlabel.Location = new System.Drawing.Point(12, 13);
            this.asmlabel.Name = "asmlabel";
            this.asmlabel.Size = new System.Drawing.Size(54, 13);
            this.asmlabel.TabIndex = 1;
            this.asmlabel.Text = "Assembly:";
            // 
            // fileSelectTextBox
            // 
            this.fileSelectTextBox.Location = new System.Drawing.Point(72, 10);
            this.fileSelectTextBox.Name = "fileSelectTextBox";
            this.fileSelectTextBox.ReadOnly = true;
            this.fileSelectTextBox.Size = new System.Drawing.Size(148, 20);
            this.fileSelectTextBox.TabIndex = 2;
            // 
            // HeavyWorker
            // 
            this.HeavyWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(HeavyWorker_RunWorkerCompleted);
            this.HeavyWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.HeavyWorker_DoWork);
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(15, 36);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTextBox.Size = new System.Drawing.Size(286, 214);
            this.logTextBox.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 262);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.fileSelectTextBox);
            this.Controls.Add(this.asmlabel);
            this.Controls.Add(this.FileSelectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "GIOR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FileSelectButton;
        private System.Windows.Forms.Label asmlabel;
        private System.Windows.Forms.TextBox fileSelectTextBox;
        private System.ComponentModel.BackgroundWorker HeavyWorker;
        private System.Windows.Forms.TextBox logTextBox;
    }
}

