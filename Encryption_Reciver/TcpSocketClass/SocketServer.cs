using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Encryption_Reciver.MySocket
{
    class SocketServer
    {
        const int PORT = 5999;

        const string SERVER_IP = "127.0.0.1";

        public string ExecuteServer()
        {
            //inits localhost with server ip
            IPAddress localhost = IPAddress.Parse(SERVER_IP);
            
            //inits a listner for localhost at port 5999
            TcpListener tcpListener = new TcpListener(localhost, PORT);

            tcpListener.Start();

            string dataRecived = null;

            while (true)
            {
                //inits a tcpClient that accepts incoming connections
                TcpClient tcpClient = tcpListener.AcceptTcpClient();

                //inits a network stream that gets incomming stream from tcpClient
                NetworkStream networkStream = tcpClient.GetStream();

                //sets a buffer with the buffer size as the same as the tcpClients reciverBuffer
                byte[] buffer = new byte[tcpClient.ReceiveBufferSize];

                //sets bytesRead to the number of bytes recived from networkStream
                int bytesRead = networkStream.Read(buffer, 0, tcpClient.ReceiveBufferSize);

                //Converts the byte array that was recived via networkStream into a string
                dataRecived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                tcpClient.Close();

                if (dataRecived != null)
                {
                    break;
                }


            }

            return dataRecived;
        }
    }
}
