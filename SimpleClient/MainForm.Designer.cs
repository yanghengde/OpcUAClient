namespace Siemens.OpcUA.SimpleClient
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
            this.txtServerUrl = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.txtNamespaceUri = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.txtIdentifier1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMonitored1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRead1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWrite1 = new System.Windows.Forms.TextBox();
            this.btnWrite1 = new System.Windows.Forms.Button();
            this.txtWrite2 = new System.Windows.Forms.TextBox();
            this.btnWrite2 = new System.Windows.Forms.Button();
            this.txtRead2 = new System.Windows.Forms.TextBox();
            this.txtMonitored2 = new System.Windows.Forms.TextBox();
            this.txtIdentifier2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReadBlock = new System.Windows.Forms.RichTextBox();
            this.btnMonitorBlock = new System.Windows.Forms.Button();
            this.txtIdentifierBlockRead = new System.Windows.Forms.TextBox();
            this.txtIdentifierBlockWrite = new System.Windows.Forms.TextBox();
            this.btnWriteBlock1 = new System.Windows.Forms.Button();
            this.btnWriteBlock2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtWriteLength = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtServerUrl
            // 
            this.txtServerUrl.Location = new System.Drawing.Point(104, 10);
            this.txtServerUrl.Name = "txtServerUrl";
            this.txtServerUrl.Size = new System.Drawing.Size(199, 20);
            this.txtServerUrl.TabIndex = 0;
            this.txtServerUrl.Text = " opc.tcp://UADM25:48010";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(13, 8);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(13, 37);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 2;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // txtNamespaceUri
            // 
            this.txtNamespaceUri.Location = new System.Drawing.Point(104, 39);
            this.txtNamespaceUri.Name = "txtNamespaceUri";
            this.txtNamespaceUri.Size = new System.Drawing.Size(199, 20);
            this.txtNamespaceUri.TabIndex = 3;
            this.txtNamespaceUri.Text = "S7:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "OPC UA Server URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Used Namespce URI";
            // 
            // btnMonitor
            // 
            this.btnMonitor.Enabled = false;
            this.btnMonitor.Location = new System.Drawing.Point(228, 109);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(75, 48);
            this.btnMonitor.TabIndex = 6;
            this.btnMonitor.Text = "Monitor";
            this.btnMonitor.UseVisualStyleBackColor = true;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // txtIdentifier1
            // 
            this.txtIdentifier1.Location = new System.Drawing.Point(13, 111);
            this.txtIdentifier1.Name = "txtIdentifier1";
            this.txtIdentifier1.Size = new System.Drawing.Size(209, 20);
            this.txtIdentifier1.TabIndex = 7;
            this.txtIdentifier1.Text = "Conn002.m.0,w";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Variable Identifier";
            // 
            // txtMonitored1
            // 
            this.txtMonitored1.Location = new System.Drawing.Point(309, 111);
            this.txtMonitored1.Name = "txtMonitored1";
            this.txtMonitored1.Size = new System.Drawing.Size(139, 20);
            this.txtMonitored1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Monitored Value";
            // 
            // btnRead
            // 
            this.btnRead.Enabled = false;
            this.btnRead.Location = new System.Drawing.Point(454, 109);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 48);
            this.btnRead.TabIndex = 11;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(532, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Read Value";
            // 
            // txtRead1
            // 
            this.txtRead1.Location = new System.Drawing.Point(535, 111);
            this.txtRead1.Name = "txtRead1";
            this.txtRead1.Size = new System.Drawing.Size(139, 20);
            this.txtRead1.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(758, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Write Value";
            // 
            // txtWrite1
            // 
            this.txtWrite1.Location = new System.Drawing.Point(761, 111);
            this.txtWrite1.Name = "txtWrite1";
            this.txtWrite1.Size = new System.Drawing.Size(139, 20);
            this.txtWrite1.TabIndex = 15;
            // 
            // btnWrite1
            // 
            this.btnWrite1.Enabled = false;
            this.btnWrite1.Location = new System.Drawing.Point(680, 109);
            this.btnWrite1.Name = "btnWrite1";
            this.btnWrite1.Size = new System.Drawing.Size(75, 23);
            this.btnWrite1.TabIndex = 14;
            this.btnWrite1.Text = "Write";
            this.btnWrite1.UseVisualStyleBackColor = true;
            this.btnWrite1.Click += new System.EventHandler(this.btnWrite1_Click);
            // 
            // txtWrite2
            // 
            this.txtWrite2.Location = new System.Drawing.Point(761, 137);
            this.txtWrite2.Name = "txtWrite2";
            this.txtWrite2.Size = new System.Drawing.Size(139, 20);
            this.txtWrite2.TabIndex = 23;
            // 
            // btnWrite2
            // 
            this.btnWrite2.Enabled = false;
            this.btnWrite2.Location = new System.Drawing.Point(680, 135);
            this.btnWrite2.Name = "btnWrite2";
            this.btnWrite2.Size = new System.Drawing.Size(75, 23);
            this.btnWrite2.TabIndex = 22;
            this.btnWrite2.Text = "Write";
            this.btnWrite2.UseVisualStyleBackColor = true;
            this.btnWrite2.Click += new System.EventHandler(this.btnWrite2_Click);
            // 
            // txtRead2
            // 
            this.txtRead2.Location = new System.Drawing.Point(535, 137);
            this.txtRead2.Name = "txtRead2";
            this.txtRead2.Size = new System.Drawing.Size(139, 20);
            this.txtRead2.TabIndex = 21;
            // 
            // txtMonitored2
            // 
            this.txtMonitored2.Location = new System.Drawing.Point(309, 137);
            this.txtMonitored2.Name = "txtMonitored2";
            this.txtMonitored2.Size = new System.Drawing.Size(139, 20);
            this.txtMonitored2.TabIndex = 19;
            // 
            // txtIdentifier2
            // 
            this.txtIdentifier2.Location = new System.Drawing.Point(13, 137);
            this.txtIdentifier2.Name = "txtIdentifier2";
            this.txtIdentifier2.Size = new System.Drawing.Size(209, 20);
            this.txtIdentifier2.TabIndex = 18;
            this.txtIdentifier2.Text = "Conn002.db50.0,b";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtReadBlock);
            this.groupBox1.Controls.Add(this.btnMonitorBlock);
            this.groupBox1.Controls.Add(this.txtIdentifierBlockRead);
            this.groupBox1.Location = new System.Drawing.Point(16, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(880, 135);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Block Read";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(303, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Block Read Result";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Variable Identifier Block Read";
            // 
            // txtReadBlock
            // 
            this.txtReadBlock.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReadBlock.Location = new System.Drawing.Point(305, 28);
            this.txtReadBlock.Name = "txtReadBlock";
            this.txtReadBlock.Size = new System.Drawing.Size(569, 99);
            this.txtReadBlock.TabIndex = 6;
            this.txtReadBlock.Text = "";
            // 
            // btnMonitorBlock
            // 
            this.btnMonitorBlock.Enabled = false;
            this.btnMonitorBlock.Location = new System.Drawing.Point(212, 29);
            this.btnMonitorBlock.Name = "btnMonitorBlock";
            this.btnMonitorBlock.Size = new System.Drawing.Size(87, 23);
            this.btnMonitorBlock.TabIndex = 2;
            this.btnMonitorBlock.Text = "Monitor Block";
            this.btnMonitorBlock.UseVisualStyleBackColor = true;
            this.btnMonitorBlock.Click += new System.EventHandler(this.btnMonitorBlock_Click);
            // 
            // txtIdentifierBlockRead
            // 
            this.txtIdentifierBlockRead.Location = new System.Drawing.Point(6, 32);
            this.txtIdentifierBlockRead.Name = "txtIdentifierBlockRead";
            this.txtIdentifierBlockRead.Size = new System.Drawing.Size(199, 20);
            this.txtIdentifierBlockRead.TabIndex = 0;
            this.txtIdentifierBlockRead.Text = "Conn002.BRCV1";
            // 
            // txtIdentifierBlockWrite
            // 
            this.txtIdentifierBlockWrite.Location = new System.Drawing.Point(7, 36);
            this.txtIdentifierBlockWrite.Name = "txtIdentifierBlockWrite";
            this.txtIdentifierBlockWrite.Size = new System.Drawing.Size(200, 20);
            this.txtIdentifierBlockWrite.TabIndex = 1;
            this.txtIdentifierBlockWrite.Text = "Conn002.BSEND1.4096";
            // 
            // btnWriteBlock1
            // 
            this.btnWriteBlock1.Enabled = false;
            this.btnWriteBlock1.Location = new System.Drawing.Point(438, 34);
            this.btnWriteBlock1.Name = "btnWriteBlock1";
            this.btnWriteBlock1.Size = new System.Drawing.Size(88, 23);
            this.btnWriteBlock1.TabIndex = 3;
            this.btnWriteBlock1.Text = "Write Block 1";
            this.btnWriteBlock1.UseVisualStyleBackColor = true;
            this.btnWriteBlock1.Click += new System.EventHandler(this.btnWriteBlock1_Click);
            // 
            // btnWriteBlock2
            // 
            this.btnWriteBlock2.Enabled = false;
            this.btnWriteBlock2.Location = new System.Drawing.Point(664, 34);
            this.btnWriteBlock2.Name = "btnWriteBlock2";
            this.btnWriteBlock2.Size = new System.Drawing.Size(88, 23);
            this.btnWriteBlock2.TabIndex = 4;
            this.btnWriteBlock2.Text = "Write Block 2";
            this.btnWriteBlock2.UseVisualStyleBackColor = true;
            this.btnWriteBlock2.Click += new System.EventHandler(this.btnWriteBlock2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Variable Identifier Block Write";
            // 
            // txtWriteLength
            // 
            this.txtWriteLength.Location = new System.Drawing.Point(213, 36);
            this.txtWriteLength.Name = "txtWriteLength";
            this.txtWriteLength.Size = new System.Drawing.Size(52, 20);
            this.txtWriteLength.TabIndex = 12;
            this.txtWriteLength.Text = "4096";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(271, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Write Length in Byte";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnWriteBlock1);
            this.groupBox2.Controls.Add(this.txtWriteLength);
            this.groupBox2.Controls.Add(this.txtIdentifierBlockWrite);
            this.groupBox2.Controls.Add(this.btnWriteBlock2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(16, 305);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(880, 65);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Block Write";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(758, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Write [255, 254, ... 0]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(532, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Write [0, 1, 2 ... 255]";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 375);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtWrite2);
            this.Controls.Add(this.btnWrite2);
            this.Controls.Add(this.txtRead2);
            this.Controls.Add(this.txtMonitored2);
            this.Controls.Add(this.txtIdentifier2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtWrite1);
            this.Controls.Add(this.btnWrite1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRead1);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMonitored1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIdentifier1);
            this.Controls.Add(this.btnMonitor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNamespaceUri);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtServerUrl);
            this.Name = "MainForm";
            this.Text = "Simple OPC UA Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServerUrl;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.TextBox txtNamespaceUri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.TextBox txtIdentifier1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMonitored1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRead1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtWrite1;
        private System.Windows.Forms.Button btnWrite1;
        private System.Windows.Forms.TextBox txtWrite2;
        private System.Windows.Forms.Button btnWrite2;
        private System.Windows.Forms.TextBox txtRead2;
        private System.Windows.Forms.TextBox txtMonitored2;
        private System.Windows.Forms.TextBox txtIdentifier2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnWriteBlock2;
        private System.Windows.Forms.Button btnWriteBlock1;
        private System.Windows.Forms.Button btnMonitorBlock;
        private System.Windows.Forms.TextBox txtIdentifierBlockWrite;
        private System.Windows.Forms.TextBox txtIdentifierBlockRead;
        private System.Windows.Forms.RichTextBox txtReadBlock;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtWriteLength;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

