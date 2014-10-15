namespace ChitChat
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows;
    using ChitChat.Private;
    using ChitChat.Public;

    public static class SendRequests
    {
        static string[] webResponceSeparators = { "<sep>" };
        //Modify webResponceCount when adding or removing responce lines separated by <sep>
        private static int webResponceCount = 15;

        public static string AddFriend(int currentUserId, int friendId)
        {
            StringBuilder data = new StringBuilder();
            data.Append("user_id=");
            data.Append(currentUserId);
            data.Append("&friend_id=");
            data.Append(friendId);
            string dataToSend = data.ToString();
            string result = SendData(Constants.ADD_FRIEND_URI, dataToSend);
            return result;
        }

        public static ObservableCollection<Friend> LoadFriends(int user_id)
        {
            string dataToSend = "id=" + user_id;
            string result = SendData(Constants.LOAD_FRIENDS_URI, dataToSend);
            string[] resultArray = Misc.SeparateFriends(result);
            if (resultArray[0] == "true")
            {
                return Misc.FillFriendsInCollection(resultArray, 1);
            }
            //return result;
            return new ObservableCollection<Friend>();
        }

        public static User SearchForUsers(string username)
        {
            string php_username = "username=" + username;
            string result = SendData(Constants.SEARCH_USERS_URI, php_username);
            string[] resultArray = result.Split(webResponceSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (resultArray[0] == "true")
            {
                Dictionary<string, string> userInfo = Misc.GetResultToAssocArray(resultArray, 1);
                User user = new User(int.Parse(userInfo["id"]), username, userInfo["email"], userInfo["joinDate"], userInfo["info"], userInfo["city"], userInfo["nation"], userInfo["phone"], userInfo["sex"], userInfo["name"], int.Parse(userInfo["isDonator"]), userInfo["onlineStance"]);
                return user;
            }
            return null;
        }

        public static string TryToLogInUser(string username, string password, ref User user)
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
            string[] resultArray = result.Split(webResponceSeparators, webResponceCount, StringSplitOptions.None);
            if (resultArray[0] == "true")
            {
                Dictionary<string, string> userInfo = Misc.GetResultToAssocArray(resultArray, 1);
                user = new User(int.Parse(userInfo["id"]), Username, userInfo["email"], userInfo["joinDate"], userInfo["info"], userInfo["city"], userInfo["nation"], userInfo["phone"], userInfo["sex"], userInfo["name"], int.Parse(userInfo["isDonator"]), userInfo["onlineStance"]);
                return resultArray[0];
            }
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
                    data.Append(registration.Country);
                    data.Append("&nation=");
                    data.Append(registration.Nation);
                    data.Append("&language=");
                    data.Append(registration.Language);
                    data.Append("&name=");
                    data.Append(registration.Name);
                    data.Append("&phone=");
                    data.Append(registration.Phone);
                    data.Append("&city=");
                    data.Append(registration.City);
                    data.Append("&info=");
                    data.Append(registration.Info);
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