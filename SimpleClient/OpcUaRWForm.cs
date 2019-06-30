using Newtonsoft.Json;
using Opc.Ua;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Siemens.OpcUA.SimpleClient
{
    public partial class OpcUaRWForm : Form
    {
        #region 变量区域

        private Server server = new Server();

        private int connect = 0;

        #endregion

        public OpcUaRWForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try { 
                if(connect == 0) {
                    server.Connect(txtServerUrl.Text.Trim());
                }

                if(connect == 1)
                {
                    int code =  server.Disconnect();
                    txtServerUrl.ReadOnly = false;
                    btnConnect.Text = "Connect";
                    connect = 0;
                }

                if (server.Session.Connected)
                {
                    connect = 1;
                    txtServerUrl.ReadOnly = true;
                    MessageBox.Show("连接成功");
                    btnConnect.Text = "Disconnect";
                }
                
            }catch(Exception ex)
            {
                MessageBox.Show("连接失败");
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string nodeID = txtNodeID.Text.Trim();
            string writevalue = txtWriteValue.Text.Trim();
            NodeIdCollection nic = new NodeIdCollection();
            NodeId nodeid = new NodeId(nodeID);
            nic.Add(nodeid);

            DataValueCollection valueC;

            server.ReadValues(
                   nic,
                   out valueC);

            txtReadValue.Text = valueC[0].Value.ToString();

            txtResult.Text = "read success:"+valueC[0].Value.ToString();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            string nodeID = txtNodeID.Text.Trim();
            string writevalue = txtWriteValue.Text.Trim();
            if (string.IsNullOrEmpty(nodeID))
            {
                MessageBox.Show("请输入NodeID");
                return;
            }

            if (string.IsNullOrEmpty(writevalue))
            {
                MessageBox.Show("请输入写入的值");
                return;
            }

            NodeIdCollection nic = new NodeIdCollection();
            NodeId nodeid = new NodeId(nodeID);
            nic.Add(nodeid);

            DataValueCollection valueC;
            server.ReadValues(
                   nic,
                   out valueC);

            Variant variant = new Variant(Convert.ChangeType(writevalue, valueC[0].Value.GetType()));


            DataValueCollection values = new DataValueCollection();
            DataValue value = new DataValue(variant);
            values.Add(value);

            StatusCodeCollection results = null;

            server.WriteValues(
                   nic,
                   values,
                   out results);

            txtReadValue.Text = writevalue;

            txtResult.Text = "write success";
        }
    }
}
