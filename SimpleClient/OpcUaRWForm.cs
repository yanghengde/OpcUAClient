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

        #endregion

        public OpcUaRWForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try { 
                server.Connect(txtServerUrl.Text.Trim());
            }catch(Exception ex)
            {
                throw ex;
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

            txtResult.Text = "write success:"+JsonConvert.SerializeObject(valueC);
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            string nodeID = txtNodeID.Text.Trim();
            string writevalue = txtWriteValue.Text.Trim();
            NodeIdCollection nic = new NodeIdCollection();
            NodeId nodeid = new NodeId(nodeID);
            nic.Add(nodeid);

            DataValueCollection valueC = new DataValueCollection();

            DataValue dv = new DataValue();
            dv.Value = txtWriteValue.Text.Trim();

            valueC.Add(dv);

            StatusCodeCollection results = null;

            server.WriteValues(
                   nic,
                   valueC,
                   out results);

            txtResult.Text = "write success";
        }
    }
}
