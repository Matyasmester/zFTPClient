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

        private async Task PopulateTreeView()
        {
            string text = await client.SendCommand("RECDIR");

            string[] lines = text.Split(new string[] {Environment.NewLine}, StringSplitOptions.None);

            string rootDirName = lines[0];

            TreeNode root = new TreeNode(rootDirName);

            List<KeyValuePair<int, TreeNode>> rootNodesByLevel = new List<KeyValuePair<int, TreeNode>>();

            rootNodesByLevel.Add(new KeyValuePair<int, TreeNode>(0, root));

            SharedFolderTreeView.Nodes.Add(root);

            TreeNode prevNode = root;

            int prevLevel = 0;

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];

                if(line.Equals(string.Empty) || line.Contains("\0")) continue;

                string[] split = line.Split(':');
                int level = Convert.ToInt32(split[0]);
                
                TreeNode node = new TreeNode(split[1]);

                if (level > prevLevel) 
                {
                    prevLevel = level;
                    rootNodesByLevel.Add(new KeyValuePair<int, TreeNode>(level, prevNode));
                }

                rootNodesByLevel.First(x => x.Key == level).Value.Nodes.Add(node);

                prevNode = node;
            }
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

        private void SharedFolderTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            SharedFolderTreeView.Nodes.Clear();
            await PopulateTreeView();
        }
    }
}
