using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Encrypt("Password"));
        }

        public static string Encrypt(string password)
        {
            string encryptedPassword = "";
            int counter = 0;
            int hash = 0;
            int i = 0;
            Random R = new Random();
            int offset = R.Next(5, 31);

            List<string> hashChars = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n",
                "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")" };

            for (; i <= 35; i++)
            {
                if (i > 25)
                {

                    hashChars.Add(counter.ToString());
                    counter++;
                }
                else
                {
                    string upperCase = hashChars[i].ToString().ToUpper();
                    hashChars.Add(upperCase);
                }
            }

            i = 0;

            for (; i < password.Length; i++)
            {

                if (hashChars.IndexOf(password[i].ToString()) + offset > hashChars.Count)
                {
                    hash += hashChars.IndexOf(password[i].ToString()) + offset;

                    hash -= hashChars.Count;
                }
                else
                {
                    hash = hashChars.IndexOf(password[i].ToString()) + offset;
                }

                encryptedPassword += hashChars[hash];
                hash = 0;
            }

            return encryptedPassword;
        }
    }
}
