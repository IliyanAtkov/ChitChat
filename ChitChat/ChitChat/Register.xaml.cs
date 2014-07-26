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
        private int _noOfErrorsOnScreen = 0;
        private Registration _customer = new Registration();
        public Register()
        {

            InitializeComponent();
            grid.DataContext = _customer;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
              
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
        }

        private void AddCustomer_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _noOfErrorsOnScreen == 0;
            e.Handled = true;
        }

        private void AddCustomer_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Registration cust = grid.DataContext as Registration;
            // write code here to add Customer

            // reset UI
            _customer = new Registration();
            grid.DataContext = _customer;
            e.Handled = true;

        }
    }
}
