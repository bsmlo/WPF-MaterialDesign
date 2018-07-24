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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class AddingPage : Page
    {
        public AddingPage()
        {
            InitializeComponent();
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

        //Add new record to database
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name, surname, phone, email;

            if (Name.Text == "Name")
            {
                name = "";
            }
            else
            {
                name = Name.Text;
            }
            if (Surname.Text == "Surname")
            {
                surname = "";
            }
            else
            {
                surname = Surname.Text;
            }
            if (Phone.Text == "Phone")
            {
                phone = "";
            }
            else
            {
               phone  = Phone.Text;
            }
            if (Email.Text == "Email")
            {
               email  = "";
            }
            else
            {
               email  = Email.Text;
            }

            AddCoworkerDB addNewRecord = new AddCoworkerDB();
            addNewRecord.AddRecord( name, surname, phone, email);
        }
    }
}
