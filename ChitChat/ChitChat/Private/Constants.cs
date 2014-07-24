using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChat.Private
{
    public static class Constants
    {
        public static int MAX_USERNAME_LENGHT { get { return 30; } }

        public static int MIN_USERNAME_LENGHT { get { return 2; } }

        public static string REGISTER_URI { get { return "http://188.254.209.106:8080/ChitChat/register.php"; } }

        public static string LOGIN_URI { get { return "http://188.254.209.106:8080/ChitChat/login.php"; } }
    }
}
