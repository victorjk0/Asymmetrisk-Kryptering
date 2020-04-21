using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;


namespace Encryption_Sender.Cryptor
{
    class Encryptor
    {
        public byte[] EncryptData(RSACryptoServiceProvider rsa, byte[] dataToEnc)
        {
            return rsa.Encrypt(dataToEnc, false);
        }
    }
}
