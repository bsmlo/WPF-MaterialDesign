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
using dbCon2.Properties;

namespace dbCon2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public static User LoggedIn = new User();

        public LoginWindow()
        {
            InitializeComponent();
        }


        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserTextBox.Text != "" && PassBox.Password.ToString() != "" && UserTextBox.Text == Settings.Default.DefaultUser && PassBox.Password.ToString() == Settings.Default.DefaultPassword)
            {
                //User LoggedIn = new User();
                LoggedIn.Userset(Settings.Default.DefaultUser, "1", "0", true);

                LoginSuccess();
            }
            else if (UserTextBox.Text != "" && PassBox.Password.ToString() != "")
            {
                try
                {
                    AccessUserDB accessUserDB = new AccessUserDB();
                    LoggedIn = accessUserDB.TryToFindUser(UserTextBox.Text, PassBox.Password.ToString());
                    
                    if (LoggedIn != null)
                    {
                        //LoggedIn.Userset(accessUserDB.Name, accessUserDB.Rank, accessUserDB.ID, false);
                        
                        LoginSuccess();
                    }
                    else
                    {
                        LoginFaildText.Content = "Incorrect Username or Password";
                        LoginFaildText.Foreground = new SolidColorBrush(Colors.Red);
                    }
                }
                catch
                {
                   
                }
            }
            else
            {
                LoginFaildText.Content = "Incorrect Username or Password";
                LoginFaildText.Foreground = new SolidColorBrush(Colors.Red);
            }
            
        }

        //Close login window and start application
        private void LoginSuccess()
        {
            Hide();
            var mainWindow = new MainWindow();
            mainWindow.Closed += (s, args) => Close();
            mainWindow.Show();
        }
    }
}
