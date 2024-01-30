namespace Diplomska
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.addRecordButton = new System.Windows.Forms.Button();
            this.removeRecordButton = new System.Windows.Forms.Button();
            this.editRecordButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(923, 661);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // addRecordButton
            // 
            this.addRecordButton.Location = new System.Drawing.Point(6, 19);
            this.addRecordButton.Name = "addRecordButton";
            this.addRecordButton.Size = new System.Drawing.Size(75, 23);
            this.addRecordButton.TabIndex = 1;
            this.addRecordButton.Text = "Add";
            this.addRecordButton.UseVisualStyleBackColor = true;
            // 
            // removeRecordButton
            // 
            this.removeRecordButton.Location = new System.Drawing.Point(6, 48);
            this.removeRecordButton.Name = "removeRecordButton";
            this.removeRecordButton.Size = new System.Drawing.Size(75, 23);
            this.removeRecordButton.TabIndex = 2;
            this.removeRecordButton.Text = "Remove";
            this.removeRecordButton.UseVisualStyleBackColor = true;
            // 
            // editRecordButton
            // 
            this.editRecordButton.Location = new System.Drawing.Point(6, 77);
            this.editRecordButton.Name = "editRecordButton";
            this.editRecordButton.Size = new System.Drawing.Size(75, 23);
            this.editRecordButton.TabIndex = 3;
            this.editRecordButton.Text = "Edit";
            this.editRecordButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addRecordButton);
            this.groupBox1.Controls.Add(this.editRecordButton);
            this.groupBox1.Controls.Add(this.removeRecordButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(929, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 661);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button addRecordButton;
        private System.Windows.Forms.Button removeRecordButton;
        private System.Windows.Forms.Button editRecordButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

