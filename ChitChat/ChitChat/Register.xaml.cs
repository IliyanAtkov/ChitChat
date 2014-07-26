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


namespace ChitChat
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private int errorsOnScreen = 0;
        private Registration registation = new Registration();
        public Register()
        {

            InitializeComponent();
            grid.DataContext = registation;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
              
        }

             
        private void Registation_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = errorsOnScreen == 0;
            e.Handled = true;
        }

        private void Registration_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Registration cust = grid.DataContext as Registration;
            registation = new Registration();
            grid.DataContext = registation;
            e.Handled = true;

        }
       
      
    }
}
