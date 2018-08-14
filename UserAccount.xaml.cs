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

namespace dbCon2
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class UserAccount : Page
    {
        public UserAccount()
        {
            InitializeComponent();

            NameLabel.Content = User.GetUsetString();
            
            //Visability admins elements
            if(User.GetRank() == "visable")
            {
                UsersGrind.Visibility = Visibility.Visible;
                AddNewGrind.Visibility = Visibility.Visible;
            }
            else
            {
                UsersGrind.Visibility = Visibility.Collapsed;
                AddNewGrind.Visibility = Visibility.Collapsed;
            }
        }
        
        private void NameLabel_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
        
        }
    }
}
