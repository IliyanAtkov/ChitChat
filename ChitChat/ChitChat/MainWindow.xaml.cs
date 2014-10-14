namespace ChitChat
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
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

        //public ObservableCollection<Friend> FriendsList { get; set; }
        public ObservableCollection<Friend> FriendsList { get; set; }

        public MainWindow()
        {
            this.InitializeComponent();
        }

        public MainWindow(bool loggedIn, User user) : this()
        {
            this.LoggedIn = loggedIn;
            this.User = user;
            FriendsList = SendRequests.LoadFriends(user.Id);
           // User friend = new User(0, "test", "email", "date", "info", "city", "nation", "phone", "sex", "name", 0, "Online");
            Friend friend = new Friend(0, "name_here", Stances.Online);
            FriendsList.Add(friend);
           // MessageBox.Show(SendRequests.LoadFriends(user.Id);
            DataContext = this;
            UsernameOutput.Content = user.Username;
        }
        public bool LoggedIn
        {
            get { return this.loggedIn; }
            set { this.loggedIn = value; }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    
        private void ChitChat_ChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            MenuItem sourceButton = (MenuItem)sender;  
            this.currentUserStance = (Stances)Enum.Parse(typeof(Stances), sourceButton.Name);
        }

        private void AddFriends_Button_Click(object sender, RoutedEventArgs e)
        {
            AddFriendsTest addFriends_Window = new AddFriendsTest(this.User);
            addFriends_Window.Show();
        }
    }
}
