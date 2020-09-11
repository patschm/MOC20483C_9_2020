using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Confidentiality
{
    class Program
    {
        private static byte[] sharedKey;
        private static byte[] iv;

        static void Main(string[] args)
        {
            Symmetric();
            //Asymmetric();
        }

        private static void Symmetric()
        {
            AesManaged alg = new AesManaged();
            sharedKey = alg.Key;
            iv = alg.IV;
            
            // Sender
            string document = "Hello World";
            byte[] cipher;
            using (MemoryStream mem = new MemoryStream())
            {
                using (CryptoStream cryp = new CryptoStream(mem, 
                                                                        alg.CreateEncryptor(), 
                                                                        CryptoStreamMode.Write))
                {
                    using (StreamWriter writer = new StreamWriter(cryp))
                    {
                        writer.WriteLine(document);
                    }
                }
                cipher = mem.ToArray();
            }
            Console.WriteLine(Encoding.UTF8.GetString(cipher));


            // Recepient
            AesManaged rAlg = new AesManaged();
            rAlg.Key = sharedKey;
            rAlg.IV = iv;

            using(MemoryStream mem = new MemoryStream(cipher))
            {
                using(CryptoStream cryp = new CryptoStream(mem, 
                                                                           rAlg.CreateDecryptor(), 
                                                                           CryptoStreamMode.Read))
                {
                    using (StreamReader rdr = new StreamReader(cryp))
                    {
                        string data = rdr.ReadLine();
                        Console.WriteLine(data);
                    }
                }
            }
        }

        private static void Asymmetric()
        {
            // Recepient buys a pub & private key pair
            RSACryptoServiceProvider alg = new RSACryptoServiceProvider();
            string pubKey = alg.ToXmlString(false);
            string privKey = alg.ToXmlString(true);


            // Sender receives the public key and creates a document (or whatever)
            string document = "Hello World";
            RSACryptoServiceProvider sAlg = new RSACryptoServiceProvider();
            sAlg.FromXmlString(pubKey);
            byte[] data = Encoding.UTF8.GetBytes(document);
            byte[] cipher = sAlg.Encrypt(data, true);

            Console.WriteLine(Encoding.UTF8.GetString(cipher));

            // Send cipher to recepient
            RSACryptoServiceProvider rAlg = new RSACryptoServiceProvider();
            rAlg.FromXmlString(privKey);
            byte[] orgiData = rAlg.Decrypt(cipher, true);
            Console.WriteLine(Encoding.UTF8.GetString(orgiData));


        }
    }
}
