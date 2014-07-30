namespace ChitChat.Public
{
    using System;
    using ChitChat.Private;

    public class User
    {
        private int id;

        private string username;

        private string email;

        private string joinDate;

        private string ip;

        private string info;

        private string city;

        private string nation;

        private string phone;

        private string sex;

        private string name;

        private int isDonator;

        private string onlineStance;

        public User(int id, string username, string password, string email, string joinDate, string ip, string info,
                  string city, string nation, string phone, string sex, string name, int isDonator, string onlineStance)
        {
            this.Id = id;
            this.Username = username;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string JoinDate
        {
            get { return this.joinDate; }
            set { this.joinDate = value; }
        }

        public string Ip
        {
            get
            {
                return this.ip;
            }

            set 
            {
                if (this.ip != Misc.GetCurrentIPAddr())
                {
                    this.ip = Misc.GetCurrentIPAddr();
                }
            }
        }

        public string Info
        {
            get { return this.info; }
            set { this.info = value; }
        }

        public string City
        {
            get { return this.city; }
            set { this.city = value; }
        }

        public string Nation
        {
            get { return this.nation; }
            set { this.nation = value; }
        }

        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

        public string Gender
        {
            get { return this.sex; }
            set { this.sex = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int IsDonator
        {
            get { return this.isDonator; }
            set { this.isDonator = value; }
        }

        public string OnlineStance
        {
            get { return this.onlineStance; }
            set { this.onlineStance = value; }
        }
    }
}
