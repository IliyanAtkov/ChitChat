using ChitChat.Private;
using ChitChat.Public;
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
using System.Windows.Shapes;

namespace ChitChat
{
    /// <summary>
    /// Interaction logic for AddFriendsTest.xaml
    /// </summary>
    public partial class AddFriendsTest : Window
    {
        private User user;
        private string username;
        public ObservableCollection<User> UsersList { get; set; }
        public string SearchName
        {
            get
            {
                return this.username;
            }
            set
            {
                this.username = value;
                User user = SendRequests.SearchForUsers(this.SearchName);
                if (user != null)
                {
                    this.UsersList.Add(user);
                }
            }
        }
        public AddFriendsTest(User user)
        {
            InitializeComponent();
            this.UsersList = new ObservableCollection<User>();
            User friend = new User(0, "test", "email", "date", "info", "city", "nation", "phone", "sex", "name", 0, "Online");
            UsersList.Add(friend);
            DataContext = this;
            this.user = user;
        }
        
        private void ContexMenuItemAddFriend_Click(object sender, RoutedEventArgs e)
        {
            if (resultsListBox.SelectedIndex == -1)
            {
                return;
            }

            string result = SendRequests.AddFriend(this.user.Id, UsersList[resultsListBox.SelectedIndex].Id);
            MessageBox.Show(result);
        }
    }
}
