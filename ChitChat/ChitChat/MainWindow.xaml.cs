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
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using ChitChat.Private;
    using ChitChat.Public;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /** Used to check if the user has logged in. By default it's false. */
        private bool loggedIn;

        /** Used to access user variables */
        public User User;

        // Used to change Stances, by default - Online
        private Stances currentUserStance = Stances.Online;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        public MainWindow(bool loggedIn, User user) : this()
        {
            this.LoggedIn = loggedIn;
            this.User = user;

            UsernameOutput.Content = this.User.Username;
        }

        public bool LoggedIn
        {
            get { return this.loggedIn; }
            set { this.loggedIn = value; }
        }
        
        private void ChitChat_Online_Click(object sender, RoutedEventArgs e)
        {
            this.currentUserStance = Stances.Online;
        }

        private void ChitChat_Busy_Click(object sender, RoutedEventArgs e)
        {
            this.currentUserStance = Stances.Busy;
        }

        private void ChitChat_AFK_Click(object sender, RoutedEventArgs e)
        {
            this.currentUserStance = Stances.AFK;
        }

        private void ChitChat_Ghost_Click(object sender, RoutedEventArgs e)
        {
            this.currentUserStance = Stances.Ghost;
        }

        private void ChitChat_Offline_Click(object sender, RoutedEventArgs e)
        {
            this.currentUserStance = Stances.Offline;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    
        // Variant 2 - less code, but more computation == slower performance
        private void ChitChat_ChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            Button sourceButton = (Button)sender;
            switch (sourceButton.Name)
            {
                case "Online":
                    this.currentUserStance = Stances.Online;
                    break;
                case "Busy":
                    this.currentUserStance = Stances.Busy;
                    break;
                case "AFK":
                    this.currentUserStance = Stances.AFK;
                    break;
                case "Ghost":
                    this.currentUserStance = Stances.Ghost;
                    break;
                case "Offline":
                    this.currentUserStance = Stances.Offline;
                    break;
            }
        }
    }
}
