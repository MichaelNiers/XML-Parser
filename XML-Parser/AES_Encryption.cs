using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace XML_Projekt
{
    public class AesEncryptor
    {
        RijndaelManaged myRijndael = new RijndaelManaged();
        public AesEncryptor()
        {
            myRijndael.Key = System.Text.Encoding.UTF8.GetBytes("!%df46SGj3dH$20&");
            myRijndael.IV = System.Text.Encoding.UTF8.GetBytes("1234567890123456");
        }

        private byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (RijndaelManaged rijAlg = new RijndaelManaged()
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            })
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        private string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }

        public string Encrypt(string text)
        {
            try
            {
                byte[] encrypted = EncryptStringToBytes(text, myRijndael.Key, myRijndael.IV);
                return Convert.ToBase64String(encrypted);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Encrypt(string text, string key)
        {
            try
            {
                myRijndael.Key = System.Text.Encoding.UTF8.GetBytes(key);
                byte[] encrypted = EncryptStringToBytes(text, myRijndael.Key, myRijndael.IV);
                return Convert.ToBase64String(encrypted);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Decrypt(string text)
        {
            try
            {
                byte[] encrypted = Convert.FromBase64String(text);
                return DecryptStringFromBytes(encrypted, myRijndael.Key, myRijndael.IV);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Decrypt(string text, string key)
        {
            try
            {
                myRijndael.Key = System.Text.Encoding.UTF8.GetBytes(key);
                byte[] encrypted = Convert.FromBase64String(text);
                return DecryptStringFromBytes(encrypted, myRijndael.Key, myRijndael.IV);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
