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
using dbCon2.Properties;

namespace dbCon2
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class UserAccount : Page
    {
        //add changeing defaulff user's password

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

        //Change Password Button
        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActualPassword.Password != "" && NewPassword.Password != "" && ConfirmPassword.Password != "")
            {
                if (NewPassword.Password == ConfirmPassword.Password)
                {
                    if (LoginWindow.LoggedIn.DefaultUser)
                    {
                        if(Settings.Default.DefaultPassword == ActualPassword.Password.ToString())
                        {
                            Settings.Default.DefaultPassword = NewPassword.Password.ToString();
                            MessageBox.Show("Default User password changed");
                        }
                        else
                        {
                            MessageBox.Show("Default User password changed faild!");
                        }
                    }
                    else
                    {
                        AccessUserDB checkUser = new AccessUserDB();
                        if (checkUser.TryToFindUser(LoginWindow.LoggedIn.GetUserName, ActualPassword.Password.ToString()) != null)
                        {
                            AccessChangePassword accessChangePassword = new AccessChangePassword(LoginWindow.LoggedIn.GetID, NewPassword.Password.ToString());
                            checkUser = null;
                            accessChangePassword = null;
                            GC.Collect();
                        }
                        else
                        {
                            ChangeingPasswordInfo.Content = "Wrong password!";
                        }
                    }
                }
                else
                {
                    ChangeingPasswordInfo.Content = "Confrim password faild!";
                }

            }
            else
            {
                ChangeingPasswordInfo.Content = "Fill in all the boxes!";
            }
        }
        
        // Add new user
        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool userExist = false;

                foreach(User user in UsersList)
                {
                    if(user.UserNameDB == AddUserName.Text)
                    {
                        userExist = true;
                        MessageBox.Show("User Already Exists!");
                    }
                }


                if (AddUserName.Text != "" && AddUserPassword.Text != "" && !userExist)
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
            }
            catch
            {
                
            }

            RefreshUserList();
        }

        // Refresh users list
        private void RefreshUserList()
        {
            UserList Users = new UserList();
            UsersList = Users.GetAllUsers();

            User DefaultUser = new User();
            DefaultUser.Userset(Properties.Settings.Default.DefaultUser, "1", "", true);

            UsersList.Add(DefaultUser);

            AllUserGrind.ItemsSource = UsersList;
            AllUserGrind.DisplayMemberPath = "FullInfo";
        }

    }
}
