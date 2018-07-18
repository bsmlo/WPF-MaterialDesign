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

namespace dbCon2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> people = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();

            VoiceOversListbox.ItemsSource = people;
            VoiceOversListbox.DisplayMemberPath = "FullInfo";
        }

        //Search button
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();
            
            people = db.GetPeople(Name.Text, Surname.Text, Phone.Text, Email.Text, SearchType.IsChecked.Value);
            VoiceOversListbox.ItemsSource = people;

            Status.Content = db.ExecuteStatus;
            Status.Foreground = db.Color;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {   
            //Additional menu Exit
            Application.Current.Shutdown();
        }
     
        private void VoiceOversListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        
        private void TopGrind_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                mainWindow.DragMove();
            }
        }
        
        private void Name_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Name.Text = "";
        }

        //Clear textboxes when doubleclick
        private void Surname_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Surname.Text = "";
        }
        
        private void Email_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Email.Text = "";
        }

        private void Phone_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Phone.Text = "";
        }

        //Reenter default texts to textboxex when empties
        private void Name_LostFocus(object sender, RoutedEventArgs e)
        {
            if(Name.Text == "")
            {
                Name.Text = "Name";
            }
        }

        private void Surname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Surname.Text == "")
            {
                Surname.Text = "Surname";
            }
        }

        private void Email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Email.Text == "")
            {
                Email.Text = "Email";
            }
        }

        private void Phone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Phone.Text == "")
            {
                Phone.Text = "Phone";
            }
        }

        //Shearhtype check box
        private void SearchType_Checked(object sender, RoutedEventArgs e)
        {

        }

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
    }
}
