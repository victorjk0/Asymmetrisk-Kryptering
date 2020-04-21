using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Encryption_Sender
{
    class KeyManager
    {

        //TODO : Make it a class library 

        public RSACryptoServiceProvider FetchRSAKey(string containerName)
        {
            //inits CpsPrarameters with RSA compatible provider
            CspParameters cspParameters = new CspParameters(1);

            ////sets the Key Container to use.
            cspParameters.KeyContainerName = containerName;

            //inits the RSACryptoServiceProvider object with the CspParameters
            RSACryptoServiceProvider rsaCrypto = new RSACryptoServiceProvider(cspParameters);

            return rsaCrypto;
        }

        public string CreateNewKey(string containerName)
        {
            //inits CpsPrarameters with RSA compatible provider
            CspParameters cspParameters = new CspParameters(1);

            ////sets the Key Container to use.
            cspParameters.KeyContainerName = containerName;

            //sets the cspParameter to use MachineKeyStore
            cspParameters.Flags = CspProviderFlags.UseMachineKeyStore;

            //Sets the key Container use a microsoft built-in key container
            cspParameters.ProviderName = "Microsoft Strong Cryptographic Provider";

            //inits the RSACryptoServiceProvider object with the CspParameters
            RSACryptoServiceProvider rsaCrypto = new RSACryptoServiceProvider(cspParameters);

            //Stores the key in the container
            rsaCrypto.PersistKeyInCsp = true;

            //returns public key information as xml
            return rsaCrypto.ToXmlString(false);
        }
        
        public void DeleteKeyFromContainer(string containerName)
        {
            //inits CpsPrarameters with RSA compatible provider
            CspParameters cspParameters = new CspParameters();

            ////sets the Key Container to use.
            cspParameters.KeyContainerName = containerName;

            //inits the RSACryptoServiceProvider object with the CspParameters
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParameters);

            //Deletes the key from the container
            rsa.PersistKeyInCsp = false;

            //Releases all resources used by the rsa object.
            rsa.Clear();
        }
    }
}
