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

namespace ChitChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /** Used to check if the user has logged in. By default it's false. */
        private bool loggedIn;
        //Used to change Stances, by default - Online
        Stances currentUserStance = Stances.Online;

        

        public bool LoggedIn
        {
            get { return loggedIn; }
            set { loggedIn = value; }
        }


        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(bool loggedIn) : this()
        {
            LoggedIn = loggedIn;
        }

        private void ChitChat_Online_Click(object sender, RoutedEventArgs e)
        {
            currentUserStance = Stances.Online;
        }

        private void ChitChat_Busy_Click(object sender, RoutedEventArgs e)
        {
            currentUserStance = Stances.Busy;
        }

        private void ChitChat_AFK_Click(object sender, RoutedEventArgs e)
        {
            currentUserStance = Stances.AFK;
        }

        private void ChitChat_Ghost_Click(object sender, RoutedEventArgs e)
        {
            currentUserStance = Stances.Ghost;
        }

        private void ChitChat_Offline_Click(object sender, RoutedEventArgs e)
        {
            currentUserStance = Stances.Offline;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Variant 2 - less code, but more computation
        private void ChitChat_ChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            Button sourceButton = (Button)sender;
            switch (sourceButton.Name)
            {
                case  "Online": currentUserStance = Stances.Online;  break;
                case    "Busy": currentUserStance = Stances.Busy;    break;
                case     "AFK": currentUserStance = Stances.AFK;     break;
                case   "Ghost": currentUserStance = Stances.Ghost;   break;
                case "Offline": currentUserStance = Stances.Offline; break;
            }
        }

    }
}
