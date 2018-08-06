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
using MySql.Data.MySqlClient;
using dbCon2.Properties;

namespace dbCon2
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            ConnectionSettings setings = new ConnectionSettings();
            setings.ConnectionSet();

            UserNameLoggedIn.Content = User.GetUsetString();
        }

 
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        //Additional menu Exit
        private void Exit_Click(object sender, RoutedEventArgs e)
        {   
            Application.Current.Shutdown();
        }

        //Enable main window draging
        private void TopGrind_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                mainWindow.DragMove();
            }
        }
        
        //Open and Cloase Slidebar Menu
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }
        
        //Change Page To Add/Remove
        private void ButtonAddRemove_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new AddingPage();
        }

        //Searching Button
        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new MainPage();
        }

        //Connecting Settings Window
        private void ConnectionSettingsMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new ConnectionSet();
        }

        //Change Page to Things To Do view
        private void ButtonThingsToDo_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new ThingsToDo();
        }

        //Viwew acount settings page
        private void AcountSettings_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new UserAccount();

        }

        //Logout
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            var LoginPanel = new LoginWindow();
            LoginPanel.Closed += (s, args) => Close();
            
            LoginPanel.Show();
        }


        //Contracts Page
        private void ButtonContracts_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Contracts();
        }
    }
}
