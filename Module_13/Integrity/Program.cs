using System;
using System.Security.Cryptography;
using System.Text;

namespace Integrity
{
    class Program
    {
        // Make sure only sender and recepient knows this secret.
        private static byte[] salt;

        static void Main(string[] args)
        {
            //Symmetric();
            Asymmetric();
        }

        private static void Asymmetric()
        {
            // Sender
            string document = "Hello World";
            DSACryptoServiceProvider alg = new DSACryptoServiceProvider();
            string publicKey = alg.ToXmlString(false);
            Console.WriteLine(publicKey);
            byte[] hash = CreateHash(document);
            byte[] digitalSignature = alg.SignHash(hash, "SHA1");

            // ED at work
            document += ".";

            // Send it to recepient
            bool isOK = VerifySignature(document, digitalSignature, publicKey);
            Console.WriteLine(isOK ? "OK" : "NOT OK");
        }

        private static bool VerifySignature(string document, byte[] digitalSignature, string publicKey)
        {
            DSACryptoServiceProvider alg = new DSACryptoServiceProvider();
            alg.FromXmlString(publicKey);
            byte[] hash = CreateHash(document);
            bool isOK = alg.VerifyHash(hash, "SHA1", digitalSignature);
            return isOK;
        }

        private static void Symmetric()
        {
            // Sender
            string document = "Hello World";
            byte[] hash = CreateHash(document);

            // ED tries to hack
            document += "!";
            //HMACSHA1 alg = new HMACSHA1();
            //byte[] edbuffer = Encoding.UTF8.GetBytes(document);
            //byte[] edhash = alg.ComputeHash(edbuffer);

            // Recepient
            bool isOk = CheckDocument(document, hash);
            Console.WriteLine(isOk ? "OK" : "NOT OK");
        }

        private static bool CheckDocument(string document, byte[] hash)
        {
            //SHA1Managed alg = new SHA1Managed();
            HMACSHA1 alg = new HMACSHA1();
            alg.Key = salt;
            byte[] buffer = Encoding.UTF8.GetBytes(document);
            byte[] hash2 = alg.ComputeHash(buffer);
            for(int i = 0; i < hash.Length; i++)
            {
                if (hash[i] != hash2[i]) return false;
            }

            return true;
        }

        private static byte[] CreateHash(string document)
        {
            // Uses underlying c-library
            //SHA1CryptoServiceProvider alg = new SHA1CryptoServiceProvider();
            // Rewritten in managed code (.net)
            SHA1Managed alg = new SHA1Managed();
            //HMACSHA1 alg = new HMACSHA1();
            //salt = alg.Key;
            byte[] buffer = Encoding.UTF8.GetBytes(document);
            byte[] hash = alg.ComputeHash(buffer);
            
            Console.WriteLine(Convert.ToBase64String(hash));
            
            return hash;
        }
    }
}
