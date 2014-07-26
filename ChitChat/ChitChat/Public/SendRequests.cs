using System;
using System.Net;
using System.Text;
using System.IO;
using System.Windows;
using System.Security.Cryptography;
using ChitChat.Private;

namespace ChitChat
{
    public class SendRequests
    {
        private string SendData(string URI, string data)
        {
            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(URI);
                httpRequest.Method = "POST";
                byte[] postBytes = Encoding.ASCII.GetBytes(data);
                httpRequest.ContentType = "application/x-www-form-urlencoded";
                httpRequest.ContentLength = postBytes.Length;
                Stream requestStream = httpRequest.GetRequestStream();
                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                Stream responseStream = httpResponse.GetResponseStream();

                var sr = new StreamReader(httpResponse.GetResponseStream());
                string responseText = sr.ReadToEnd();
                return responseText;
            }
            catch (WebException)
            {
                MessageBox.Show("Please check your internet connection!");
                return "false";
            }
        }

        public string TryToLogInUser(string username, string password)
        {
            StringBuilder data = new StringBuilder();
            string Username = username;
            string Password = password;

            using(MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, Password);

                //Verify Hash
                if (VerifyMd5Hash(md5Hash, Password, hash))
                {
                    data.Append("username=");
                    data.Append(Username);
                    data.Append("&password=");
                    data.Append(hash);
                }
            }

            string dataToSend = data.ToString();

            string result = this.SendData(Constants.LOGIN_URI, dataToSend);

            return result;
        }

        public string GetMd5Hash(MD5 md5Hash, string input)
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

        public bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
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
