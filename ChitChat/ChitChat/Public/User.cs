using System;
using ChitChat.Private;

namespace ChitChat.Public
{
    public class User
    {

        public User(int id, string username, string password, string email, string joinDate, string ip, string info,
                    string city, string nation, string phone, string sex, string name, int isDonator,
                    string onlineStance)
        {
            Id = id;
            Username = username;
        }

        //Variables

        /** User's ID */
        private  int id;

        /** User's username */
        private string username;

        /** User's email  */
        private string email;

        /** When did the user joined the community */
        private string joinDate;

        /** Current IP of the user */
        private string ip;

        /** Extra information about the user */
        private string info;

        /** The city where the user is living */
        private string city;

        /** The user's nationality */
        private string nation;

        /** User's phone number */
        private string phone;

        /** User's gender */
        private string sex;

        /** User's name to be showed to other users */
        private string name;

        /** This show if the user had donated, or not */
        private int isDonator;

        /** This is the current stance of the user */
        private string onlineStance;

        //Properties

        /** We can get the id, but we can't change it */
        public  int Id
        {
            get { return id; }
            set { id = value; }
        }

        /** We can get the username, but we can't change it */
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        /** We can get the email, but we can't change it */
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /** We can get the join date, but we can't change it */
        public string JoinDate
        {
            get { return joinDate; }
            set { joinDate = value; }
        }

        /** We can get the ip, and change it if it differs from the old one */
        public string Ip
        {
            get { return ip; }
            set 
            {
                if (ip != Misc.GetCurrentIPAddr())
                {
                    ip = Misc.GetCurrentIPAddr();
                }
            }
        }

        /** We can get the email, but we can't change it */
        public string Info
        {
            get { return info; }
            set { info = value; }
        }

        /** We can get the email, but we can't change it */
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        /** We can get the email, but we can't change it */
        public string Nation
        {
            get { return nation; }
            set { nation = value; }
        }

        /** We can get the email, but we can't change it */
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        /** We can get the email, but we can't change it */
        public string Gender
        {
            get { return sex; }
            set { sex = value; }
        }

        /** We can get the email, but we can't change it */
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /** We can get the email, but we can't change it */
        public int IsDonator
        {
            get { return isDonator; }
            set { isDonator = value; }
        }

        /** We can get the email, but we can't change it */
        public string OnlineStance
        {
            get { return onlineStance; }
            set { onlineStance = value; }
        }
    }
}
