using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RSA2
{
    public class ExampleRSA
    {

        public string publicKey = "";
        private string privateKey = "";

        public void GenKey()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);

            privateKey = rsa.ToXmlString(true);
            publicKey = rsa.ToXmlString(false);
            /*using (StreamWriter writer = new StreamWriter(@"D:\Users\tee.pi\Desktop\dr4ft\RSA\rsa-private.xml")) //This file should be kept secret...
            {
                System.Diagnostics.Debug.WriteLine("---------------private");
                System.Diagnostics.Debug.WriteLine(rsa.ToXmlString(true));

                writer.WriteLine(rsa.ToXmlString(true));
            }
            using (StreamWriter writer = new StreamWriter(@"D:\Users\tee.pi\Desktop\dr4ft\RSA\rsa-public.xml"))
            {
                System.Diagnostics.Debug.WriteLine("---------------public ");
                System.Diagnostics.Debug.WriteLine(rsa.ToXmlString(false));
                writer.WriteLine(rsa.ToXmlString(false));
            }*/
        }

        public string Encryption(string strText)
        {
            var testData = Encoding.UTF8.GetBytes(strText);

            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    // client encrypting data with public key issued by server                    
                    rsa.FromXmlString(publicKey.ToString());

                    var encryptedData = rsa.Encrypt(testData, true);

                    var base64Encrypted = Convert.ToBase64String(encryptedData);

                    return base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        public string Decryption(string strText)
        {

            var testData = Encoding.UTF8.GetBytes(strText);

            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    var base64Encrypted = strText;

                    // server decrypting data with private key                    
                    rsa.FromXmlString(privateKey);

                    var resultBytes = Convert.FromBase64String(base64Encrypted);
                    var decryptedBytes = rsa.Decrypt(resultBytes, true);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

    }//end class

}

