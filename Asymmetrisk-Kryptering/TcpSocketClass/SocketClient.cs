using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Encryption_Sender.MySocket
{
    class SocketClient
    {
        const int PORT = 5999;
        const string SERVER_IP = "127.0.0.1";

        public void ExecuteClient(string userMsg)
        {
            //starts a tcpClient to connect to given server and on given port.
            TcpClient tcpClient = new TcpClient(SERVER_IP, PORT);

            //starts a NetworkStream for sending data to the server
            NetworkStream networkStream = tcpClient.GetStream();


            //converts the message to a byte array.
            byte[] baSend = ASCIIEncoding.ASCII.GetBytes(userMsg);

            //Sends message as a byte array to the TCPSocketServer
            networkStream.Write(baSend, 0, baSend.Length);

            tcpClient.Close();
        }
    }
}
