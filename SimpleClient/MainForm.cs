using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Opc.Ua;
using Opc.Ua.Client;
using Siemens.OpcUA;

namespace Siemens.OpcUA.SimpleClient
{
    public partial class MainForm : Form
    {

        #region Construction
        public MainForm()
        {
            InitializeComponent();

            m_Server = new Server();

            m_Server.CertificateEvent += new certificateValidation(m_Server_CertificateEvent);
        }

        void m_Server_CertificateEvent(CertificateValidator validator, CertificateValidationEventArgs e)
        {
            // Accept all certificate -> better ask user
            e.Accept = true;
        }
        #endregion

        #region Fields
        private Server m_Server = null;
        private Subscription m_Subscipition;
        private Subscription m_SubscipitionBlock;
        private UInt16 m_NameSpaceIndex = 0;
        private object currentValue1;
        private object currentValue2;
        #endregion

        /// <summary>
        /// Connect to the UA server and read the namespace table.
        /// The connect is based on the Server URL entered in the Form
        /// The read of the namespace table is used to detect the namespace index
        /// of the namespace URI entered in the Form and used for the variables to read
        /// </summary>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            // Connect to the server
            try
            {
                // Connect with URL from Server URL text box
                m_Server.Connect(txtServerUrl.Text);

                // Toggle enable flag of buttons
                toggleButtons(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connect failed:\n\n" + ex.Message);
                return;
            }

            // Read Namespace Table
            try
            {
                NodeIdCollection nodesToRead = new NodeIdCollection();
                DataValueCollection results;

                nodesToRead.Add(Variables.Server_NamespaceArray);

                // Read the namespace array
                m_Server.ReadValues(nodesToRead, out results);

                if ( (results.Count != 1) || (results[0].Value.GetType() != typeof(string[])) )
                {
                    throw new Exception("Reading namespace table returned unexptected result");
                }

                // Try to find the namespace URI entered by the user
                string[] nameSpaceArray = (string[])results[0].Value;
                ushort i;
                for (i = 0; i < nameSpaceArray.Length; i++)
                {
                    if (nameSpaceArray[i] == txtNamespaceUri.Text)
                    {
                        m_NameSpaceIndex = i;
                    }
                }

                // Check if the namespace was found
                if ( m_NameSpaceIndex == 0 )
                {
                    throw new Exception("Namespace " + txtNamespaceUri.Text + " not found in server namespace table");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reading namespace table failed:\n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Disconnect from the UA server.
        /// </summary>
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_Subscipition != null)
                {
                    btnMonitor_Click(null, null);
                }

                if (m_SubscipitionBlock != null)
                {
                    btnMonitorBlock_Click(null, null);
                }

                // Disconnect from Server
                m_Server.Disconnect();

                // Toggle enable flag of buttons
                toggleButtons(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Disconnect failed:\n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Reads the values of the two variables entered in the From.
        /// The NodeIds used for the Read are constructed from the identifier entered 
        /// in the Form and the namespace index detected in the connect method
        /// </summary>
        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                NodeIdCollection nodesToRead = new NodeIdCollection();
                DataValueCollection results;

                // Add the two variable NodeIds to the list of nodes to read
                // NodeId is constructed from 
                // - the identifier text in the text box
                // - the namespace index collected during the server connect
                nodesToRead.Add(new NodeId(txtIdentifier1.Text, m_NameSpaceIndex));
                nodesToRead.Add(new NodeId(txtIdentifier2.Text, m_NameSpaceIndex));

                // Read the values
                m_Server.ReadValues(nodesToRead, out results);

                if ( results.Count != 2 )
                {
                    throw new Exception("Reading value returned unexptected number of result");
                }

                // Print result for first variable - check first the result code
                if (StatusCode.IsBad(results[0].StatusCode))
                {
                    // The node failed - print the symbolic name of the status code
                    txtRead1.Text = StatusCode.LookupSymbolicId(results[0].StatusCode.Code);
                    txtRead1.BackColor = Color.Red;
                }
                else
                {
                    // The node succeeded - print the value as string
                    txtRead1.Text = results[0].Value.ToString();
                    txtRead1.BackColor = Color.White;
                    currentValue1 = results[0].Value;
                }

                // Print result for second variable - check first the result code
                if (StatusCode.IsBad(results[1].StatusCode))
                {
                    // The node failed - print the symbolic name of the status code
                    txtRead2.Text = StatusCode.LookupSymbolicId(results[1].StatusCode.Code);
                    txtRead2.BackColor = Color.Red;
                }
                else
                {
                    // The node succeeded - print the value as string
                    txtRead2.Text = results[1].Value.ToString();
                    txtRead2.BackColor = Color.White;
                    currentValue2 = results[1].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read failed:\n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Starts the monitoring of the values of the two variables entered in the From.
        /// The NodeIds used for the monitoring are constructed from the identifier entered 
        /// in the Form and the namespace index detected in the connect method
        /// </summary>
        private void btnMonitor_Click(object sender, EventArgs e)
        {
            // Check if we have a subscription 
            //  - No  -> Create a new subscription and create monitored items
            //  - Yes -> Delete Subcription
            if (m_Subscipition == null)
            {
                try
                {
                    // Handle is not stored since we delete the whole subscription
                    object monitoredItemServerHandle = null;

                    // Create subscription
                    m_Subscipition = m_Server.AddSubscription(100);
                    btnMonitor.Text = "Stop";

                    // Create first monitored item
                    m_Subscipition.AddDataMonitoredItem(
                        new NodeId(txtIdentifier1.Text, m_NameSpaceIndex),
                        txtMonitored1,
                        ClientApi_ValueChanged,
                        100,
                        out monitoredItemServerHandle);

                    // Create second monitored item
                    m_Subscipition.AddDataMonitoredItem(
                        new NodeId(txtIdentifier2.Text, m_NameSpaceIndex),
                        txtMonitored2,
                        ClientApi_ValueChanged,
                        100,
                        out monitoredItemServerHandle);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Establishing data monitoring failed:\n\n" + ex.Message);
                }
            }
            else
            {
                try
                {
                    m_Server.RemoveSubscription(m_Subscipition);
                    m_Subscipition = null;

                    btnMonitor.Text = "Monitor";
                    txtMonitored1.Text = "";
                    txtMonitored2.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Stopping data monitoring failed:\n\n" + ex.Message);
                }
            }
        }

        /// <summary>
        /// Callback method for data changes from the monitored variables.
        /// The text boxes for the output of the values or status information are passed 
        /// to the client API as clientHandles and contained in the callback
        /// </summary>
        private void ClientApi_ValueChanged(object clientHandle, DataValue value)
        {
            try
            {
                // We have to call an invoke method 
                if (this.InvokeRequired)
                {
                    // Asynchronous execution of the valueChanged delegate
                    this.BeginInvoke(new valueChanged(ClientApi_ValueChanged), clientHandle, value);
                    return;
                }

                if (clientHandle.GetType() == typeof(TextBox))
                {
                    // Get the according item
                    TextBox txtMonitoredValue = (TextBox)clientHandle;

                    // Print data change information for variable - check first the result code
                    if (StatusCode.IsBad(value.StatusCode))
                    {
                        // The node failed - print the symbolic name of the status code
                        txtMonitoredValue.Text = StatusCode.LookupSymbolicId(value.StatusCode.Code);
                        txtMonitoredValue.BackColor = Color.Red;
                    }
                    else
                    {
                        // The node succeeded - print the value as string
                        txtMonitoredValue.Text = value.Value.ToString();
                        txtMonitoredValue.BackColor = Color.White;
                    }
                }
                else
                {
                    // Print result for block - check first the result code
                    if (StatusCode.IsBad(value.StatusCode))
                    {
                        // The node failed - print the symbolic name of the status code
                        txtReadBlock.Text = StatusCode.LookupSymbolicId(value.StatusCode.Code);
                        txtReadBlock.BackColor = Color.Red;
                    }
                    else
                    {
                        if (value.Value.GetType() != typeof(byte[]))
                        {
                            throw new Exception("Value change for block did not send byte array");
                        }

                        byte[] rawValue = (byte[])value.Value;
                        string stringValue = "";
                        int lineLength = 0;

                        for (int i = 0; i < rawValue.Count(); i++)
                        {
                            stringValue += string.Format("{0:X2} ", rawValue[i]);
                            lineLength++;
                            if (lineLength > 25)
                            {
                                stringValue += "\n";
                                lineLength = 0;
                            }
                        }

                        // The node succeeded - print the value as string
                        txtReadBlock.Text = stringValue;
                        txtReadBlock.BackColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error in the data change callback:\n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Write the value of the first variable entered in the From.
        /// The NodeId used for the Write is constructed from the identifier entered 
        /// in the Form and the namespace index detected in the connect method
        /// </summary>
        private void btnWrite1_Click(object sender, EventArgs e)
        {
            writeNewValue(
                new NodeId(txtIdentifier1.Text, m_NameSpaceIndex),  // NodeId = identifier + namespace index
                txtWrite1.Text, // Value to write as string
                currentValue1); // Current value from Read used to convert the string to the target type
        }

        /// <summary>
        /// Write the value of the second variable entered in the From.
        /// The NodeId used for the Write is constructed from the identifier entered 
        /// in the Form and the namespace index detected in the connect method
        /// </summary>
        private void btnWrite2_Click(object sender, EventArgs e)
        {
            writeNewValue(
                new NodeId(txtIdentifier2.Text, m_NameSpaceIndex), // NodeId = identifier + namespace index
                txtWrite2.Text, // Value to write as string
                currentValue1); // Current value from Read used to convert the string to the target type
        }

        /// <summary>
        /// Helper function to writing a value to a variable.
        /// The function 
        /// - reads the data type of the variable
        /// - converts the passed string to the data type
        /// - writes the value to the variable
        /// </summary>
        private void writeNewValue(NodeId nodeToWrite, string valueToWrite, object currentValue)
        {
            try
            {
                NodeIdCollection nodesToWrite = new NodeIdCollection();
                DataValueCollection values = new DataValueCollection();
                StatusCodeCollection results;
                Variant value = new Variant(Convert.ChangeType(valueToWrite, currentValue.GetType()));
                
                nodesToWrite.Add(nodeToWrite);
                values.Add(new DataValue(value));

                m_Server.WriteValues(
                    nodesToWrite,
                    values,
                    out results);

                if (StatusCode.IsBad(results[0]))
                {
                    throw new Exception(StatusCode.LookupSymbolicId(results[0].Code));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Writing new value failed:\n\n" + ex.Message);
            }
        }

        private void btnMonitorBlock_Click(object sender, EventArgs e)
        {
            // Check if we have a subscription 
            //  - No  -> Create a new subscription and create monitored item
            //  - Yes -> Delete Subcription
            if (m_SubscipitionBlock == null)
            {
                try
                {
                    // Handle is not stored since we delete the whole subscription
                    object monitoredItemServerHandle = null;

                    // Create subscription
                    m_SubscipitionBlock = m_Server.AddSubscription(100);
                    btnMonitorBlock.Text = "Stop";

                    // Create first monitored item
                    m_SubscipitionBlock.AddDataMonitoredItem(
                        new NodeId(txtIdentifierBlockRead.Text, m_NameSpaceIndex),
                        txtReadBlock,
                        ClientApi_ValueChanged,
                        100,
                        out monitoredItemServerHandle);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Establishing block monitoring failed:\n\n" + ex.Message);
                }
            }
            else
            {
                try
                {
                    m_Server.RemoveSubscription(m_SubscipitionBlock);
                    m_SubscipitionBlock = null;

                    btnMonitorBlock.Text = "Monitor Block";
                    txtReadBlock.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Stopping block monitoring failed:\n\n" + ex.Message);
                }
            }
        }

        private void btnWriteBlock1_Click(object sender, EventArgs e)
        {
            int writeLength = (int)Convert.ChangeType(txtWriteLength.Text, typeof(int));
            byte[] rawValue = new byte[writeLength];
            byte currentValue = 0;
            object writeValue;

            for (int i = 0; i < rawValue.Count(); i++)
            {
                rawValue[i] = currentValue;
                currentValue++;
            }

            writeValue = rawValue;

            writeNewBlockValue(
                new NodeId(txtIdentifierBlockWrite.Text, m_NameSpaceIndex), // NodeId = identifier + namespace index
                writeValue); // Value to write as byte array
        }

        private void btnWriteBlock2_Click(object sender, EventArgs e)
        {
            int writeLength = (int)Convert.ChangeType(txtWriteLength.Text, typeof(int));
            byte[] rawValue = new byte[writeLength];
            byte currentValue = 255;
            object writeValue;

            for (int i = 0; i < rawValue.Count(); i++)
            {
                rawValue[i] = currentValue;
                currentValue--;
            }

            writeValue = rawValue;

            writeNewBlockValue(
                new NodeId(txtIdentifierBlockWrite.Text, m_NameSpaceIndex), // NodeId = identifier + namespace index
                writeValue); // Value to write as byte array
        }

        /// <summary>
        /// Helper function to writing a value to a variable.
        /// The function 
        /// - reads the data type of the variable
        /// - converts the passed string to the data type
        /// - writes the value to the variable
        /// </summary>
        private void writeNewBlockValue(NodeId nodeToWrite, object valueToWrite)
        {
            try
            {
                NodeIdCollection nodesToWrite = new NodeIdCollection();
                DataValueCollection values = new DataValueCollection();
                StatusCodeCollection results;
                Variant value = new Variant(valueToWrite);

                nodesToWrite.Add(nodeToWrite);
                values.Add(new DataValue(value));

                m_Server.WriteValues(
                    nodesToWrite,
                    values,
                    out results);

                if (StatusCode.IsBad(results[0]))
                {
                    throw new Exception(StatusCode.LookupSymbolicId(results[0].Code));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Writing new block value failed:\n\n" + ex.Message);
            }
        }

        private void toggleButtons(bool isConnected)
        {
            // Toggle Connect / Disconnect buttons
            btnConnect.Enabled = !isConnected;
            btnDisconnect.Enabled = isConnected;

            // Toggle Textboxes
            txtServerUrl.Enabled = !isConnected;
            txtNamespaceUri.Enabled = !isConnected;

            // Toggle action buttons
            btnMonitor.Enabled = isConnected;
            btnRead.Enabled = isConnected;
            btnWrite1.Enabled = isConnected;
            btnWrite2.Enabled = isConnected;
            btnMonitorBlock.Enabled = isConnected;
            btnWriteBlock1.Enabled = isConnected;
            btnWriteBlock2.Enabled = isConnected;
        }
    }
}
