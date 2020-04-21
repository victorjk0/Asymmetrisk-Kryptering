using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Encryption_Reciver
{


    //TODO : Make it use The KeyManager class. like the Encryptor class
    class Decryptor
    {

        //Decrypts given data with key in given Key Container
        public byte[] DecryptData(byte[] dataToDec, string KeyContainer)
        {

            //inits CpsPrarameters with RSA compatible provider
            CspParameters cspParameters = new CspParameters(1);

            //sets the Key Container to use.
            cspParameters.KeyContainerName = KeyContainer;

            //inits the RSACryptoServiceProvider object with encryption byte set to 2048 and the CspParameters
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048, cspParameters);

            //Stores the key in the container.
            rsa.PersistKeyInCsp = false;


            return rsa.Decrypt(dataToDec, false);
        }

        
    }
}
