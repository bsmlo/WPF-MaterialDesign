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
    /// Interaction logic for ConnectionSet.xaml
    /// </summary>
    public partial class ConnectionSet : Page
    {
        public ConnectionSet()
        {
            InitializeComponent();
            IPTextBox.Text = Settings.Default.Server.ToString();
            UserTextBox.Text = Settings.Default.User_id.ToString();
            PasswordTextBox.Text = Settings.Default.Password.ToString();
            PersisTextBox.Text = Settings.Default.Persistsecurityinfo.ToString();
            PortTextBox.Text = Settings.Default.Port.ToString();
            DataBaseTextBox.Text = Settings.Default.Database.ToString();
            SslTextBox.Text = Settings.Default.SslMode.ToString();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.Server = IPTextBox.Text;
            Settings.Default.User_id = UserTextBox.Text;
            Settings.Default.Password = PasswordTextBox.Text;
            Settings.Default.Persistsecurityinfo = PersisTextBox.Text;
            Settings.Default.Port = PortTextBox.Text;
            Settings.Default.Database = DataBaseTextBox.Text;
            Settings.Default.SslMode = SslTextBox.Text;

            Settings.Default.Save();

            ConnectionSettings reload = new ConnectionSettings();
            reload.ConnectionSet();
        }

        private void IPTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UserTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PersisTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PortTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataBaseTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SslTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
