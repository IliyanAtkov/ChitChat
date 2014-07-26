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
using ChitChat.Private;

namespace ChitChat
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        /** Used to check if the user has logged in. By default it's false. */
        private bool loggedIn;

        public bool LoggedIn
        {
            get { return loggedIn; }
            set { loggedIn = value; }
        }

        public void LogInUser()
        {
            this.LoggedIn = true;
        }

        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Register regForm = new Register();
            regForm.Show();
            this.Close();
        }

        private void Login_btn_Click_1(object sender, RoutedEventArgs e)
        {
            SendRequests sr = new SendRequests();
            string canLogin = sr.TryToLogInUser(username.Text, password.Password);

            if (canLogin == "true")
            {
                LogInUser();
                MainWindow mw = new MainWindow(LoggedIn);
                mw.Show();
                this.Close();
            }
                
            
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
