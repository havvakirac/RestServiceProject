using RestService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace RestService.Controllers
{
    public class EncryptionDecryption
    {
        /// <summary>
        /// Kullanıcının Passwordunu SHA256 kullanarak encryption işlemi
        /// </summary>
        /// <param name="paswrd"></param>
        /// <returns></returns>       
        public string Encryption(string password)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
    }
}


/// <summary>
/// DBye kaydedilen şifrelenmiş kullanıcı Passwordunu deşifre eden metod
/// </summary>
/// <param name="encPassword"></param>
/// <returns>encPassword=çözülmüş şifre</returns>
//public string Decryption(string encPassword)
//    {
//         ///readonly string hash = "fx0le%h";
//        string ps = string.Empty;

//        byte[] data = Convert.FromBase64String(encPassword);

//        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
//        {
//            byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
//            using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
//            {
//                ICryptoTransform transform = tripDes.CreateDecryptor();
//                byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
//                encPassword = UTF8Encoding.UTF8.GetString(result);
//            }
//        }
//        return encPassword;
//    }




//public string Encryption(string paswrd)
//{
//    byte[] data = UTF8Encoding.UTF8.GetBytes(paswrd);
//    using (MD5CryptoServiceProvider md5=new MD5CryptoServiceProvider())
//    {
//        byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
//        using (TripleDESCryptoServiceProvider tripDes=new TripleDESCryptoServiceProvider() { Key=keys, Mode= CipherMode.ECB, Padding=PaddingMode.PKCS7 })
//        {
//            ICryptoTransform transform = tripDes.CreateEncryptor();
//            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
//            paswrd = Convert.ToBase64String(result, 0, result.Length);
//        }
//    }
//  return paswrd;
//}