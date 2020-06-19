using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Paintball_club
{
    class Encription
    {
        public static string EncriptionString(string str)
        {
            string encription = "";
            using (var hash = SHA256.Create())
            {
                byte[] bhash = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str));
                for (int i = 0; i < bhash.Length; i++)
                {
                    encription += bhash[i].ToString("X2");
                }
            }
            return encription;

        }
    }
}
