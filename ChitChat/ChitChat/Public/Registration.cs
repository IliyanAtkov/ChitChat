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

        public string Country { get; set; }

        public string Nation { get; set; }

        public string Language { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public string Name { get; set; }

        public string Info { get; set; }


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
                    case "Country":
                        validation = this.CountryValidation();
                        break;
                    case "Nation":
                        validation =this.NationValidation();
                        break;
                    case "Language":
                        validation = this.LanguageValidation();
                        break;
                    case "City":
                        validation = this.CityValidation();
                        break;
                    case "Phone":
                        validation = this.PhoneValidation();
                        break;
                    case "Name":
                        validation = this.NameValidation();
                        break;
                    case "Info":
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
            if (string.IsNullOrEmpty(this.Country))
            {
                return null;
            }

            bool isValid = Regex.IsMatch(this.Country, @"^[a-zA-Z0-9 ]+$");
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
            if (string.IsNullOrEmpty(this.Nation))
            {
                return null;
            }

            bool isValid = Regex.IsMatch(this.Nation, @"^[a-zA-Z0-9]+$");
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
            if (string.IsNullOrEmpty(this.Language))
            {
                return null;
            }

            bool isValid = Regex.IsMatch(this.Language, @"^[a-zA-Z0-9]+$");
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
            if (string.IsNullOrEmpty(this.City))
            {
                return null;
            }

            bool isValid = Regex.IsMatch(this.City, @"^[a-zA-Z0-9 ]+$");
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
            if (string.IsNullOrEmpty(this.Phone))
            {
                return null;
            }

            bool isValid = Regex.IsMatch(this.Phone, @"^[0-9+]+$");
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
             if (string.IsNullOrEmpty(this.Name))
             {
                 return null;
             }

             bool isValid = Regex.IsMatch(this.Name, @"^[a-zA-Z0-9 ]+$");
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