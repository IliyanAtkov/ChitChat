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

        public string country { get; set; }

        public string nation { get; set; }

        public string language { get; set; }

        public string city { get; set; }

        public string phone { get; set; }

        public string name { get; set; }

        public string info { get; set; }


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
                    case "country":
                        validation = this.CountryValidation();
                        break;
                    case "nation":
                        validation =this.NationValidation();
                        break;
                    case "language":
                        validation = this.LanguageValidation();
                        break;
                    case "city":
                        validation = this.CityValidation();
                        break;
                    case "phone":
                        validation = this.PhoneValidation();
                        break;
                    case "name":
                        validation = this.NameValidation();
                        break;
                    case "info":
                        validation = null;
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

        private string CountryValidation()
        {
            if (string.IsNullOrEmpty(this.country))
            {
                return null;
            }

            bool isValid = Regex.IsMatch(this.country, @"^[a-zA-Z0-9 ]+$");
            if (isValid)
            {
                return null;
            }
            else
            {
                return "Invalid country";
            }
        }
       
        private string  NationValidation()
        {
            if (string.IsNullOrEmpty(this.nation))
            {
                return null;
            }

            bool isValid = Regex.IsMatch(this.nation, @"^[a-zA-Z0-9]+$");
            if (isValid)
            {
                return null;
            }
            else
            {
                return "Invalid nation";
            }
        }

        private string LanguageValidation()
        {
            if (string.IsNullOrEmpty(this.language))
            {
                return null;
            }

            bool isValid = Regex.IsMatch(this.language, @"^[a-zA-Z0-9]+$");
            if (isValid)
            {
                return null;
            }
            else
            {
                return "Invalid language";
            }
        }

        private string CityValidation()
        {
            if (string.IsNullOrEmpty(this.city))
            {
                return null;
            }

            bool isValid = Regex.IsMatch(this.city, @"^[a-zA-Z0-9 ]+$");
            if (isValid)
            {
                return null;
            }
            else
            {
                return "Invalid city";
            }
        }

         private string PhoneValidation()
        {
            if (string.IsNullOrEmpty(this.phone))
            {
                return null;
            }

            bool isValid = Regex.IsMatch(this.phone, @"^[0-9+]+$");
            if (isValid)
            {
                return null;
            }
            else
            {
                return "Invalid phone";
            }
        }

         private string NameValidation()
         {
             if (string.IsNullOrEmpty(this.name))
             {
                 return null;
             }

             bool isValid = Regex.IsMatch(this.name, @"^[a-zA-Z0-9 ]+$");
             if (isValid)
             {
                 return null;
             }
             else
             {
                 return "Invalid name";
             }
         }
    }
}