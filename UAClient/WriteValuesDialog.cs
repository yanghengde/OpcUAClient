using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Opc.Ua;

namespace Siemens.OpcUA.Client
{
    public partial class WriteValuesDialog : Form
    {
        #region Construction
        public WriteValuesDialog()
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
        /// Keeps the current values.
        /// </summary>
        private DataValueCollection m_currentValues;
        #endregion

        #region Public Interfaces
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        /// <param name="server">The server instance.</param>
        /// <param name="itemCollection">The <see cref="System.EventArgs"/> Collection of items to display.</param>
        public void Show(Server server, ListViewItem[] itemCollection)
        {
            if (server == null) throw new ArgumentNullException("server");

            // Set server,
            m_Server = server;

            // Add the items to the listview.
            foreach (ListViewItem item in itemCollection)
            {
                this.listView.Items.Add(item);
            }

            // Fit the width of the columns to header size.
            this.listView.Columns[0].Width = -2;
            this.listView.Columns[1].Width = -2;
            this.listView.Columns[2].Width = -2;

            // Write the values.
            UpdateCurrentValues();

            // Display the control,
            Show();
            // and bring it to front.
            BringToFront();
        }
        #endregion

        /// <summary>
        /// Handles the Ok click event.
        /// Writes the values and then closes the dialog.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            // Write the values.
            WriteValues();

            // Close dialog.
            Close();
        }

        /// <summary>
        /// Write values without closing the dialog.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonApply_Click(object sender, EventArgs e)
        {
            // Write the values.
            WriteValues();

            // Display the values.
            UpdateCurrentValues();
        }

        /// <summary>
        /// Writes the values.
        /// </summary>
        private void WriteValues()
        {
            try
            {
                // Prepare call to ClientAPI.
                NodeIdCollection nodesToWrite = new NodeIdCollection(this.listView.Items.Count);
                DataValueCollection values = new DataValueCollection(this.listView.Items.Count);
                StatusCodeCollection results = null;
                int i = 0;

                foreach (ListViewItem item in this.listView.Items)
                {
                    // Values to write.
                    String sValue = (String)item.SubItems[0].Text;
                    
                    // Leave current value if write value is empty.
                    if (sValue.Length == 0)
                    {
                        i++;
                        continue;
                    }
                    Variant variant = new Variant(Convert.ChangeType(sValue, m_currentValues[i].Value.GetType()));

                    DataValue value = new DataValue(variant);
                    values.Add(value);

                    // NodeIds.
                    String sNodeId = item.SubItems[1].Text;
                    NodeId nodeId = new NodeId(sNodeId);
                    nodesToWrite.Add(nodeId);
                    
                    i++;
                }

                // Call to ClientAPI.
                m_Server.WriteValues(
                    nodesToWrite,
                    values,
                    out results);

                // Update status label.
                toolStripStatusLabel.Text = "Writing values succeeded.";
            }
            catch (Exception e)
            {
                // Update status label.
                toolStripStatusLabel.Text = "An exception occured while writing values: "
                    + e.Message;
            }
        }

        /// <summary>
        /// Writes and displays the new values.
        /// </summary>
        private void UpdateCurrentValues()
        {
            try
            {
                // Prepare call to ClientAPI.
                NodeIdCollection nodesToRead = new NodeIdCollection(this.listView.Items.Count);

                foreach (ListViewItem item in this.listView.Items)
                {
                    // NodeIds.
                    String sNodeId = item.SubItems[1].Text;
                    NodeId nodeId = new NodeId(sNodeId);
                    nodesToRead.Add(nodeId);
                }

                // Call to ClientAPI.
                m_Server.ReadValues(
                    nodesToRead,
                    out m_currentValues);

                int i = 0;
                foreach (ListViewItem item in this.listView.Items)
                {
                    // Update current value.
                    item.SubItems[2].Text = m_currentValues[i].Value.ToString();
                    i++;
                }

                // Update status label.
                toolStripStatusLabel.Text = "Updating current values succeeded.";
            }
            catch (Exception e)
            {
                // Update status label.
                toolStripStatusLabel.Text = "An exception occured while updating current values: "
                    + e.Message;
            }
        }

        /// <summary>
        /// Cancel writing values.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Close dialog.
            Close();
        }
    }
}
