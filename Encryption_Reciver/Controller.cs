using System;
using System.Collections.Generic;
using System.Text;
using Encryption_Reciver.MySocket;

namespace Encryption_Reciver
{
    class Controller
    {
        Decryptor decryptor = new Decryptor();
        SocketServer sockServ = new SocketServer();

        public byte[] DecryptText(string text)
        {
            //calls the Decrypter to decrypt a encryptred string, with given KeyContainer
            return decryptor.DecryptData(Convert.FromBase64String(text), "KeyContainer");
        }

        public string InitTcpServer()
        {
            //starts our TCPSocketServer
            return sockServ.ExecuteServer();
        }
    }
}
