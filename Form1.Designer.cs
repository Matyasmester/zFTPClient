namespace FTPClient
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
            this.IPAddressBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IsLocalhostBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PortBox = new System.Windows.Forms.NumericUpDown();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.UploadFileButton = new System.Windows.Forms.Button();
            this.UploadFolderButton = new System.Windows.Forms.Button();
            this.SharedFolderTreeView = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.DataPortBox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PortBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataPortBox)).BeginInit();
            this.SuspendLayout();
            // 
            // IPAddressBox
            // 
            this.IPAddressBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IPAddressBox.Location = new System.Drawing.Point(372, 16);
            this.IPAddressBox.Name = "IPAddressBox";
            this.IPAddressBox.Size = new System.Drawing.Size(303, 28);
            this.IPAddressBox.TabIndex = 0;
            this.IPAddressBox.TextChanged += new System.EventHandler(this.IPAddressBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(184, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server IP Address:";
            // 
            // IsLocalhostBox
            // 
            this.IsLocalhostBox.AutoSize = true;
            this.IsLocalhostBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IsLocalhostBox.Location = new System.Drawing.Point(460, 50);
            this.IsLocalhostBox.Name = "IsLocalhostBox";
            this.IsLocalhostBox.Size = new System.Drawing.Size(118, 29);
            this.IsLocalhostBox.TabIndex = 2;
            this.IsLocalhostBox.Text = "Localhost";
            this.IsLocalhostBox.UseVisualStyleBackColor = true;
            this.IsLocalhostBox.CheckedChanged += new System.EventHandler(this.IsLocalhostBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(710, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port:";
            // 
            // PortBox
            // 
            this.PortBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PortBox.Location = new System.Drawing.Point(769, 14);
            this.PortBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(120, 34);
            this.PortBox.TabIndex = 5;
            this.PortBox.Value = new decimal(new int[] {
            5555,
            0,
            0,
            0});
            // 
            // ConnectButton
            // 
            this.ConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ConnectButton.Location = new System.Drawing.Point(933, 16);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(232, 82);
            this.ConnectButton.TabIndex = 6;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // UploadFileButton
            // 
            this.UploadFileButton.Enabled = false;
            this.UploadFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UploadFileButton.Location = new System.Drawing.Point(653, 170);
            this.UploadFileButton.Name = "UploadFileButton";
            this.UploadFileButton.Size = new System.Drawing.Size(430, 126);
            this.UploadFileButton.TabIndex = 10;
            this.UploadFileButton.Text = "Upload file";
            this.UploadFileButton.UseVisualStyleBackColor = true;
            this.UploadFileButton.Click += new System.EventHandler(this.UploadFileButton_Click);
            // 
            // UploadFolderButton
            // 
            this.UploadFolderButton.Enabled = false;
            this.UploadFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UploadFolderButton.Location = new System.Drawing.Point(653, 347);
            this.UploadFolderButton.Name = "UploadFolderButton";
            this.UploadFolderButton.Size = new System.Drawing.Size(430, 126);
            this.UploadFolderButton.TabIndex = 11;
            this.UploadFolderButton.Text = "Upload folder";
            this.UploadFolderButton.UseVisualStyleBackColor = true;
            this.UploadFolderButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // SharedFolderTreeView
            // 
            this.SharedFolderTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SharedFolderTreeView.HotTracking = true;
            this.SharedFolderTreeView.Location = new System.Drawing.Point(12, 124);
            this.SharedFolderTreeView.Name = "SharedFolderTreeView";
            this.SharedFolderTreeView.Size = new System.Drawing.Size(566, 525);
            this.SharedFolderTreeView.TabIndex = 12;
            this.SharedFolderTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SharedFolderTreeView_AfterSelect);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(184, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Files on server";
            // 
            // DataPortBox
            // 
            this.DataPortBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataPortBox.Location = new System.Drawing.Point(769, 64);
            this.DataPortBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.DataPortBox.Name = "DataPortBox";
            this.DataPortBox.Size = new System.Drawing.Size(120, 34);
            this.DataPortBox.TabIndex = 14;
            this.DataPortBox.Value = new decimal(new int[] {
            5556,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(664, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Data Port:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1189, 672);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DataPortBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SharedFolderTreeView);
            this.Controls.Add(this.UploadFolderButton);
            this.Controls.Add(this.UploadFileButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.PortBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IsLocalhostBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IPAddressBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "FTP Client";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PortBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataPortBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IPAddressBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox IsLocalhostBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown PortBox;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button UploadFileButton;
        private System.Windows.Forms.Button UploadFolderButton;
        private System.Windows.Forms.TreeView SharedFolderTreeView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown DataPortBox;
        private System.Windows.Forms.Label label4;
    }
}

