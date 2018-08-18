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
        

        List<User> UsersList = new List<User>();

        public UserAccount()
        {
            InitializeComponent();

            //Visability admins elements
            if (LoginWindow.LoggedIn.GetRankNumr() == "1")
            {
                NameLabel.Content = "Hello " + LoginWindow.LoggedIn.GetUserName + "!";

                UsersGrind.Visibility = Visibility.Visible;
                AddNewGrind.Visibility = Visibility.Visible;

                RefreshUserList();
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
        
        // Add new user
        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            if(AddUserName.Text != "" && AddUserPassword.Text != "")
            {
                string userRank;
                if (AddUserType.IsChecked == true)
                {
                    userRank = "1";
                }
                else
                {
                    userRank = "2";
                }

                AddNewUser user = new AddNewUser(AddUserName.Text, AddUserPassword.Text, userRank);
            }

            RefreshUserList();
        }

        // Refresh users list
        private void RefreshUserList()
        {
            UserList Users = new UserList();
            UsersList = Users.GetAllUsers();

            AllUserGrind.ItemsSource = UsersList;
            AllUserGrind.DisplayMemberPath = "FullInfo";
        }

    }
}
