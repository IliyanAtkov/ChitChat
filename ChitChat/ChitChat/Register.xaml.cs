namespace ChitChat
{ 
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using ChitChat.Private;
    using ChitChat.Public;

    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private const string PasswordIsValid = null;
        private int errorsOnScreen = 0;
        private bool isSexChosen = false;
        private string sex = "";

        private Registration registation = new Registration();

        public Register()
        {
            this.InitializeComponent();
            grid.DataContext = this.registation;
        }
 
        private void Sex_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton value = sender as RadioButton;
            if (value != null)
            {
                this.sex = value.Content.ToString();
                this.isSexChosen = true;
            }

            e.Handled = true;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string passwordResultValidation = this.PasswordValidation();
            if (passwordResultValidation != PasswordIsValid)
            {
                MessageBox.Show(passwordResultValidation);
                e.Handled = true;
            }
            else if (this.isSexChosen == false)
            {
                MessageBox.Show("Choose Sex");
                e.Handled = true;
            }
            else if (this.errorsOnScreen != 0)
            {
                MessageBox.Show("There are errors you must fix it");
                e.Handled = true;
            }

            else
            {
                //Register implementation
                string ipAddr = Misc.GetCurrentIPAddr();
                //string regSuccess = SendRequests.RegisterUser(UserName.Text, PasswordBox.Password, Email.Text, ipAddr, this.sex, country.Text, nation.Text, language.Text);
                int regSuccess = SendRequests.RegisterUser(this.registation, PasswordBox.Password, ipAddr, this.sex);
                if (regSuccess == 0) 
                //If successfuly registered
                {
                    Login lw = new Login();
                    MessageBox.Show("Registration successful!");
                    lw.Show();
                    this.Close();
                }
                else if(regSuccess == 1)
                {
                    MessageBox.Show("Username already in use!");
                }
                else if(regSuccess == 2)
                {
                    MessageBox.Show("Email already in use!");
                }
                else if(regSuccess == 3)
                {
                    MessageBox.Show("Failed to register!");
                }

                e.Handled = true;
            }
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                this.errorsOnScreen++;
            }
            else
            {
                this.errorsOnScreen--;
            }
        }

        private void Validation_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.errorsOnScreen == 0;
            e.Handled = true;
        }

        private void Validation_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Registration registrationForm = grid.DataContext as Registration;
            this.registation = new Registration();
            grid.DataContext = this.registation;
            e.Handled = true;
        }

        private string PasswordValidation()
        {
            ///Old code:
            /// string firstFieldPassword = Password.ToString();
            ///string repeatedPassword = RepeatedPassword.ToString();
            string firstFieldPassword = PasswordBox.Password;
            string repeatedPassword = RepeatedPasswordBox.Password;

            if (string.IsNullOrEmpty(firstFieldPassword))
            {
                return "Password is Required";
            }
           
            bool allowedPassword = Regex.IsMatch(firstFieldPassword, @"^\S\w[a-zA-Z0-9_@]+$");
            bool passwordLength = firstFieldPassword.Length <= Constants.MAX_PASSWORD_LENGTH && firstFieldPassword.Length >= Constants.MIN_PASSWORD_LENGTH;
            
            if (allowedPassword == false && passwordLength == false)
            {
                return "Password should contain only words, numbers, underscore or @, length should be between 6 and 20";
            }
            
            bool arePasswordEqual = firstFieldPassword == repeatedPassword;

            if (arePasswordEqual == false)
            {
                return "Passwords are not equal";
            }
            else
            {
                return PasswordIsValid;
            }
        }
    }
}