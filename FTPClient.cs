using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FTPClient
{
    public class FTPClient : IDisposable
    {
        private IPEndPoint endPoint;

        private TcpClient client = new TcpClient();
        private TcpClient dataClient = new TcpClient();

        private StreamReader reader;
        private StreamWriter writer;

        private NetworkStream stream;
        private NetworkStream dataStream;

        private static readonly string SharingFolderName = "ToShare";
        private readonly string SharingFolderPath = Path.Combine(Directory.GetCurrentDirectory(), SharingFolderName);

        public FTPClient()
        {
            if (!Directory.Exists(SharingFolderPath)) Directory.CreateDirectory(SharingFolderPath);
            Directory.SetCurrentDirectory(SharingFolderPath);
        }

        public string Connect(IPAddress IP, int port, int dataPort)
        {
            endPoint = new IPEndPoint(IP, port);
            client.Connect(endPoint);

            stream = client.GetStream();

            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);

            MakeDataConnection(dataPort);

            return reader.ReadLine() + "\r\n";
        }

        public async Task<string> SendCommand(string command)
        {
            string[] cmdSplit = command.Split(new char[] { ' ' }, 2);

            string cmd = cmdSplit[0].ToLower();
            string arg = cmdSplit.Length > 1 ? cmdSplit[1] : null;

            writer.WriteAsync(command + "\r\n").Wait();
            writer.FlushAsync().Wait();

            if (cmd.Equals("get") || cmd.Equals("retr"))
            {
                await GetCopyOfFile(arg);
            }
            if (cmd.Equals("upload")) UploadFile(arg);
            if (cmd.Equals("fupload")) UploadFolder(arg);
            
            while (!stream.DataAvailable) await Task.Delay(40);

            char[] buffer = new char[client.Available];

            while (stream.DataAvailable) await reader.ReadAsync(buffer, 0, buffer.Length);

            return new string(buffer);
        }

        public void Dispose()
        {
            client.Close();
            dataClient.Close();
            
            reader?.Dispose();
            writer?.Dispose();

            stream?.Dispose();
            dataStream?.Dispose();
        }

        public bool IsConnected()
        {
            return client.Connected;
        }

        public bool IsDataConnected()
        {
            return dataClient.Connected;
        }

        private void UploadFile(string path)
        {
            FileInfo info = new FileInfo(path);

            byte[] encoded = EncodeSingleFile(info);

            SendBytesToDataStream(encoded);
        }

        private void UploadFolder(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            string fileName = dirInfo.Name + ".zip";

            string archivePath = Path.Combine(SharingFolderPath, fileName);

            if (File.Exists(archivePath)) File.Delete(archivePath);

            ZipFile.CreateFromDirectory(path, archivePath);

            UploadFile(archivePath);

            File.Delete(archivePath);
        }

        private byte[] EncodeSingleFile(FileInfo info)
        {
            FileStream stream = info.OpenRead();

            byte[] buffer = new byte[stream.Length];

            stream.Read(buffer, 0, buffer.Length);

            stream.Dispose();

            return buffer;
        }

        private void MakeDataConnection(int dataPort)
        {
            if(dataClient.Connected) return;

            dataClient.Connect(endPoint.Address, dataPort);
            dataStream = dataClient.GetStream();
        }

        private void SendBytesToDataStream(byte[] bytes)
        {
            int bufferSize = 1024;

            int dataLength = bytes.Length;

            byte[] dataLengthBytes = BitConverter.GetBytes(dataLength);

            dataStream.Write(dataLengthBytes, 0, dataLengthBytes.Length);

            int bSent = 0;
            int bLeft = dataLength;

            while (bLeft > 0)
            {
                int currentSize = Math.Min(bLeft, bufferSize);

                dataStream.Write(bytes, bSent, currentSize);

                bSent += currentSize;
                bLeft -= currentSize;
            }
        }

        private async Task GetCopyOfFile(string name)
        {
            int bufferSize = 1024;

            byte[] fileSizeBytes = new byte[4];
            dataStream.ReadAsync(fileSizeBytes, 0, 4).Wait();

            int fileSize = BitConverter.ToInt32(fileSizeBytes, 0);

            int bytesLeft = fileSize;
            byte[] fileContent = new byte[fileSize];

            int bytesRead = 0;

            while(bytesLeft > 0)
            {
                int currentSize = Math.Min(bytesLeft, bufferSize);

                if(dataClient.Available < currentSize) currentSize = dataClient.Available;

                await dataStream.ReadAsync(fileContent, bytesRead, currentSize);

                bytesRead += currentSize;
                bytesLeft -= currentSize;
            }

            File.WriteAllBytes(name, fileContent);
        }
    }
}
