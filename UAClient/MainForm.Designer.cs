namespace Siemens.OpcUA.Client
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
            Siemens.OpcUA.Server server1 = new Siemens.OpcUA.Server();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NodeLBL = new System.Windows.Forms.Label();
            this.NodeTB = new System.Windows.Forms.TextBox();
            this.UrlCB = new System.Windows.Forms.ComboBox();
            this.EndpointsLBL = new System.Windows.Forms.Label();
            this.ConnectDisconnectBTN = new System.Windows.Forms.Button();
            this.MenubarMS = new System.Windows.Forms.MenuStrip();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subscriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_SamplingInterval = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SamplingInterval_100 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SamplingInterval_500 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SamplingInterval_1000 = new System.Windows.Forms.ToolStripMenuItem();
            this.writeValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publishingIntervalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_PublishingInterval_200 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_PublishingInterval_1000 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_PublishingInterval_2000 = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusLabelSTS = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.browseControl = new Siemens.OpcUA.Client.BrowseControl();
            this.attributeListControl = new Siemens.OpcUA.Client.AttributeListControl();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.monitoredItemsControl = new Siemens.OpcUA.Client.MonitoredItemsControl();
            this.panel1.SuspendLayout();
            this.MenubarMS.SuspendLayout();
            this.StatusLabelSTS.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.NodeLBL);
            this.panel1.Controls.Add(this.NodeTB);
            this.panel1.Controls.Add(this.UrlCB);
            this.panel1.Controls.Add(this.EndpointsLBL);
            this.panel1.Controls.Add(this.ConnectDisconnectBTN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(827, 30);
            this.panel1.TabIndex = 0;
            // 
            // NodeLBL
            // 
            this.NodeLBL.AutoSize = true;
            this.NodeLBL.Location = new System.Drawing.Point(13, 8);
            this.NodeLBL.Name = "NodeLBL";
            this.NodeLBL.Size = new System.Drawing.Size(36, 13);
            this.NodeLBL.TabIndex = 7;
            this.NodeLBL.Text = "Node:";
            // 
            // NodeTB
            // 
            this.NodeTB.Location = new System.Drawing.Point(50, 4);
            this.NodeTB.Name = "NodeTB";
            this.NodeTB.Size = new System.Drawing.Size(90, 20);
            this.NodeTB.TabIndex = 6;
            // 
            // UrlCB
            // 
            this.UrlCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.UrlCB.FormattingEnabled = true;
            this.UrlCB.Location = new System.Drawing.Point(211, 4);
            this.UrlCB.Name = "UrlCB";
            this.UrlCB.Size = new System.Drawing.Size(528, 21);
            this.UrlCB.TabIndex = 3;
            this.UrlCB.DropDown += new System.EventHandler(this.UrlCB_DropDown);
            // 
            // EndpointsLBL
            // 
            this.EndpointsLBL.AutoSize = true;
            this.EndpointsLBL.Location = new System.Drawing.Point(151, 8);
            this.EndpointsLBL.Name = "EndpointsLBL";
            this.EndpointsLBL.Size = new System.Drawing.Size(57, 13);
            this.EndpointsLBL.TabIndex = 2;
            this.EndpointsLBL.Text = "Endpoints:";
            // 
            // ConnectDisconnectBTN
            // 
            this.ConnectDisconnectBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectDisconnectBTN.Location = new System.Drawing.Point(745, 4);
            this.ConnectDisconnectBTN.Name = "ConnectDisconnectBTN";
            this.ConnectDisconnectBTN.Size = new System.Drawing.Size(74, 23);
            this.ConnectDisconnectBTN.TabIndex = 0;
            this.ConnectDisconnectBTN.Text = "Connect";
            this.ConnectDisconnectBTN.UseVisualStyleBackColor = true;
            this.ConnectDisconnectBTN.Click += new System.EventHandler(this.btnConnectDisconnect_Click);
            // 
            // MenubarMS
            // 
            this.MenubarMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem,
            this.subscriptionToolStripMenuItem});
            this.MenubarMS.Location = new System.Drawing.Point(0, 0);
            this.MenubarMS.Name = "MenubarMS";
            this.MenubarMS.Size = new System.Drawing.Size(827, 24);
            this.MenubarMS.TabIndex = 2;
            this.MenubarMS.Text = "MenuBar";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.serverToolStripMenuItem.Text = "Server";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // subscriptionToolStripMenuItem
            // 
            this.subscriptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_SamplingInterval,
            this.writeValuesToolStripMenuItem,
            this.removeItemsToolStripMenuItem,
            this.publishingIntervalToolStripMenuItem});
            this.subscriptionToolStripMenuItem.Name = "subscriptionToolStripMenuItem";
            this.subscriptionToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.subscriptionToolStripMenuItem.Text = "Subscription";
            // 
            // ToolStripMenuItem_SamplingInterval
            // 
            this.ToolStripMenuItem_SamplingInterval.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_SamplingInterval_100,
            this.toolStripMenuItem_SamplingInterval_500,
            this.toolStripMenuItem_SamplingInterval_1000});
            this.ToolStripMenuItem_SamplingInterval.Name = "ToolStripMenuItem_SamplingInterval";
            this.ToolStripMenuItem_SamplingInterval.Size = new System.Drawing.Size(173, 22);
            this.ToolStripMenuItem_SamplingInterval.Text = "Sampling Interval";
            // 
            // toolStripMenuItem_SamplingInterval_100
            // 
            this.toolStripMenuItem_SamplingInterval_100.Name = "toolStripMenuItem_SamplingInterval_100";
            this.toolStripMenuItem_SamplingInterval_100.Size = new System.Drawing.Size(109, 22);
            this.toolStripMenuItem_SamplingInterval_100.Text = "100";
            this.toolStripMenuItem_SamplingInterval_100.Click += new System.EventHandler(this.SamplingInterval_Click);
            // 
            // toolStripMenuItem_SamplingInterval_500
            // 
            this.toolStripMenuItem_SamplingInterval_500.Name = "toolStripMenuItem_SamplingInterval_500";
            this.toolStripMenuItem_SamplingInterval_500.Size = new System.Drawing.Size(109, 22);
            this.toolStripMenuItem_SamplingInterval_500.Text = "500";
            this.toolStripMenuItem_SamplingInterval_500.Click += new System.EventHandler(this.SamplingInterval_Click);
            // 
            // toolStripMenuItem_SamplingInterval_1000
            // 
            this.toolStripMenuItem_SamplingInterval_1000.Name = "toolStripMenuItem_SamplingInterval_1000";
            this.toolStripMenuItem_SamplingInterval_1000.Size = new System.Drawing.Size(109, 22);
            this.toolStripMenuItem_SamplingInterval_1000.Text = "1000";
            this.toolStripMenuItem_SamplingInterval_1000.Click += new System.EventHandler(this.SamplingInterval_Click);
            // 
            // writeValuesToolStripMenuItem
            // 
            this.writeValuesToolStripMenuItem.Name = "writeValuesToolStripMenuItem";
            this.writeValuesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.writeValuesToolStripMenuItem.Text = "Write Value(s)";
            this.writeValuesToolStripMenuItem.Click += new System.EventHandler(this.WriteValues_Click);
            // 
            // removeItemsToolStripMenuItem
            // 
            this.removeItemsToolStripMenuItem.Name = "removeItemsToolStripMenuItem";
            this.removeItemsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.removeItemsToolStripMenuItem.Text = "Remove Item(s)";
            this.removeItemsToolStripMenuItem.Click += new System.EventHandler(this.RemoveItems_Click);
            // 
            // publishingIntervalToolStripMenuItem
            // 
            this.publishingIntervalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_PublishingInterval_200,
            this.toolStripMenuItem_PublishingInterval_1000,
            this.toolStripMenuItem_PublishingInterval_2000});
            this.publishingIntervalToolStripMenuItem.Name = "publishingIntervalToolStripMenuItem";
            this.publishingIntervalToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.publishingIntervalToolStripMenuItem.Text = "Publishing Interval";
            // 
            // toolStripMenuItem_PublishingInterval_200
            // 
            this.toolStripMenuItem_PublishingInterval_200.Name = "toolStripMenuItem_PublishingInterval_200";
            this.toolStripMenuItem_PublishingInterval_200.Size = new System.Drawing.Size(109, 22);
            this.toolStripMenuItem_PublishingInterval_200.Text = "200";
            this.toolStripMenuItem_PublishingInterval_200.Click += new System.EventHandler(this.PublishingInterval_Click);
            // 
            // toolStripMenuItem_PublishingInterval_1000
            // 
            this.toolStripMenuItem_PublishingInterval_1000.Name = "toolStripMenuItem_PublishingInterval_1000";
            this.toolStripMenuItem_PublishingInterval_1000.Size = new System.Drawing.Size(109, 22);
            this.toolStripMenuItem_PublishingInterval_1000.Text = "1000";
            this.toolStripMenuItem_PublishingInterval_1000.Click += new System.EventHandler(this.PublishingInterval_Click);
            // 
            // toolStripMenuItem_PublishingInterval_2000
            // 
            this.toolStripMenuItem_PublishingInterval_2000.Name = "toolStripMenuItem_PublishingInterval_2000";
            this.toolStripMenuItem_PublishingInterval_2000.Size = new System.Drawing.Size(109, 22);
            this.toolStripMenuItem_PublishingInterval_2000.Text = "2000";
            this.toolStripMenuItem_PublishingInterval_2000.Click += new System.EventHandler(this.PublishingInterval_Click);
            // 
            // StatusLabelSTS
            // 
            this.StatusLabelSTS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.StatusLabelSTS.Location = new System.Drawing.Point(0, 552);
            this.StatusLabelSTS.Name = "StatusLabelSTS";
            this.StatusLabelSTS.Size = new System.Drawing.Size(827, 22);
            this.StatusLabelSTS.TabIndex = 3;
            this.StatusLabelSTS.Text = "StatusLabelSTS";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Image = global::Siemens.OpcUA.Client.Properties.Resources.success;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(155, 17);
            this.toolStripStatusLabel.Text = "enter URL and click connect";
            this.toolStripStatusLabel.ToolTipText = "status informationb";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.browseControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.attributeListControl);
            this.splitContainer1.Size = new System.Drawing.Size(827, 248);
            this.splitContainer1.SplitterDistance = 318;
            this.splitContainer1.TabIndex = 5;
            // 
            // browseControl
            // 
            this.browseControl.AutoSize = true;
            this.browseControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browseControl.Location = new System.Drawing.Point(0, 0);
            this.browseControl.Name = "browseControl";
            this.browseControl.RebrowseOnNodeExpande = false;
            this.browseControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.browseControl.Server = null;
            this.browseControl.Size = new System.Drawing.Size(318, 248);
            this.browseControl.TabIndex = 0;
            // 
            // attributeListControl
            // 
            this.attributeListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attributeListControl.Location = new System.Drawing.Point(0, 0);
            this.attributeListControl.Name = "attributeListControl";
            this.attributeListControl.Server = server1;
            this.attributeListControl.Size = new System.Drawing.Size(505, 248);
            this.attributeListControl.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 54);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.monitoredItemsControl);
            this.splitContainer2.Size = new System.Drawing.Size(827, 498);
            this.splitContainer2.SplitterDistance = 248;
            this.splitContainer2.TabIndex = 6;
            // 
            // monitoredItemsControl
            // 
            this.monitoredItemsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monitoredItemsControl.Location = new System.Drawing.Point(0, 0);
            this.monitoredItemsControl.Name = "monitoredItemsControl";
            this.monitoredItemsControl.Server = null;
            this.monitoredItemsControl.Size = new System.Drawing.Size(827, 246);
            this.monitoredItemsControl.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(827, 574);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.StatusLabelSTS);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MenubarMS);
            this.MainMenuStrip = this.MenubarMS;
            this.Name = "MainForm";
            this.Text = "OPC UA .NET Client";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.MenubarMS.ResumeLayout(false);
            this.MenubarMS.PerformLayout();
            this.StatusLabelSTS.ResumeLayout(false);
            this.StatusLabelSTS.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip MenubarMS;
        private System.Windows.Forms.StatusStrip StatusLabelSTS;
        private BrowseControl browseControl;
        private AttributeListControl attributeListControl;
        private MonitoredItemsControl monitoredItemsControl;
        private System.Windows.Forms.ComboBox UrlCB;
        private System.Windows.Forms.Label EndpointsLBL;
        private System.Windows.Forms.Button ConnectDisconnectBTN;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subscriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_SamplingInterval;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.Label NodeLBL;
        private System.Windows.Forms.TextBox NodeTB;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SamplingInterval_100;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SamplingInterval_500;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SamplingInterval_1000;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem writeValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publishingIntervalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_PublishingInterval_200;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_PublishingInterval_1000;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_PublishingInterval_2000;

    }
}

