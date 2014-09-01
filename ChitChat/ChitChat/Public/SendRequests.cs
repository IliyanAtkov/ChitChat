namespace ChitChat
{
    using System;
    using System.IO;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows;
    using ChitChat.Private;

    public static class SendRequests
    {
        public static string TryToLogInUser(string username, string password)
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

            string result = SendData(Constants.LOGIN_URI, dataToSend);

            return result;
        }

      // public static string RegisterUser(string username, string password, string email, string ip, string sex, string country, string nation, string language)
        public static int RegisterUser( Registration registration, string password, string ip, string sex)   
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
                    data.Append(registration.UserName);
                    data.Append("&password=");
                    data.Append(hash);
                    data.Append("&email=");
                    data.Append(registration.Email);
                    data.Append("&ip=");
                    data.Append(ip);
                    data.Append("&sex=");
                    data.Append(sex);
                    data.Append("&country=");
                    data.Append(registration.country);
                    data.Append("&nation=");
                    data.Append(registration.nation);
                    data.Append("&language=");
                    data.Append(registration.language);
                    data.Append("&name=");
                    data.Append(registration.name);
                    data.Append("&phone=");
                    data.Append(registration.phone);
                    data.Append("&city=");
                    data.Append(registration.city);
                    data.Append("&info=");
                    data.Append(registration.info);
                }

                string dataToSend = data.ToString();

                string result = SendData(Constants.REGISTER_URI, dataToSend);

                if (result == "true")
                {
                    return 0;
                }
                else if(result == "Username")
                {
                    return 1;
                }
                else if(result == "Email")
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            }
        }

        public static bool UpdateUser(string data, ToUpdate whatToUpdate, int userID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("whatToUpdate=");
            sb.Append(whatToUpdate.ToString().ToLower());
            sb.Append("&data=");
            sb.Append(data);
            sb.Append("&userID=");
            sb.Append(userID);

            string dataToSend = sb.ToString();

            string result = SendData(Constants.CHECK_URI, dataToSend);

            if (result == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static string SendData(string URI, string data)
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