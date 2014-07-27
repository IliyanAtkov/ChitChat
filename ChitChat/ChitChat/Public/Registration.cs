using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ChitChat.Private;

namespace ChitChat
{
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
                        validation = UserNameValidation();
                        break;
                    case "Email":
                        validation = EmailValidation();
                        break;
                    default:
                        break;
                }

                return validation;
            }
        }

        private string UserNameValidation()
        {
            bool allowedSymbols = Regex.IsMatch(UserName, @"^[a-zA-Z0-9_]+$");

            if (string.IsNullOrEmpty(UserName))
            {
                return "User Name is Required";
            }

            else if (UserName.Length > Constants.MAX_USERNAME_LENGTH  && UserName.Length <= Constants.MIN_USERNAME_LENGTH)
            {
                return "User name length should be at least 3 and maximum 30 characters long.";
            }

            else if(allowedSymbols == false)
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
            bool isEmail = Regex.IsMatch(Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
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

