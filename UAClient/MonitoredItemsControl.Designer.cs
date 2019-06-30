namespace Siemens.OpcUA.Client
{
    partial class MonitoredItemsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Accessor methods for private members
        // ListView
        public System.Windows.Forms.ListView MonitoredItemsList
        {
            get { return MonitoredItemsLV; }
        }
        #endregion        
        
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MonitoredItemsLV = new System.Windows.Forms.ListView();
            this.NodeIdCH = new System.Windows.Forms.ColumnHeader();
            this.SamplingIntervalCH = new System.Windows.Forms.ColumnHeader();
            this.ValueCH = new System.Windows.Forms.ColumnHeader();
            this.QualityCH = new System.Windows.Forms.ColumnHeader();
            this.TimestampCH = new System.Windows.Forms.ColumnHeader();
            this.LastOperationStatusCH = new System.Windows.Forms.ColumnHeader();
            this.MonitoringMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_SamplingInterval = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SamplingInterval_100 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SamplingInterval_500 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SamplingInterval_1000 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_WriteValues = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RemoveItems = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_PublishingInterval = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_PublishingInterval_200 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_PublishingInterval_1000 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_PublishingInterval_2000 = new System.Windows.Forms.ToolStripMenuItem();
            this.MonitoringMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MonitoredItemsLV
            // 
            this.MonitoredItemsLV.AllowDrop = true;
            this.MonitoredItemsLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NodeIdCH,
            this.SamplingIntervalCH,
            this.ValueCH,
            this.QualityCH,
            this.TimestampCH,
            this.LastOperationStatusCH});
            this.MonitoredItemsLV.ContextMenuStrip = this.MonitoringMenu;
            this.MonitoredItemsLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonitoredItemsLV.LabelWrap = false;
            this.MonitoredItemsLV.Location = new System.Drawing.Point(0, 0);
            this.MonitoredItemsLV.Name = "MonitoredItemsLV";
            this.MonitoredItemsLV.Size = new System.Drawing.Size(350, 150);
            this.MonitoredItemsLV.TabIndex = 0;
            this.MonitoredItemsLV.UseCompatibleStateImageBehavior = false;
            this.MonitoredItemsLV.View = System.Windows.Forms.View.Details;
            this.MonitoredItemsLV.DragDrop += new System.Windows.Forms.DragEventHandler(this.MonitoredItems_DragDrop);
            this.MonitoredItemsLV.DragOver += new System.Windows.Forms.DragEventHandler(this.MonitoredItems_DragOver);
            // 
            // NodeIdCH
            // 
            this.NodeIdCH.Text = "NodeId";
            // 
            // SamplingIntervalCH
            // 
            this.SamplingIntervalCH.Text = "Sampling";
            // 
            // ValueCH
            // 
            this.ValueCH.Text = "Value";
            // 
            // QualityCH
            // 
            this.QualityCH.Text = "Quality";
            // 
            // TimestampCH
            // 
            this.TimestampCH.Text = "Timestamp";
            // 
            // LastOperationStatusCH
            // 
            this.LastOperationStatusCH.Text = "Last Error";
            // 
            // MonitoringMenu
            // 
            this.MonitoringMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_SamplingInterval,
            this.toolStripMenuItem_WriteValues,
            this.toolStripMenuItem_RemoveItems,
            this.toolStripMenuItem_PublishingInterval});
            this.MonitoringMenu.Name = "MonitoringMenu";
            this.MonitoringMenu.Size = new System.Drawing.Size(174, 92);
            // 
            // toolStripMenuItem_SamplingInterval
            // 
            this.toolStripMenuItem_SamplingInterval.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_SamplingInterval_100,
            this.toolStripMenuItem_SamplingInterval_500,
            this.toolStripMenuItem_SamplingInterval_1000});
            this.toolStripMenuItem_SamplingInterval.Name = "toolStripMenuItem_SamplingInterval";
            this.toolStripMenuItem_SamplingInterval.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem_SamplingInterval.Text = "Sampling Interval";
            // 
            // toolStripMenuItem_SamplingInterval_100
            // 
            this.toolStripMenuItem_SamplingInterval_100.Name = "toolStripMenuItem_SamplingInterval_100";
            this.toolStripMenuItem_SamplingInterval_100.Size = new System.Drawing.Size(109, 22);
            this.toolStripMenuItem_SamplingInterval_100.Text = "100";
            this.toolStripMenuItem_SamplingInterval_100.Click += new System.EventHandler(this.MonitoringMenu_SamplingInterval_Click);
            // 
            // toolStripMenuItem_SamplingInterval_500
            // 
            this.toolStripMenuItem_SamplingInterval_500.Name = "toolStripMenuItem_SamplingInterval_500";
            this.toolStripMenuItem_SamplingInterval_500.Size = new System.Drawing.Size(109, 22);
            this.toolStripMenuItem_SamplingInterval_500.Text = "500";
            this.toolStripMenuItem_SamplingInterval_500.Click += new System.EventHandler(this.MonitoringMenu_SamplingInterval_Click);
            // 
            // toolStripMenuItem_SamplingInterval_1000
            // 
            this.toolStripMenuItem_SamplingInterval_1000.Name = "toolStripMenuItem_SamplingInterval_1000";
            this.toolStripMenuItem_SamplingInterval_1000.Size = new System.Drawing.Size(109, 22);
            this.toolStripMenuItem_SamplingInterval_1000.Text = "1000";
            this.toolStripMenuItem_SamplingInterval_1000.Click += new System.EventHandler(this.MonitoringMenu_SamplingInterval_Click);
            // 
            // toolStripMenuItem_WriteValues
            // 
            this.toolStripMenuItem_WriteValues.Name = "toolStripMenuItem_WriteValues";
            this.toolStripMenuItem_WriteValues.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem_WriteValues.Text = "Write Value(s)";
            this.toolStripMenuItem_WriteValues.Click += new System.EventHandler(this.MonitoringMenu_WriteValues_Click);
            // 
            // toolStripMenuItem_RemoveItems
            // 
            this.toolStripMenuItem_RemoveItems.Name = "toolStripMenuItem_RemoveItems";
            this.toolStripMenuItem_RemoveItems.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem_RemoveItems.Text = "Remove Item(s)";
            this.toolStripMenuItem_RemoveItems.Click += new System.EventHandler(this.MonitoringMenu_RemoveItems_Click);
            // 
            // toolStripMenuItem_PublishingInterval
            // 
            this.toolStripMenuItem_PublishingInterval.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_PublishingInterval_200,
            this.toolStripMenuItem_PublishingInterval_1000,
            this.toolStripMenuItem_PublishingInterval_2000});
            this.toolStripMenuItem_PublishingInterval.Name = "toolStripMenuItem_PublishingInterval";
            this.toolStripMenuItem_PublishingInterval.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem_PublishingInterval.Text = "Publishing Interval";
            this.toolStripMenuItem_PublishingInterval.Click += new System.EventHandler(this.MonitoringMenu_PublishingInterval_Click);
            // 
            // toolStripMenuItem_PublishingInterval_200
            // 
            this.toolStripMenuItem_PublishingInterval_200.Name = "toolStripMenuItem_PublishingInterval_200";
            this.toolStripMenuItem_PublishingInterval_200.Size = new System.Drawing.Size(109, 22);
            this.toolStripMenuItem_PublishingInterval_200.Text = "200";
            this.toolStripMenuItem_PublishingInterval_200.Click += new System.EventHandler(this.MonitoringMenu_PublishingInterval_Click);
            // 
            // toolStripMenuItem_PublishingInterval_1000
            // 
            this.toolStripMenuItem_PublishingInterval_1000.Name = "toolStripMenuItem_PublishingInterval_1000";
            this.toolStripMenuItem_PublishingInterval_1000.Size = new System.Drawing.Size(109, 22);
            this.toolStripMenuItem_PublishingInterval_1000.Text = "1000";
            this.toolStripMenuItem_PublishingInterval_1000.Click += new System.EventHandler(this.MonitoringMenu_PublishingInterval_Click);
            // 
            // toolStripMenuItem_PublishingInterval_2000
            // 
            this.toolStripMenuItem_PublishingInterval_2000.Name = "toolStripMenuItem_PublishingInterval_2000";
            this.toolStripMenuItem_PublishingInterval_2000.Size = new System.Drawing.Size(109, 22);
            this.toolStripMenuItem_PublishingInterval_2000.Text = "2000";
            this.toolStripMenuItem_PublishingInterval_2000.Click += new System.EventHandler(this.MonitoringMenu_PublishingInterval_Click);
            // 
            // MonitoredItemsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MonitoredItemsLV);
            this.Name = "MonitoredItemsControl";
            this.Size = new System.Drawing.Size(350, 150);
            this.MonitoringMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView MonitoredItemsLV;
        private System.Windows.Forms.ContextMenuStrip MonitoringMenu;
        private System.Windows.Forms.ColumnHeader NodeIdCH;
        private System.Windows.Forms.ColumnHeader SamplingIntervalCH;
        private System.Windows.Forms.ColumnHeader ValueCH;
        private System.Windows.Forms.ColumnHeader QualityCH;
        private System.Windows.Forms.ColumnHeader TimestampCH;
        private System.Windows.Forms.ColumnHeader LastOperationStatusCH;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SamplingInterval;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RemoveItems;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_PublishingInterval;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_WriteValues;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SamplingInterval_100;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SamplingInterval_500;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SamplingInterval_1000;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_PublishingInterval_200;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_PublishingInterval_1000;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_PublishingInterval_2000;

    }
}
