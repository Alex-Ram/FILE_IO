using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace FILE_IO
{
    static class Encryption__ // added the __ because I wanted to avoid collision
    {
        private static string Key = "lfkigobkhyrloijhgfdiookngfwqjklm";
        private static string IV = "kglbogdqplmtembc";



        public static string Encrypt(string plaintext)
        {
            // converts our plain text into bytes to actually allow the encryptor to work with it.
            byte[] plainTextByte = ASCIIEncoding.ASCII.GetBytes(plaintext);

            AesCryptoServiceProvider aes = new AesCryptoServiceProvider(); // allows us to use the AES abstract class to help us encrypt some data.
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            aes.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            byte[] encryptedData = encryptor.TransformFinalBlock(plainTextByte, 0, plainTextByte.Length);

            return Convert.ToBase64String(encryptedData);
        }

        public static string Decrypt(String encText)
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider(); // allows us to use the AES abstract class to help us encrypt some data.
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            aes.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            ICryptoTransform decryptor = aes.CreateDecryptor();

            byte[] encBytes = Convert.FromBase64String(encText);

            byte[] decrypted = decryptor.TransformFinalBlock(encBytes, 0, encBytes.Length);

            return ASCIIEncoding.ASCII.GetString(decrypted);
        }


    }
}
