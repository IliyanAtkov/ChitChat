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

        public bool RegisterUser(string username, string password, string email, string ip, string sex)
        {
            StringBuilder data = new StringBuilder();
            string Password = password;

            using (MD5 md5Hash = MD5.Create())
            {
                string hash = Misc.GetMd5Hash(md5Hash, Password);

                //Verify Hash
                if (Misc.VerifyMd5Hash(md5Hash, Password, hash))
                {
                    data.Append("username=");
                    data.Append(username);
                    data.Append("&password=");
                    data.Append(hash);
                    data.Append("&email=");
                    data.Append(email);
                    data.Append("&ip=");
                    data.Append(ip);
                    data.Append("&sex=");
                    data.Append(sex);
                }

                string dataToSend = data.ToString();

                string result = this.SendData(Constants.REGISTER_URI, dataToSend);

                if (result == "true")
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
}
