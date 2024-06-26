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
        private FTPClient client;

        private const int FILE_IMG_INDEX = 0;
        private const int FOLDER_IMG_INDEX = 1;

        public MainForm()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;

            Image file_img = Image.FromFile(@"assets\file_icon.png");
            Image folder_img = Image.FromFile(@"assets\folder_icon.png");

            ImageList list = new ImageList();
            list.Images.Add(file_img);
            list.Images.Add(folder_img);

            SharedFolderTreeView.ImageList = list;
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

        private async void ConnectButton_Click(object sender, EventArgs e)
        {
            IPAddress IP = IsLocalhostBox.Checked ? IPAddress.Parse("127.0.0.1") : IPAddress.Parse(IPAddressBox.Text);
            int port = (int)PortBox.Value;
            int dataPort = (int)DataPortBox.Value;

            try { MessageBox.Show(client.Connect(IP, port, dataPort)); }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to client:\n " + ex.Message);
                return;
            }
            bool isConnected = client.IsConnected();

            UploadFileButton.Enabled = isConnected;
            UploadFolderButton.Enabled = isConnected;

            await PopulateTreeView();
        }

        private async Task PopulateTreeView()
        {
            SharedFolderTreeView.Nodes.Clear();
            
            string text = await client.SendCommand("RECDIR");

            string[] lines = text.Split(new string[] {Environment.NewLine}, StringSplitOptions.None);

            string rootDirName = lines[0];

            TreeNode root = new TreeNode(rootDirName);
            root.ImageIndex = FOLDER_IMG_INDEX;
            root.SelectedImageIndex = FOLDER_IMG_INDEX;

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
                string name = split[1];
                
                TreeNode node = new TreeNode(name);

                if (Path.GetExtension(name).Equals(string.Empty))
                {
                    node.ImageIndex = FOLDER_IMG_INDEX;
                    node.SelectedImageIndex = FOLDER_IMG_INDEX;
                }
                else
                {
                    node.ImageIndex = FILE_IMG_INDEX;
                    node.SelectedImageIndex = FILE_IMG_INDEX;
                }

                if (level != prevLevel) 
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
                MessageBox.Show(await client.SendCommand("UPLOAD " + info.FullName));
            }
            else
            {
                MessageBox.Show("Error selecting file.");
                return;
            }

            await PopulateTreeView();
        }

        private void SharedFolderTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = false;

            DialogResult result = dialog.ShowDialog(owner: this);

            if(result == DialogResult.OK)
            {
                string selectedPath = dialog.SelectedPath;
                MessageBox.Show(await client.SendCommand("FUPLOAD " + selectedPath));
            }

            await PopulateTreeView();
        }
    }
}
