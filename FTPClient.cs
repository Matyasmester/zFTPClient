using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

        private StreamReader reader;
        private StreamWriter writer;

        private NetworkStream stream;

        public FTPClient()
        {
            
        }

        public string Connect(IPAddress IP, int port)
        {            
            endPoint = new IPEndPoint(IP, port);
            client.Connect(endPoint);

            stream = client.GetStream();

            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);

            return reader.ReadLine() + "\r\n";
        }

        public async Task<string> SendCommand(string command)
        {
            writer.WriteAsync(command + "\r\n").Wait();
            writer.FlushAsync().Wait();

            char[] buffer = new char[1024];
            
            while(!stream.DataAvailable)
            {
                await Task.Delay(40);
            }

            while(stream.DataAvailable) await reader.ReadAsync(buffer, 0, buffer.Length - 1);

            return new string(buffer);
        }

        public void Dispose()
        {
            client.Dispose();
            reader.Dispose();
            writer.Dispose();
        }
    }
}
