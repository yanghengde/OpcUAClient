using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Opc.Ua.Client;
using Opc.Ua;
using Siemens.OpcUA;

namespace Siemens.OpcUA.Client
{
    public partial class MonitoredItemsControl : UserControl
    {
        /// <summary>
        /// Event handler for the event that the status label of the main form has to be updated.
        /// </summary>
        public delegate void UpdateStatusLabelEventHandler(string strMessage, bool bSuccess);
        /// <summary>
        /// Use the delegate as event.
        /// </summary>
        public event UpdateStatusLabelEventHandler UpdateStatusLabel = null;
        /// <summary>
        /// An exception was thrown.
        /// </summary>
        public void OnUpdateStatusLabel(string strMessage, bool bSuccess)
        {
            if (UpdateStatusLabel != null)
            {
                UpdateStatusLabel(strMessage, bSuccess);
            }
        }
        
        #region Construction
        public MonitoredItemsControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Fields
        /// <summary>
        /// Provides access to OPC UA server.
        /// </summary>
        private Server m_Server;
        /// <summary>
        /// Provides access to the subscription being created.
        /// </summary>
        private Subscription m_Subscription;
        #endregion

        #region Properties
        // Server
        public Server Server
        {
            get { return m_Server; }
            set { m_Server = value; }
        }
        // Subscription
        public Subscription Subscription
        {
            get { return m_Subscription; }
        }
        #endregion        

        #region Public Interfaces
        public void RemoveSubscription()
        {
            m_Server.RemoveSubscription(m_Subscription);
            m_Subscription = null;
        }
        #endregion

        #region User Actions and Event Handling
        /// <summary>
        /// Finishes a drag and drop action whereas this control is used as target.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MonitoredItems_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // Retrieve the event data and create the according nodeid. 
                String sNodeId = (String)e.Data.GetData(typeof(System.String));
                NodeId nodeId = new NodeId(sNodeId);

                // Create the subscription if it does not already exist.
                if (m_Subscription == null)
                {
                    m_Subscription = m_Server.AddSubscription(100);
                }

                // Add the attribute name/value to the list view.
                ListViewItem item = new ListViewItem(sNodeId);
                object serverHandle = null;

                // Prepare further columns.
                item.SubItems.Add("100"); // Sampling interval by default.
                item.SubItems.Add(String.Empty);
                item.SubItems.Add(String.Empty);
                item.SubItems.Add(String.Empty);
                item.SubItems.Add(String.Empty);
                item.SubItems.Add(String.Empty);

                try
                {
                    // Add the item and apply any changes to it. 
                    m_Subscription.AddDataMonitoredItem(nodeId, item, ClientApi_ValueChanged, 100, out serverHandle);
                    
                    // Update status label.
                    OnUpdateStatusLabel("Adding monitored item succeeded for NodeId:" + 
                        nodeId.ToString(), true);
                }
                catch (ServiceResultException monitoredItemResult)
                {
                    item.SubItems[5].Text = monitoredItemResult.StatusCode.ToString();

                    // Update status label.
                    OnUpdateStatusLabel("An exception occured while adding an item: " + 
                        monitoredItemResult.Message, false);
                }

                item.Tag = serverHandle;
                MonitoredItemsLV.Items.Add(item);

                // Fit column width to the longest item and add a few pixel:
                MonitoredItemsLV.Columns[0].Width = -1;
                MonitoredItemsLV.Columns[0].Width += 15;
                // Fit column width to the column content:
                MonitoredItemsLV.Columns[1].Width = -2;
                MonitoredItemsLV.Columns[5].Width = -2;
                // Fix settings:
                MonitoredItemsLV.Columns[2].Width = 95;
                MonitoredItemsLV.Columns[3].Width = 75;
                MonitoredItemsLV.Columns[4].Width = 75;
            }
            catch (Exception exception)
            {
                // Update status label.
                OnUpdateStatusLabel("An exception occured while creating a subscription: " +
                        exception.Message, false);
            }
        }

        /// <summary>
        /// Callback to receive data changes from an UA server.
        /// </summary>
        /// <param name="clientHandle">The source of the event.</param>
        /// <param name="value">The instance containing the changed data.</param>
        private void ClientApi_ValueChanged(object clientHandle, DataValue value)
        {
            // We have to call an invoke method. 
            if (this.InvokeRequired)
            {
                // Asynchronous execution of the valueChanged delegate.
                this.BeginInvoke(new valueChanged(ClientApi_ValueChanged), clientHandle, value);
                return;
            }

            // Get the according item.
            ListViewItem item = (ListViewItem)clientHandle;

            // Set current value, status code and timestamp.
            item.SubItems[2].Text = Utils.Format("{0}", value.Value);
            item.SubItems[3].Text = Utils.Format("{0}", value.StatusCode);
            item.SubItems[4].Text = Utils.Format("{0:HH:mm:ss.fff}", value.SourceTimestamp.ToLocalTime());
        }

        /// <summary>
        /// Handles the drag over event of the control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MonitoredItems_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// Handles the click event of the MonitoringMenu_SamplingInterval_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MonitoringMenu_SamplingInterval_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if operation is currently allowed.
                if (m_Subscription.Session == null || m_Subscription.innerSubscription == null || MonitoredItemsLV.SelectedItems.Count == 0)
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

                for (int ii = 0; ii < MonitoredItemsLV.SelectedItems.Count; ii++)
                {
                    MonitoredItem monitoredItem = MonitoredItemsLV.SelectedItems[ii].Tag as MonitoredItem;

                    if (monitoredItem != null)
                    {
                        monitoredItem.SamplingInterval = (int)samplingInterval;
                        itemsToChange.Add(monitoredItem);
                        
                        // Apply the changes to the server.
                        m_Subscription.ModifyMonitoredItem(monitoredItem);
                    }

                    // Update the display.
                    MonitoredItemsLV.SelectedItems[ii].SubItems[5].Text = String.Empty;

                    MonitoredItemsLV.SelectedItems[ii].SubItems[1].Text = samplingInterval.ToString();

                    if (ServiceResult.IsBad(itemsToChange[ii].Status.Error))
                    {
                        MonitoredItemsLV.SelectedItems[ii].SubItems[5].Text = itemsToChange[ii].Status.Error.StatusCode.ToString();
                    }
                }

                // Update status label.
                OnUpdateStatusLabel("Setting sampling interval succeeded.", true);
            }
            catch (Exception exception)
            {
                // Update status label.
                OnUpdateStatusLabel("An exception occured while setting sampling interval: " +
                        exception.Message, false);
            }
        }

        /// <summary>
        /// Handles the click event of the MonitoringMenu_PublishingInterval_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MonitoringMenu_PublishingInterval_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if operation is currently allowed.
                if (m_Subscription.Session == null || m_Subscription.innerSubscription == null || MonitoredItemsLV.SelectedItems.Count == 0)
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

                // Apply changes to server.
                m_Server.ModifySubscription(m_Subscription, publishingInterval);

                // Update status label.
                OnUpdateStatusLabel("Setting publishing interval succeeded.", true);
            }
            catch (Exception exception)
            {
                // Update status label.
                OnUpdateStatusLabel("An exception occured while setting publishing interval: " +
                    exception.Message, false);
            }
        }

        /// <summary>
        /// Handles the click event of the MonitoringMenu_WriteValues_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param> 
        private void MonitoringMenu_WriteValues_Click(object sender, EventArgs e)
        {
            // Prepare ListViewItem collection of selected items.
            ListViewItem[] itemCollection;
            itemCollection = null;
            Array.Resize(ref itemCollection, this.MonitoredItemsLV.SelectedItems.Count);
            int i = 0;

            foreach (ListViewItem selectedItem in this.MonitoredItemsLV.SelectedItems)
            {
                // Create new item for the write values dialog and set nodeid.
                String sNodeId = selectedItem.SubItems[0].Text;
                // Create empty subitem. 
                ListViewItem item = new ListViewItem("");

                // Set nodeid.
                item.SubItems.Add(selectedItem.SubItems[0].Text);

                // Set current value.
                item.SubItems.Add(selectedItem.SubItems[2].Text);

                // Add item to collection.
                itemCollection[i] = item;
                i++;
            }

            // Show write values dialog.
            try
            {
                new WriteValuesDialog().Show(m_Server, itemCollection);
            }
            catch (Exception exception)
            {
                // Update status label.
                OnUpdateStatusLabel("An exception occured while writing values: " +
                    exception.Message, false);
            }
        }

        /// <summary>
        /// Handles the click event of the MonitoringMenu_RemoveItems_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MonitoringMenu_RemoveItems_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (m_Subscription.Session == null || m_Subscription.innerSubscription == null || MonitoredItemsLV.SelectedItems.Count == 0)
                {
                    return;
                }

                // Collect the items to delete.
                List<ListViewItem> itemsToDelete = new List<ListViewItem>();

                for (int ii = 0; ii < MonitoredItemsLV.SelectedItems.Count; ii++)
                {
                    MonitoredItem monitoredItem = MonitoredItemsLV.SelectedItems[ii].Tag as MonitoredItem;

                    if (monitoredItem != null)
                    {
                        m_Subscription.RemoveMonitoredItem(monitoredItem);
                        itemsToDelete.Add(MonitoredItemsLV.SelectedItems[ii]);
                    }
                }

                // Remove item(s).
                for (int ii = 0; ii < itemsToDelete.Count; ii++)
                {
                    MonitoredItem monitoredItem = itemsToDelete[ii].Tag as MonitoredItem;

                    // Check the status.
                    if (ServiceResult.IsBad(monitoredItem.Status.Error))
                    {
                        itemsToDelete[ii].SubItems[5].Text = monitoredItem.Status.Error.StatusCode.ToString();
                        continue;
                    }

                    itemsToDelete[ii].Remove();
                }

                // Fit column width.
                // NodeId.
                MonitoredItemsLV.Columns[0].Width = -2;
                // Error.
                MonitoredItemsLV.Columns[5].Width = -2;

                // Update status label.
                OnUpdateStatusLabel("Removing monitored items succeeded.", true);
            }
            catch (Exception exception)
            {
                // Update status label.
                OnUpdateStatusLabel("An exception occured while removing monitored items: " +
                    exception.Message, false);
            }
        }
        #endregion
    }
}
