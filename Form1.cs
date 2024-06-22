using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPClient
{
    public partial class MainForm : Form
    {
        FTPClient client;

        public MainForm()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Dispose();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            client = new FTPClient();
        }

        private void IPAddressBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void IsLocalhostBox_CheckedChanged(object sender, EventArgs e)
        {
            IPAddressBox.Enabled = !IsLocalhostBox.Checked;
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            IPAddress IP = IsLocalhostBox.Checked ? IPAddress.Parse("127.0.0.1") : IPAddress.Parse(IPAddressBox.Text);
            int port = (int)PortBox.Value;

            OutputBox.Text = client.Connect(IP, port);
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            OutputBox.Text += await client.SendCommand(CommandBox.Text) + Environment.NewLine;
        }

        private async void UploadFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            
            DialogResult result = dialog.ShowDialog(owner: this);

            if(result == DialogResult.OK)
            {
                FileInfo info = new FileInfo(dialog.FileName);
                OutputBox.Text += await client.SendCommand("UPLOAD " + info.FullName) + Environment.NewLine;
            }
            else
            {
                MessageBox.Show("Error selecting file.");
                return;
            }
        }
    }
}
