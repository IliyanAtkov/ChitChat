namespace ChitChat.Private
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Constants
    {
        public static int MAX_USERNAME_LENGTH { get { return 30; } }

        public static int MIN_USERNAME_LENGTH { get { return 2; } }

        public static int MAX_PASSWORD_LENGTH { get { return 20; } }

        public static int MIN_PASSWORD_LENGTH { get { return 6; } }

        public static string REGISTER_URI { get { return "http://188.254.209.106:8080/ChitChat/register.php"; } }

        public static string LOGIN_URI { get { return "http://188.254.209.106:8080/ChitChat/login.php"; } }

        public static string CHECK_URI { get { return "http://188.254.209.106:8080/ChitChat/check.php"; } }

        public static string IPCHECK_URI { get { return "http://checkip.dyndns.org"; } }

        public static string SEARCH_USERS_URI { get { return "http://188.254.209.106:8080/ChitChat/search_users.php"; } }

        public static string ADD_FRIEND_URI { get { return "http://188.254.209.106:8080/ChitChat/add_friend.php"; } }

        public static string LOAD_FRIENDS_URI { get { return "http://188.254.209.106:8080/ChitChat/load_friends.php"; } }
    }
}