using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Opc.Ua;
using Opc.Ua.Client;
using Siemens.OpcUA;

namespace Siemens.OpcUA.Client
{
    /// <summary>
    /// The main form of the user interface.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Construction
        /// <summary>
        /// Initializes the controls of this form. Registers for an particular event.
        /// </summary>
        public MainForm()
        {
            // Initialize controls.
            InitializeComponent();

            // Register for the SelectionChanged event of BrowseControl in order to update
            // the ListView of AttributeListControl.
            browseControl.SelectionChanged += new BrowseControl.SelectionChangedEventHandler(browserControl_SelectionChanged);

            // Register for the update statuslabel event of AttriuteListControl in order to update
            // the status label.
            attributeListControl.UpdateStatusLabel += 
                new AttributeListControl.UpdateStatusLabelEventHandler(UserControl_UpdateStatusLabel);
            
            // Register for the update statuslabel event of MonitoredItemsControl in order to update
            // the status label.
            monitoredItemsControl.UpdateStatusLabel +=
                new MonitoredItemsControl.UpdateStatusLabelEventHandler(UserControl_UpdateStatusLabel);

            // Create client API server object
            m_Server = new Server();
            // Attach to certificate event
            m_Server.CertificateEvent += new certificateValidation(m_Server_CertificateEvent);
        }
        #endregion

        #region Fields
        /// <summary>
        /// Provides access to the OPC UA server and its services. 
        /// </summary>
        private Server m_Server = null;
        /// <summary>
        /// Indicates the connect state.
        /// </summary>
        private bool m_Connected = false;
        #endregion

        #region Properties
        /// <summary>
        /// Provides the text of the selected item of the combobox.
        /// </summary>
        public string ServerURL
        {
            get { return UrlCB.Text; }
        }
        /// <summary>
        /// Provides the status label toolstrip.
        /// </summary>
        public System.Windows.Forms.ToolStripStatusLabel StatusLabel
        {
            get { return toolStripStatusLabel; }
        }
        #endregion        
       
        #region Calls to Client API
        /// <summary>
        /// Connect to server.
        /// </summary>
        private int Connect()
        {
            // Check the content of the combobox.
            if( UrlCB.Text.Length == 0 )
            {
                return -1;
            }

            // Set wait cursor.
            Cursor = Cursors.WaitCursor;
            int result = 0;
            
            try
            {
                EndpointWrapper wrapper;
                string endpointUrl;

                // Extract Url from combobox text.
                object item = UrlCB.SelectedItem;
                if ((item == null) || (item.GetType() == typeof(string)))
                {
                    // The URL has been entered as text.
                    endpointUrl = UrlCB.Text;

                    // Call connect with URL
                    m_Server.Connect(endpointUrl);
                }
                else
                {
                    // The endpoint was provided through discovery.
                    wrapper = (EndpointWrapper)item;
                    endpointUrl = wrapper.Endpoint.EndpointUrl;

                    // Call connect with endpoint
                    m_Server.Connect(wrapper.Endpoint);
                }

                // Connect succeeded.
                m_Connected = true;
                
                // Aggregate the UserControls.
                browseControl.Server = m_Server;
                attributeListControl.Server = m_Server;
                monitoredItemsControl.Server = m_Server;
                
                // State is connected now.
                ConnectDisconnectBTN.Text = "Disconnect";
                
                // Update status label.
                toolStripStatusLabel.Text = "Connected to " + endpointUrl;
                toolStripStatusLabel.Image = global::Siemens.OpcUA.Client.Properties.Resources.success;

                UrlCB.Enabled = false;
            }
            catch (Exception e)
            {
                if (m_Connected)
                {
                    // Disconnect from server.
                    Disconnect();
                }

                result = -1;
                m_Connected = false;
                
                // Update status label.
                toolStripStatusLabel.Text = "Connect failed. Error: " + e.Message;
                toolStripStatusLabel.Image = global::Siemens.OpcUA.Client.Properties.Resources.error;
            }

            // Set default cursor.
            Cursor = Cursors.Default;
            return result;
        }

        /// <summary>
        /// Disconnect from server.
        /// </summary>
        private int Disconnect()
        {
            int result;

            try
            {
                // Call the disconnect service of the server.
                result = m_Server.Disconnect();

                // Disconnect succeeded.
                if (result == 0)
                {
                    // Look for subscription
                    if (monitoredItemsControl.Subscription != null)
                    {
                        // Remove the subscription from session.
                        monitoredItemsControl.RemoveSubscription();
                    }

                    // Set flag.
                    m_Connected = false;

                    // Update status label.
                    toolStripStatusLabel.Text = "Not connected.";
                    toolStripStatusLabel.Image = global::Siemens.OpcUA.Client.Properties.Resources.warning;

                    // State is connected now.
                    ConnectDisconnectBTN.Text = "Connect";

                    // Enable the combobox to respond to user interaction.
                    UrlCB.Enabled = true;
                }
                // Disconnect failed. 
                else
                {
                    // Error case.
                    m_Connected = true;

                    // Update status label.
                    toolStripStatusLabel.Text = "Disconnect failed. Error: " + result.ToString();
                    toolStripStatusLabel.Image = global::Siemens.OpcUA.Client.Properties.Resources.error;
                }
            }
            catch (Exception e)
            {
                result = -1;
                
                // Update status label.
                toolStripStatusLabel.Text = "An exception occured during disconnect: " + e.Message;
                toolStripStatusLabel.Image = global::Siemens.OpcUA.Client.Properties.Resources.error;
            }

            // Cleanup attribute list.
            this.attributeListControl.AttributeList.Items.Clear();

            // Cleanup monitored items list.
            this.monitoredItemsControl.MonitoredItemsList.Items.Clear();
            
            // Cleanup treeview.
            browseControl.BrowseTree.BeginUpdate();
            browseControl.BrowseTree.Nodes.Clear();
            browseControl.BrowseTree.EndUpdate();
            return result;
        }
        #endregion

        #region User Actions
        /// <summary>
        /// Callback of the exception thrown event of BrowseControl and AttributeListControl.
        /// </summary>
        /// <param name="node">The source of the event.</param>
        private void UserControl_UpdateStatusLabel(string strMessage, bool bSuccess)
        {
            toolStripStatusLabel.Text = strMessage;

            if (bSuccess == true)
            {
                toolStripStatusLabel.Image = global::Siemens.OpcUA.Client.Properties.Resources.success;
            }
            else
            {
                toolStripStatusLabel.Image = global::Siemens.OpcUA.Client.Properties.Resources.error;
            }
        }

        /// <summary>
        /// Callback of the selection changed event of BrowseControl.
        /// </summary>
        /// <param name="node">The source of the event.</param>
        private void browserControl_SelectionChanged(TreeNode node)
        {
            // Read all the attributes of the selected tree node.
            attributeListControl.ReadAttributes(node);
        }

        /// <summary>
        /// Expands the drop down list of the ComboBox to display available servers and endpoints.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void UrlCB_DropDown(object sender, EventArgs e) 
        {
            try
            {
                Uri discoveryUrl = null;

                // Check the text property of the Server textbox
                if (NodeTB.Text.Length == 0)
                {
                    // Set the uri of the local discovery server by default.
                    discoveryUrl = new Uri("opc.tcp://localhost:48010");
                }
                else
                {
                    // Create the uri from hostname.
                    string sUrl;

                    // Has the port been entered by the user?
                    char seperator = ':';
                    string[] strPortCheck = NodeTB.Text.Split(seperator);
                    if (strPortCheck.Length > 1)
                    {
                        sUrl = "opc.tcp://" + NodeTB.Text;
                    }
                    else
                    {
                        sUrl = "opc.tcp://" + NodeTB.Text + ":48010";
                    }

                    // Create the uri itself.
                    discoveryUrl = new Uri(sUrl);
                }

                // Set wait cursor.
                Cursor = Cursors.WaitCursor;

                // Clear all items of the ComboBox.
                UrlCB.Items.Clear();
                UrlCB.Text = "";

                // Look for servers
                ApplicationDescriptionCollection servers = null;
                Discovery discovery = new Discovery();

                discovery.FindServers(discoveryUrl, ref servers);

                // Populate the drop down list with the endpoints for the available servers.
                for (int iServer = 0; iServer < servers.Count; iServer++)
                {
                    try
                    {
                        // Create discovery client and get the available endpoints.
                        EndpointDescriptionCollection endpoints = null;

                        string sUrl;
                        sUrl = servers[iServer].DiscoveryUrls[0];
                        discoveryUrl = new Uri(sUrl);
                                                
                        discovery.GetEndpoints(discoveryUrl, ref endpoints);

                        // Create wrapper and fill the combobox.
                        for (int i = 0; i < endpoints.Count; i++)
                        {
                            // Create endpoint wrapper.
                            EndpointWrapper wrapper = new EndpointWrapper(endpoints[i]);

                            // Add it to the combobox.
                            UrlCB.Items.Add(wrapper);
                        }

                        // Update status label.
                        toolStripStatusLabel.Text = "GetEndpoints succeeded for " + servers[iServer].ApplicationName;
                        toolStripStatusLabel.Image = global::Siemens.OpcUA.Client.Properties.Resources.success;
                    }
                    catch (Exception)
                    {
                        // Update status label.
                        toolStripStatusLabel.Text = "GetEndpoints failed for " + servers[iServer].ApplicationName;
                        toolStripStatusLabel.Image = global::Siemens.OpcUA.Client.Properties.Resources.error;
                    }
                }

                // Set default cursor.
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                // Update status label.
                toolStripStatusLabel.Text = "FindServers failed:" + ex.ToString();
                toolStripStatusLabel.Image = global::Siemens.OpcUA.Client.Properties.Resources.error;
            }
        }

        /// <summary>
        /// Handles the connect / disconnect procedure.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnConnectDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Currently connected -> disconnect.
                if (m_Connected)
                {
                    Disconnect();
                }
                // Currently not connected -> connect to server.
                else
                {
                    // Browse first level.
                    if (Connect() == 0)
                    {
                        // Browse from root.
                        browseControl.Browse(null);
                    }
                }
            }
            catch (Exception)
            {
                // Update status label.
                if (m_Connected)
                {
                    toolStripStatusLabel.Text = "Disconnect failed";
                }
                else
                {
                    toolStripStatusLabel.Text = "Connect failed";
                }
                toolStripStatusLabel.Image = global::Siemens.OpcUA.Client.Properties.Resources.error;
            }
        }

        /// <summary>
        /// Handles the connect procedure being started from the menu bar.
        /// <summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Browse first level.
                if (Connect() == 0)
                {
                    // Browse from root.
                    browseControl.Browse(null);

                    // Update status bar.
                    toolStripStatusLabel.Text = "Connect succeeded.";
                }
            }
            catch (Exception)
            {
                // Update status bar.
                toolStripStatusLabel.Text = "Connect failed.";
                toolStripStatusLabel.Image = global::Siemens.OpcUA.Client.Properties.Resources.error;
            }
        }

        /// <summary>
        // Handles the disconnect procedure being started from the menu bar.
        /// <summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Disconnect from server
                Disconnect();
                // Update status label.
                toolStripStatusLabel.Text = "Disconnect succeeded.";
            }
            catch (Exception)
            {
                // Update status label.
                toolStripStatusLabel.Text = "Disconnect failed.";
                toolStripStatusLabel.Image = global::Siemens.OpcUA.Client.Properties.Resources.error;
            }
        }

        /// <summary>
        // Handles the sampling interval procedure started from the menu bar.
        /// <summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SamplingInterval_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if operation is currently allowed.
                if (monitoredItemsControl.Subscription.Session == null ||
                    monitoredItemsControl.Subscription.innerSubscription == null ||
                    monitoredItemsControl.MonitoredItemsList.SelectedItems.Count == 0)
                {
                    return;
                }

                // Determine the sampling interval being requested.
                double samplingInterval = 0;

                if (sender == toolStripMenuItem_SamplingInterval_100)
                {
                    samplingInterval = 100;
                }
                else if (sender == toolStripMenuItem_SamplingInterval_500)
                {
                    samplingInterval = 500;
                }
                else if (sender == toolStripMenuItem_SamplingInterval_1000)
                {
                    samplingInterval = 1000;
                }

                // Update the monitoring mode.
                List<MonitoredItem> itemsToChange = new List<MonitoredItem>();

                for (int ii = 0; ii < monitoredItemsControl.MonitoredItemsList.SelectedItems.Count; ii++)
                {
                    MonitoredItem monitoredItem = monitoredItemsControl.MonitoredItemsList.SelectedItems[ii].Tag as MonitoredItem;

                    if (monitoredItem != null)
                    {
                        // Set the current interval.
                        monitoredItem.SamplingInterval = (int)samplingInterval;
                        itemsToChange.Add(monitoredItem);
                        
                        // Apply the changes to the server.
                        monitoredItemsControl.Subscription.ModifyMonitoredItem(monitoredItem);

                        // Update the display.
                        // Sampling column.
                        monitoredItemsControl.MonitoredItemsList.SelectedItems[ii].SubItems[1].Text = samplingInterval.ToString();
                        
                        // Error column.
                        monitoredItemsControl.MonitoredItemsList.SelectedItems[ii].SubItems[5].Text = String.Empty;

                        if (ServiceResult.IsBad(itemsToChange[ii].Status.Error))
                        {
                            monitoredItemsControl.MonitoredItemsList.SelectedItems[ii].SubItems[5].Text = itemsToChange[ii].Status.Error.StatusCode.ToString();
                        }
                    }
                }

                // Update status label.
                toolStripStatusLabel.Text = "Setting sampling interval succeeded.";
            }
            catch (Exception exception)
            {
                // Update status label.
                toolStripStatusLabel.Text = "An exception occured while setting sampling interval: " + exception.Message;
                toolStripStatusLabel.Image = global::Siemens.OpcUA.Client.Properties.Resources.error;
            }
        }

        /// <summary>
        // Handles the write values procedure started from the menu bar.
        /// <summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void WriteValues_Click(object sender, EventArgs e)
        {
            // Prepare ListViewItem collection of selected items
            ListViewItem[] itemCollection;
            itemCollection = null;

            // Adopt the item collection to the number of selected items.
            Array.Resize(ref itemCollection, this.monitoredItemsControl.MonitoredItemsList.SelectedItems.Count);
            int i = 0;

            foreach (ListViewItem selectedItem in this.monitoredItemsControl.MonitoredItemsList.SelectedItems)
            {
                // Create new item for the write values dialog and set NodeId. 
                String sNodeId = selectedItem.SubItems[0].Text;
                
                // Create empty subitem. 
                ListViewItem item = new ListViewItem("");

                // Set nodeid.
                item.SubItems.Add(selectedItem.SubItems[0].Text);

                // Set current value.
                item.SubItems.Add(selectedItem.SubItems[3].Text);

                // Add item to collection.
                itemCollection[i] = item;
                i++;
            }

            // Show write values dialog.
            try
            {
                new WriteValuesDialog().Show(m_Server, itemCollection);
                // Update status label.
                toolStripStatusLabel.Text = "Writing values succeeded.";
            }
            catch (Exception exception)
            {
                // Update status label.
                toolStripStatusLabel.Text = "An exception occured while writing values: " + exception.Message;
                toolStripStatusLabel.Image = global::Siemens.OpcUA.Client.Properties.Resources.error;
            }
        }

        /// <summary>
        // Handles the remove items procedure started from the menu bar.
        /// <summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void RemoveItems_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if operation is currently allowed.
                if (monitoredItemsControl.Subscription.Session == null ||
                    monitoredItemsControl.Subscription.innerSubscription == null ||
                    monitoredItemsControl.MonitoredItemsList.SelectedItems.Count == 0)
                {
                    return;
                }

                // Collect the items to delete.
                List<ListViewItem> itemsToDelete = new List<ListViewItem>();

                for (int ii = 0; ii < monitoredItemsControl.MonitoredItemsList.SelectedItems.Count; ii++)
                {
                    MonitoredItem monitoredItem = monitoredItemsControl.MonitoredItemsList.SelectedItems[ii].Tag as MonitoredItem;

                    if (monitoredItem != null)
                    {
                        monitoredItemsControl.Subscription.RemoveMonitoredItem(monitoredItem);
                        itemsToDelete.Add(monitoredItemsControl.MonitoredItemsList.SelectedItems[ii]);
                    }
                }

                // Check the status.
                for (int ii = 0; ii < itemsToDelete.Count; ii++)
                {
                    MonitoredItem monitoredItem = itemsToDelete[ii].Tag as MonitoredItem;

                    if (ServiceResult.IsBad(monitoredItem.Status.Error))
                    {
                        // Fill error column.
                        itemsToDelete[ii].SubItems[5].Text = monitoredItem.Status.Error.StatusCode.ToString();
                        continue;
                    }

                    // Remove the current item from the listview.
                    itemsToDelete[ii].Remove();
                }

                // Set the width of the NodeId and the Error column.
                monitoredItemsControl.MonitoredItemsList.Columns[0].Width = -2;
                monitoredItemsControl.MonitoredItemsList.Columns[5].Width = -2;

                // Update status label.
                toolStripStatusLabel.Text = "Removing monitored items succeeded.";
            }
            catch (Exception exception)
            {
                // Update status label.
                toolStripStatusLabel.Text = "An exception occured while removing monitored items: " + exception.Message;
                toolStripStatusLabel.Image = global::Siemens.OpcUA.Client.Properties.Resources.error;
            }
        }

        /// <summary>
        // Handles the publishing interval procedure started from the menu bar.
        /// <summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void PublishingInterval_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if operation is currently allowed.
                if (monitoredItemsControl.Subscription.Session == null ||
                    monitoredItemsControl.Subscription.innerSubscription == null ||
                    monitoredItemsControl.MonitoredItemsList.SelectedItems.Count == 0)
                {
                    return;
                }

                // Determine the sampling interval being requested.
                int publishingInterval = 0;

                if (sender == toolStripMenuItem_PublishingInterval_200)
                {
                    publishingInterval = 200;
                }
                else if (sender == toolStripMenuItem_PublishingInterval_1000)
                {
                    publishingInterval = 1000;
                }
                else if (sender == toolStripMenuItem_PublishingInterval_2000)
                {
                    publishingInterval = 2000;
                }

                // Modify subscription.
                m_Server.ModifySubscription(monitoredItemsControl.Subscription, publishingInterval);

                // Update status label.
                toolStripStatusLabel.Text = "Setting publishing interval succeeded.";
            }
            catch (Exception exception)
            {
                // Update status label.
                toolStripStatusLabel.Text = "An exception occured while setting publishing interval: " + exception.Message;
                toolStripStatusLabel.Image = global::Siemens.OpcUA.Client.Properties.Resources.error;
            }
        }
        #endregion

        #region Event Handler
        void m_Server_CertificateEvent(CertificateValidator validator, CertificateValidationEventArgs e)
        {
            // Ask user if he wants to trust the certificate
            DialogResult result = MessageBox.Show(
                "Do you want to accept the untrusted server certificate: \n" +
                "\nSubject Name: " + e.Certificate.SubjectName.Name +
                "\nIssuer Name: " + e.Certificate.IssuerName.Name,
                "Untrusted Server Certificate",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // If the certificate is stored in the trust list, the user is not asked again
                e.Accept = true;
            }
            else
            {
                e.Accept = false;
            }
        }
        #endregion
    }
}