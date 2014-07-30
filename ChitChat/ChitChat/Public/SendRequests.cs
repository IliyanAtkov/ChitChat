namespace ChitChat
{
    using System;
    using System.IO;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows;
    using ChitChat.Private;

    public class SendRequests
    {
        public string TryToLogInUser(string username, string password)
        {
            StringBuilder data = new StringBuilder();
            string Username = username;
            string Password = password;

            using (MD5 md5Hash = MD5.Create())
            {
                string hash = Misc.GetMd5Hash(md5Hash, Password);

                //Verify Hash
                if (Misc.VerifyMd5Hash(md5Hash, Password, hash))
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

        public bool UpdateUser(string data, ToUpdate whatToUpdate, int userID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("whatToUpdate=");

            if (whatToUpdate == ToUpdate.IP)
            {
                sb.Append("ip");
            }
            else if (whatToUpdate == ToUpdate.City)
            {
                sb.Append("city");
            }
            else if (whatToUpdate == ToUpdate.Gender)
            {
                sb.Append("gender");
            }
            else if (whatToUpdate == ToUpdate.Info)
            {
                sb.Append("info");
            }
            else if (whatToUpdate == ToUpdate.Name)
            {
                sb.Append("name");
            }
            else if (whatToUpdate == ToUpdate.Nation)
            {
                sb.Append("nation");
            }
            else if (whatToUpdate == ToUpdate.OnlineStance)
            {
                sb.Append("onlineStance");
            }
            else if (whatToUpdate == ToUpdate.Phone)
            {
                sb.Append("phone");
            }

            sb.Append("&data=");
            sb.Append(data);
            sb.Append("&userID=");
            sb.Append(userID);

            string dataToSend = sb.ToString();

            string result = this.SendData(Constants.CHECK_URI, dataToSend);

            if (result == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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
    }
}