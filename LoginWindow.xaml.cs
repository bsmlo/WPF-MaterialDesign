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

        //Clear userbox when double Click
        private void UserTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (UserTextBox.Text == "User")
            {
                UserTextBox.Text = "";
            }
        }

        //Remark textbox as User after focus lost
        private void UserTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (UserTextBox.Text == "")
            {
                UserTextBox.Text = "User";
            }
        }


        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            User LoggedIn = new User();
            LoggedIn.Userset("User", "1");

            this.Hide();
            var mainWindow = new MainWindow();
            mainWindow.Closed += (s, args) => this.Close();
            mainWindow.Show();
        }
    }
}
