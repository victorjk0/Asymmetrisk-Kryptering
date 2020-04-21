using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Encryption_Sender.Cryptor;
using Encryption_Sender.MySocket;

namespace Encryption_Sender
{
    class Controller
    {
        KeyManager keyManager = new KeyManager();
        Encryptor encryptor = new Encryptor();
        SocketClient sockClient = new SocketClient();

        public byte[] EncryptText(string text, string keyContainer)
        {
            //calls the Encrypter to encrypt a plaintext string, with given RSACryptoServiceProvider object.
            return encryptor.EncryptData(keyManager.FetchRSAKey(keyContainer),Encoding.Default.GetBytes(text));
        }

        public List<string> InitKeyStrings()
        {
            
            List<string> xmlReturn = new List<string>();
            XmlDocument xml = new XmlDocument();

            //inits a new key and gets the public key info
            xml.LoadXml(keyManager.CreateNewKey("KeyContainer"));
            
            //Selects the Modulus Node in the xml Document
            XmlNode nodeM = xml.DocumentElement.SelectSingleNode("/RSAKeyValue/Modulus");

            //Selects the Exponent Node in the xml Document
            XmlNode nodeE = xml.DocumentElement.SelectSingleNode("/RSAKeyValue/Exponent");

            //gets the value of the Modulus Node
            string Modulus = nodeM.InnerText;

            //Gets the value of the Exponent Node 
            string Exponent = nodeE.InnerText;

            xmlReturn.Add(Modulus);
            xmlReturn.Add(Exponent);

            return xmlReturn;
        }

        public void InitTcpClient(string input)
        {
            //starts the TCPSocketClient
            sockClient.ExecuteClient(input);
        }

        
        public void DelKey()
        {
            //Deletes the key from the given KeyContainer
            keyManager.DeleteKeyFromContainer("KeyContainer");
        }
    }
}
