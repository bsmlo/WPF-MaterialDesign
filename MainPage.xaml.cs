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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {

        List<DBRecord> people = new List<DBRecord>();

        public MainPage()
        {
            InitializeComponent();


            VoiceOversListbox.ItemsSource = people;
            VoiceOversListbox.DisplayMemberPath = "FullInfo";
        }

        //Shearhtype check box
        private void SearchType_Checked(object sender, RoutedEventArgs e)
        {

        }

        //Visable and Collapsing Deleting Button depends on listbox selection
        private void VoiceOversListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VoiceOversListbox.SelectedItems != null)
            {
                DeleteButon.Visibility = Visibility.Visible;
            }
            else
            {
                DeleteButon.Visibility = Visibility.Collapsed;
            }
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

        //Clear textboxes when doubleclick
        private void Name_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Name.Text = "";
        }

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
            if (Name.Text == "")
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

        //Deleting button
        private void DeleteButon_Click(object sender, RoutedEventArgs e)
        {
            List<int> selectedID = new List<int>();
            foreach (object record in VoiceOversListbox.SelectedItems)
            {
                selectedID.Add(Convert.ToInt16(people[VoiceOversListbox.Items.IndexOf(record)].ID));
            }

            if (selectedID.Count() != 0)
            {
                DeleteItems deleting = new DeleteItems(selectedID);

                //Research list after deleting
                Search_Click(sender, e);

                Status.Foreground = new SolidColorBrush(Colors.Green);
                Status.Content = "Data removed successfully";
            }

            selectedID = null;
        }
    }
}
