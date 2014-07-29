using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ChitChat.Private
{
    public static class Misc
    {
        public static string GetCurrentIPAddr()
        {
            string uri = Constants.IPCHECK_URI;
            WebRequest req = WebRequest.Create(uri);
            WebResponse resp = req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            string[] a = response.Split(':');
            string a2 = a[1].Substring(1);
            string[] a3 = a2.Split('<');
            string a4 = a3[0];
            return a4;
        }

        public static Dictionary<string, string> GetResultToAssocArray(string result)
        {
            string[] newStr = result.Split(':');

            Dictionary<string, string> myDic = new Dictionary<string, string>();

            for (int i = 0; i < newStr.Length; i++)
            {
                string[] newestStr = newStr[i].Split(',');

                myDic.Add(newestStr[0], newestStr[1]);
            }

            return myDic;
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            //Convert the input string to a byte array and compute the has
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            //Create a new Stringbuilder to collect bytes
            //and create a string
            StringBuilder sb = new StringBuilder();

            //Loop trough each byte of the hashed data
            // and format each one as hexademical string
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            //Return hexademical string
            return sb.ToString();
        }

        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            //Hash the input
            string hashOfInput = GetMd5Hash(md5Hash, input);

            //Create a StringComparer and compare the hashes
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
