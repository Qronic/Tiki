namespace tikiClient
{
    partial class TikiClient
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("NewFiles", System.Windows.Forms.HorizontalAlignment.Left);
            this.lblStatusLabel = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tabControlUI = new System.Windows.Forms.TabControl();
            this.tabFileWatchReport = new System.Windows.Forms.TabPage();
            this.tabAssociationManager = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnArrivalTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCurrentLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnMovedLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControlUI.SuspendLayout();
            this.tabFileWatchReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatusLabel
            // 
            this.lblStatusLabel.AutoSize = true;
            this.lblStatusLabel.Location = new System.Drawing.Point(973, 9);
            this.lblStatusLabel.Name = "lblStatusLabel";
            this.lblStatusLabel.Size = new System.Drawing.Size(40, 13);
            this.lblStatusLabel.TabIndex = 0;
            this.lblStatusLabel.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(1020, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(78, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Not connected";
            // 
            // tabControlUI
            // 
            this.tabControlUI.Controls.Add(this.tabFileWatchReport);
            this.tabControlUI.Controls.Add(this.tabAssociationManager);
            this.tabControlUI.Location = new System.Drawing.Point(12, 22);
            this.tabControlUI.Name = "tabControlUI";
            this.tabControlUI.SelectedIndex = 0;
            this.tabControlUI.Size = new System.Drawing.Size(1101, 520);
            this.tabControlUI.TabIndex = 2;
            // 
            // tabFileWatchReport
            // 
            this.tabFileWatchReport.Controls.Add(this.listView1);
            this.tabFileWatchReport.Location = new System.Drawing.Point(4, 22);
            this.tabFileWatchReport.Name = "tabFileWatchReport";
            this.tabFileWatchReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabFileWatchReport.Size = new System.Drawing.Size(1093, 494);
            this.tabFileWatchReport.TabIndex = 0;
            this.tabFileWatchReport.Text = "FileWatchReport";
            this.tabFileWatchReport.UseVisualStyleBackColor = true;
            // 
            // tabAssociationManager
            // 
            this.tabAssociationManager.Location = new System.Drawing.Point(4, 22);
            this.tabAssociationManager.Name = "tabAssociationManager";
            this.tabAssociationManager.Padding = new System.Windows.Forms.Padding(3);
            this.tabAssociationManager.Size = new System.Drawing.Size(1093, 494);
            this.tabAssociationManager.TabIndex = 1;
            this.tabAssociationManager.Text = "AssociationManager";
            this.tabAssociationManager.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFileName,
            this.columnArrivalTime,
            this.columnCurrentLocation,
            this.columnMovedLocation});
            listViewGroup1.Header = "NewFiles";
            listViewGroup1.Name = "NewFiles";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.listView1.Location = new System.Drawing.Point(6, 21);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1081, 454);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnFileName
            // 
            this.columnFileName.Text = "File Name";
            // 
            // columnArrivalTime
            // 
            this.columnArrivalTime.Text = "Arrival Time";
            this.columnArrivalTime.Width = 98;
            // 
            // columnCurrentLocation
            // 
            this.columnCurrentLocation.Text = "Current Location";
            this.columnCurrentLocation.Width = 138;
            // 
            // columnMovedLocation
            // 
            this.columnMovedLocation.Text = "Moved Location";
            this.columnMovedLocation.Width = 119;
            // 
            // TikiClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 554);
            this.Controls.Add(this.tabControlUI);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblStatusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TikiClient";
            this.Text = "TikiClient";
            this.tabControlUI.ResumeLayout(false);
            this.tabFileWatchReport.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatusLabel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TabControl tabControlUI;
        private System.Windows.Forms.TabPage tabFileWatchReport;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TabPage tabAssociationManager;
        private System.Windows.Forms.ColumnHeader columnFileName;
        private System.Windows.Forms.ColumnHeader columnArrivalTime;
        private System.Windows.Forms.ColumnHeader columnCurrentLocation;
        private System.Windows.Forms.ColumnHeader columnMovedLocation;
    }
}