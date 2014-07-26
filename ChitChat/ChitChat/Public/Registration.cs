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
    class Registration : IDataErrorInfo
    {
        public string UserName { get; set; }


        public string Password { get;  set; }

        public string RepeatedPassword { get;  set; }

        public string Email { get;  set; }

        public string Gender { get;  set; }

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
                    case "Password":
                        validation = PasswordValidation();
                        break;
                    case "RepeatedPassword":
                        validation = RepeatedPasswordValidation();
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

            else if (UserName.Length > Constants.MAX_USERNAME_LENGHT  && UserName.Length <= Constants.MIN_USERNAME_LENGHT)
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

        private string PasswordValidation()
        { 
            bool allowedPassword = Regex.IsMatch(Password, @"^\S\w[a-zA-Z0-9_@]+$");
            bool passwordLength = Password.Length <= 20 && Password.Length >= 6;

            if (string.IsNullOrEmpty(Password))
            {
                return "Password is Required";
            }
    
            else if(allowedPassword == false && passwordLength == false)
            {
                return "Password should contain only words, numbers, underscore or @, length should be between 6 and 20";
            }

            else
            {
                return null;
            }

        }

        private string RepeatedPasswordValidation()
        {
            bool IsrepeatedPasswordTheSame = RepeatedPassword == Password;
            if (IsrepeatedPasswordTheSame)
            {
                return null;
            }

            else
            {
                return "Two passwords must be the same";
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

