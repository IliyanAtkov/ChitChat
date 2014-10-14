namespace ChitChat.Private
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using ChitChat.Public;

    public static class Misc
    {
        static string[] webResponceInstanceSeparators = { "<new>" };
        static int tempFriendsInfoCount = 3;
        static string[] webResponceSeparators = { "<sep>" };
        //Modify webResponceCount when adding or removing responce lines separated by <sep>
        private static int webResponceCount = 15;

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
            //return "95.42.197.252";
        }

        public static  string[] SeparateFriends(string data)
        {
            string[] dataArr = data.Split(webResponceInstanceSeparators, StringSplitOptions.RemoveEmptyEntries);
            return dataArr;
            //string[][] dataArr2 = new string[dataArr.Length][];
            //for (int i = 0; i < dataArr.Length; i++)
            //{
            //    dataArr2[i] = dataArr[i].Split(webResponceSeparators, StringSplitOptions.None);
            //    dictionary = GetResultToAssocArray();
            //}
        }

        public static ObservableCollection<Friend> FillFriendsInCollection(string[] dataArr, int startIndex)
        {
            string[][] dataArr2 = new string[dataArr.Length][];
            Dictionary<string, string> dictionary;
            ObservableCollection<Friend> collection = new ObservableCollection<Friend>();
            for (int i = startIndex; i < dataArr.Length; i++)
            {
                dictionary = GetResultToAssocArray(dataArr[i].Split(webResponceSeparators, StringSplitOptions.RemoveEmptyEntries), 0);
                Friend current = new Friend(int.Parse(dictionary["id"]), dictionary["name"], (Stances)Enum.Parse(typeof(Stances), dictionary["onlineStance"]));
                collection.Add(current);
            }
            return collection;
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
        public static Dictionary<string, string> GetResultToAssocArray(string[] resultArray, int startIndex)
        {
            Dictionary<string, string> myDic = new Dictionary<string, string>();
            char[] dictionarySeparators = { '=' };

            for (int i = startIndex; i < resultArray.Length; i++)
            {
                string[] newestStr = resultArray[i].Split(dictionarySeparators, 2, StringSplitOptions.None);

                myDic.Add(newestStr[0], newestStr[1]);
            }

            return myDic;
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the has
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect bytes
            // and create a string
            StringBuilder sb = new StringBuilder();

            // Loop trough each byte of the hashed data
            // and format each one as hexademical string
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            // Return hexademical string
            return sb.ToString();
        }

        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer and compare the hashes
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
