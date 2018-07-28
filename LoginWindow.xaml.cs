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
        public LoginWindow()
        {
            InitializeComponent();
        }


        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            if(UserTextBox.Text == Settings.Default.DefaultUser && PassBox.Password.ToString() == Settings.Default.DefaultPassword)
            {
                User LoggedIn = new User();
                LoggedIn.Userset(Settings.Default.DefaultUser, "1");

                LoginSuccess();
            }
            else if (false)//check in db
            {
                //login success
            }
            else
            {
                LoginFaildText.Content = "Wrong Input Or Connection Problem";
                LoginFaildText.Foreground = new SolidColorBrush(Colors.Red);
            }


        }

        //Close login window and start application
        private void LoginSuccess()
        {
            this.Hide();
            var mainWindow = new MainWindow();
            mainWindow.Closed += (s, args) => this.Close();
            mainWindow.Show();
        }
    }
}
