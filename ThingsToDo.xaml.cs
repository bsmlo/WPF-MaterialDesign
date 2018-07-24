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
    /// Interaction logic for ThingsToDo.xaml
    /// </summary>
    public partial class ThingsToDo : Page
    {
        List<ToDoRecord> thingsToDos = new List<ToDoRecord>();

        public ThingsToDo()
        {
            InitializeComponent();

            ToDoList.ItemsSource = thingsToDos;
            ToDoList.DisplayMemberPath = "FullInfoToDo";

            InitializeStartList();
        }

        private void SaveToDoButton_Click(object sender, RoutedEventArgs e)
        {
            AddnewToDoDB toDoDB = new AddnewToDoDB();
            toDoDB.AddToDoDB(DateTDBox.Text, TitleTDBox.Text, CoWorkTDBox.Text, DescriptionTDBox.Text, "1");
        }

        private void ClndOfStuff_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DateTDBox.Text = ClndOfStuff.SelectedDate.Value.ToString("yyyy-MM-dd");
            }
            catch
            {

            }

        }

        private void ClndOfStuff_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            string year = ClndOfStuff.DisplayDate.ToString("yyyy");
            string month = ClndOfStuff.DisplayDate.ToString("MM");

            DataAccessToDo accessToDo = new DataAccessToDo();
            thingsToDos = accessToDo.GetToDosMonth(year, month);
            ToDoList.ItemsSource = thingsToDos;
        }

        //Actual task list after initialize page
        private void InitializeStartList()
        {
            string year = ClndOfStuff.DisplayDate.ToString("yyyy");
            string month = ClndOfStuff.DisplayDate.ToString("MM");

            DataAccessToDo accessToDo = new DataAccessToDo();
            thingsToDos = accessToDo.GetToDosMonth(year, month);
            ToDoList.ItemsSource = thingsToDos;
        }

        private void ToDoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (thingsToDos.Count() > 0)
            {
                try
                {
                    Description.Text = thingsToDos[ToDoList.SelectedIndex].GetDescription;
                    DoneButton.Visibility = Visibility.Visible;
                }
                catch
                {

                }
            }

        }

        //Mark task as done
        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataAccessToDo changeStatus = new DataAccessToDo();
                changeStatus.MarkAsDone(thingsToDos[ToDoList.SelectedIndex].GetId.ToString());
            }
            catch
            {

            }
            finally
            {
                InitializeStartList();
            }
        }
    }
}
