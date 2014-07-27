using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Text.RegularExpressions;
using ChitChat.Private;


namespace ChitChat
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private const string PasswordIsValid = null;
        private int errorsOnScreen = 0;

        private Registration registation = new Registration();

        private string userSex;

        private string user;

        private string userPassword;

        private string userEmail;
        
        public Register()
        {

            InitializeComponent();
            grid.DataContext = registation;
        }

        public string User
        {
            get
            {
                return user;
            }
            private set
            {
                user = value;
            }
      
        }

        public string UserSex
        {
            get
            {
                return userSex;
            }
            private set
            {
                userSex = value;
            }
        }

        public string UserPassword
        {
            get
            {
                return userPassword;
            }
            private set
            {
                userPassword = value;
            }
        }

        public string UserEmail
        {
            get
            {
                return userEmail;
            }
            private set
            {
                userEmail = value;
            }
        }
        private void Sex_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox check = sender as CheckBox;
            userSex = check.ToString();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            User = UserName.ToString();
            UserEmail = Email.ToString();

         //   string passwordResultValidation;
         //   if (passwordResultValidation != PasswordIsValid)
         //   {
         //       MessageBox.Show(passwordResultValidation);
         //   }

        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorsOnScreen++;
            else
                errorsOnScreen--;
        }

        private void Registation_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = errorsOnScreen == 0;
            e.Handled = true;
        }

        private void Registration_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Registration registrationForm = grid.DataContext as Registration;
            registation = new Registration();
            grid.DataContext = registation;
            e.Handled = true;
        }

    //   private void PasswordValidation()
    //   {
    //       string firstFieldPassword = Password.ToString();
    //       string repeatedPassword = RepeatedPassword.ToString();
    //       bool arePasswordEqual = firstFieldPassword == repeatedPassword;
    //
    //       if (arePasswordEqual == false)
    //       {
    //            MessageBox.Show("Passwords are not equal");
    //       }
    //
    //       bool allowedPassword = Regex.IsMatch(firstFieldPassword, @"^\S\w[a-zA-Z0-9_@]+$");
    //       bool passwordLength = userPassword.Length <= Constants.MAX_PASSWORD_LENGTH
    //           && userPassword.Length >= Constants.MIN_PASSWORD_LENGTH;
    //
    //       if (string.IsNullOrEmpty(userPassword))
    //       {
    //           MessageBox.Show("Password is Required");
    //       }
    //
    //       else if (allowedPassword == false && passwordLength == false)
    //       {
    //           MessageBox.Show("Password should contain only words, numbers, underscore or @, length should be between 6 and 20");
    //       }
    //
    //       else
    //       {
    //            UserPassword = firstFieldPassword;
    //            return PasswordIsValid;
    //       }
    //   }

    }
}