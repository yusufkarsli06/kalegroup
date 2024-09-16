
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Common.Helper
{
    public class HashHelper
    {
        public static string ComputeSha256Hash(string rawData)
        {

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string DecryptStringFromBase64_Aes(string input, string password)
        {
            byte[] passwordBytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
            byte[] IV = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
            byte[] cipherText = Convert.FromBase64String(input);

            string plaintext;

            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = passwordBytes;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption. 
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;
        }

        public static string IsValidPassword(string password)
        {
            // 1. Minimum uzunluk kontrolü
            if (password.Length < 8)
            {
                return "Parola en az 8 karakter uzunluğunda olmalıdır.";

            }

            // 2. Büyük harf, küçük harf, rakam ve özel karakter kontrolü
            if (!password.Any(char.IsUpper))
            {
                return "Parola en az bir büyük harf içermelidir.";

            }

            if (!password.Any(char.IsLower))
            {
                return "Parola en az bir küçük harf içermelidir.";

            }

            if (!password.Any(char.IsDigit))
            {
                return "Parola en az bir rakam içermelidir.";

            }
            // Özel karakter kontrolü
            if (!password.Any(ch => !char.IsLetterOrDigit(ch))) 
            {
                return "Parola en az bir özel karakter içermelidir.";

            }        

            // 4. Art arda veya sıralı karakter kontrolü
            string lowerCasePassword = password.ToLower();

            for (int i = 0; i < lowerCasePassword.Length - 2; i++)
            {
                // Karakterlerin ASCII kodlarına göre sıralı olup olmadığını kontrol eder
                if (lowerCasePassword[i + 1] == lowerCasePassword[i] + 1 && lowerCasePassword[i + 2] == lowerCasePassword[i + 1] + 1)
                {
                    return "Parola sıralı karakterler içeremez (örneğin: '123', 'abc').";
                }

                // Ters sıralı kontrolü (örneğin '321' veya 'cba')
                if (lowerCasePassword[i + 1] == lowerCasePassword[i] - 1 && lowerCasePassword[i + 2] == lowerCasePassword[i + 1] - 1)
                {
                    return "Parola sıralı karakterler içeremez (örneğin: '123', 'abc').";
                }
            }
            return "";
        }
    }
}
