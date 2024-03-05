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
            this.components = new System.ComponentModel.Container();
            this.recordsListView = new System.Windows.Forms.ListView();
            this.championColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.killsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deathsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.assistsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.creepScoreColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.visionScoreColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.matchLenghtColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.winColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.roleColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.championImageList = new System.Windows.Forms.ImageList(this.components);
            this.newMatchButton = new System.Windows.Forms.Button();
            this.removeRecordButton = new System.Windows.Forms.Button();
            this.editRecordButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.statisticsSelectedMatchButton = new System.Windows.Forms.Button();
            this.statisticsAllButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // recordsListView
            // 
            this.recordsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.championColumnHeader,
            this.dateColumnHeader,
            this.killsColumnHeader,
            this.deathsColumnHeader,
            this.assistsColumnHeader,
            this.creepScoreColumnHeader,
            this.visionScoreColumnHeader,
            this.matchLenghtColumnHeader,
            this.winColumnHeader,
            this.roleColumnHeader});
            this.recordsListView.Dock = System.Windows.Forms.DockStyle.Left;
            this.recordsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recordsListView.FullRowSelect = true;
            this.recordsListView.HideSelection = false;
            this.recordsListView.Location = new System.Drawing.Point(0, 0);
            this.recordsListView.MultiSelect = false;
            this.recordsListView.Name = "recordsListView";
            this.recordsListView.Size = new System.Drawing.Size(911, 661);
            this.recordsListView.TabIndex = 0;
            this.recordsListView.TileSize = new System.Drawing.Size(600, 50);
            this.recordsListView.UseCompatibleStateImageBehavior = false;
            this.recordsListView.View = System.Windows.Forms.View.Details;
            // 
            // championColumnHeader
            // 
            this.championColumnHeader.Text = "Champion";
            this.championColumnHeader.Width = 109;
            // 
            // dateColumnHeader
            // 
            this.dateColumnHeader.Text = "Date";
            this.dateColumnHeader.Width = 57;
            // 
            // killsColumnHeader
            // 
            this.killsColumnHeader.Text = "Kills";
            this.killsColumnHeader.Width = 52;
            // 
            // deathsColumnHeader
            // 
            this.deathsColumnHeader.Text = "Deaths";
            this.deathsColumnHeader.Width = 80;
            // 
            // assistsColumnHeader
            // 
            this.assistsColumnHeader.Text = "Assists";
            this.assistsColumnHeader.Width = 81;
            // 
            // creepScoreColumnHeader
            // 
            this.creepScoreColumnHeader.Text = "CS";
            this.creepScoreColumnHeader.Width = 41;
            // 
            // visionScoreColumnHeader
            // 
            this.visionScoreColumnHeader.Text = "Vision Score";
            this.visionScoreColumnHeader.Width = 133;
            // 
            // matchLenghtColumnHeader
            // 
            this.matchLenghtColumnHeader.Text = "Lenght";
            this.matchLenghtColumnHeader.Width = 78;
            // 
            // winColumnHeader
            // 
            this.winColumnHeader.Text = "Win";
            this.winColumnHeader.Width = 49;
            // 
            // roleColumnHeader
            // 
            this.roleColumnHeader.Text = "Role";
            this.roleColumnHeader.Width = 227;
            // 
            // championImageList
            // 
            this.championImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.championImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.championImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // newMatchButton
            // 
            this.newMatchButton.Location = new System.Drawing.Point(6, 19);
            this.newMatchButton.Name = "newMatchButton";
            this.newMatchButton.Size = new System.Drawing.Size(108, 23);
            this.newMatchButton.TabIndex = 1;
            this.newMatchButton.Text = "New match";
            this.newMatchButton.UseVisualStyleBackColor = true;
            this.newMatchButton.Click += new System.EventHandler(this.newMatchButton_Click);
            // 
            // removeRecordButton
            // 
            this.removeRecordButton.Location = new System.Drawing.Point(6, 48);
            this.removeRecordButton.Name = "removeRecordButton";
            this.removeRecordButton.Size = new System.Drawing.Size(108, 23);
            this.removeRecordButton.TabIndex = 2;
            this.removeRecordButton.Text = "Remove";
            this.removeRecordButton.UseVisualStyleBackColor = true;
            this.removeRecordButton.Click += new System.EventHandler(this.removeRecordButton_Click);
            // 
            // editRecordButton
            // 
            this.editRecordButton.Location = new System.Drawing.Point(6, 77);
            this.editRecordButton.Name = "editRecordButton";
            this.editRecordButton.Size = new System.Drawing.Size(108, 23);
            this.editRecordButton.TabIndex = 3;
            this.editRecordButton.Text = "Edit";
            this.editRecordButton.UseVisualStyleBackColor = true;
            this.editRecordButton.Click += new System.EventHandler(this.editRecordButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.statisticsAllButton);
            this.groupBox1.Controls.Add(this.statisticsSelectedMatchButton);
            this.groupBox1.Controls.Add(this.refreshButton);
            this.groupBox1.Controls.Add(this.newMatchButton);
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
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(6, 106);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(108, 23);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // statisticsSelectedMatchButton
            // 
            this.statisticsSelectedMatchButton.Location = new System.Drawing.Point(6, 135);
            this.statisticsSelectedMatchButton.Name = "statisticsSelectedMatchButton";
            this.statisticsSelectedMatchButton.Size = new System.Drawing.Size(108, 23);
            this.statisticsSelectedMatchButton.TabIndex = 5;
            this.statisticsSelectedMatchButton.Text = "Statistics (selected)";
            this.statisticsSelectedMatchButton.UseVisualStyleBackColor = true;
            this.statisticsSelectedMatchButton.Click += new System.EventHandler(this.statisticsSelectedMatchButton_Click);
            // 
            // statisticsAllButton
            // 
            this.statisticsAllButton.Location = new System.Drawing.Point(6, 164);
            this.statisticsAllButton.Name = "statisticsAllButton";
            this.statisticsAllButton.Size = new System.Drawing.Size(108, 23);
            this.statisticsAllButton.TabIndex = 6;
            this.statisticsAllButton.Text = "Statistics (all)";
            this.statisticsAllButton.UseVisualStyleBackColor = true;
            this.statisticsAllButton.Click += new System.EventHandler(this.statisticsAllButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.recordsListView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView recordsListView;
        private System.Windows.Forms.Button newMatchButton;
        private System.Windows.Forms.Button removeRecordButton;
        private System.Windows.Forms.Button editRecordButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ImageList championImageList;
        private System.Windows.Forms.ColumnHeader championColumnHeader;
        private System.Windows.Forms.ColumnHeader dateColumnHeader;
        private System.Windows.Forms.ColumnHeader killsColumnHeader;
        private System.Windows.Forms.ColumnHeader deathsColumnHeader;
        private System.Windows.Forms.ColumnHeader assistsColumnHeader;
        private System.Windows.Forms.ColumnHeader creepScoreColumnHeader;
        private System.Windows.Forms.ColumnHeader visionScoreColumnHeader;
        private System.Windows.Forms.ColumnHeader matchLenghtColumnHeader;
        private System.Windows.Forms.ColumnHeader winColumnHeader;
        private System.Windows.Forms.ColumnHeader roleColumnHeader;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button statisticsAllButton;
        private System.Windows.Forms.Button statisticsSelectedMatchButton;
    }
}

