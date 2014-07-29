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
using ChitChat.Public;


namespace ChitChat
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private const string PasswordIsValid = null;
        private int errorsOnScreen = 0;
        private bool IsSexChosen = false;

        private Registration registation = new Registration();

        public Register()
        {

            InitializeComponent();
            grid.DataContext = registation;
        }
 
        private void Sex_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton value = sender as RadioButton;
            if (value != null)
            {
                string sex = value.Content.ToString();
                IsSexChosen = true;
            }

            e.Handled = true;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string passwordResultValidation = PasswordValidation();
            if (passwordResultValidation != PasswordIsValid)
            {
                MessageBox.Show(passwordResultValidation);
                e.Handled = true;
            }

            else if(IsSexChosen == false)
            {
                MessageBox.Show("Choose Sex");
                e.Handled = true;
            }

            else if (errorsOnScreen != 0)
            {
                MessageBox.Show("There are errors you must fix it");
                e.Handled = true;
            }        

        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorsOnScreen++;
            else
                errorsOnScreen--;
        }

        private void Validation_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = errorsOnScreen == 0;
            e.Handled = true;
        }

        private void Validation_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Registration registrationForm = grid.DataContext as Registration;
            registation = new Registration();
            grid.DataContext = registation;
            e.Handled = true;
        }

        private string PasswordValidation()
        {
            string firstFieldPassword = Password.ToString();
            string repeatedPassword = RepeatedPassword.ToString();
            bool arePasswordEqual = firstFieldPassword == repeatedPassword;

            if (arePasswordEqual == false)
            {
                return "Passwords are not equal";
            }

            bool allowedPassword = Regex.IsMatch(firstFieldPassword, @"^\S\w[a-zA-Z0-9_@]+$");
            bool passwordLength = firstFieldPassword.Length <= Constants.MAX_PASSWORD_LENGTH
                && firstFieldPassword.Length >= Constants.MIN_PASSWORD_LENGTH;

            if (string.IsNullOrEmpty(firstFieldPassword))
            {
                return "Password is Required";
            }

            else if (allowedPassword == false && passwordLength == false)
            {
                return "Password should contain only words, numbers, underscore or @, length should be between 6 and 20";
            }

            else
            {
                return PasswordIsValid;
            }
        }
    }
}