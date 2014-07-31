namespace ChitChat
{
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

    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        /** Used to check if the user has logged in. By default it's false. */
        private bool loggedIn;

        public Login()
        {
            this.InitializeComponent();
        }

        public bool LoggedIn
        {
            get { return this.loggedIn; }
            set { this.loggedIn = value; }
        }

        public void LogInUser()
        {
            this.LoggedIn = true;
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
                this.LogInUser();
                MainWindow mw = new MainWindow(this.LoggedIn);
                mw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
