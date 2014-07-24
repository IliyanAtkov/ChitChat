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

namespace ChitChat
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        bool loggedIn = false;
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
            const string userLog = "chitchat";
            const string userPass = "123456";

            if (username.Text == userLog && password.Password == userPass)
            {
                loggedIn = true;
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
        }
    }
}
