namespace ChitChat
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using ChitChat.Private;

    public class Registration : IDataErrorInfo
    {
        public string UserName { get; set; }

        public string Email { get;  set; }

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string validation = null;
                switch (columnName)
                {
                    case "UserName":
                        validation = this.UserNameValidation();
                        break;
                    case "Email":
                        validation = this.EmailValidation();
                        break;
                    default:
                        break;
                }

                return validation;
            }
        }

        private string UserNameValidation()
        {
            if (string.IsNullOrEmpty(this.UserName))
            {
                return "User Name is Required";
            }

            bool allowedSymbols = Regex.IsMatch(this.UserName, @"^[a-zA-Z0-9_]+$");

            if (this.UserName.Length > Constants.MAX_USERNAME_LENGTH && this.UserName.Length <= Constants.MIN_USERNAME_LENGTH)
            {
                return "User name length should be at least 3 and maximum 30 characters long.";
            }
            else if (allowedSymbols == false)
            {
                return "User name should contain only digits, words from a to z, or underscore";
            }
            else
            {   
                return null;
            }
        }

        private string EmailValidation()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                return "Email is Required";
            }

            bool isEmail = Regex.IsMatch(this.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (isEmail)
            {
                return null;
            }
            else
            {
                return "Invalid email adress";
            }
        }
    }
}