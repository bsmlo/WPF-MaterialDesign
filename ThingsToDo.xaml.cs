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
        //list for all month
        List<ToDoRecord> thingsToDos = new List<ToDoRecord>();

        //list for selected day
        List<ToDoRecord> daylyToDos = new List<ToDoRecord>();

        //Selected date when changing Status
        string selectedDay;

        public ThingsToDo()
        {
            InitializeComponent();

            ToDoList.ItemsSource = thingsToDos;
            ToDoList.DisplayMemberPath = "FullInfoToDo";

            InitializeStartList();
        }


        //Save Button
        private void SaveToDoButton_Click(object sender, RoutedEventArgs e)
        {
            AddnewToDoDB toDoDB = new AddnewToDoDB();
            toDoDB.AddToDoDB(DateTDBox.Text, TitleTDBox.Text, CoWorkTDBox.Text, DescriptionTDBox.Text, "1");

            CheckRecordsForMounth();

            HighliteDatesOnCalendar();
        }


        //Double click on callendar-fill Data text box with selected data
        private void ClndOfStuff_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DateTDBox.Text = ClndOfStuff.SelectedDate.Value.ToString("yyyy-MM-dd");

                selectedDay = ClndOfStuff.SelectedDate.Value.ToString("yyyy-MM-dd");

                LoadTasksDayly(ClndOfStuff.SelectedDate.Value.ToString("yyyy-MM-dd"));
            }
            catch
            {

            }
            finally
            {
                HighliteDatesOnCalendar();
            }
        }




        //Check in DB records for actual month
        private void CheckRecordsForMounth()
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

            if (ToDoList.ItemsSource == daylyToDos)
            {
                LoadTasksDayly(selectedDay);
            }
            else
            {
                ToDoList.ItemsSource = thingsToDos;
            }

            HighliteDatesOnCalendar();
        }

        //Highlight dates on calendar
        private void HighliteDatesOnCalendar()
        {
            SelectedDatesCollection dates = ClndOfStuff.SelectedDates;
            dates.Clear();
            DateTime today = DateTime.Today;

            dates.Add(today);

            foreach (ToDoRecord date in thingsToDos)
            {
                dates.Add(Convert.ToDateTime(date.Date));
            }

        }


        //Load and find dayly tasks
        private void LoadTasksDayly(string loadForDate)
        {
            ToDoList.ItemsSource = null;

            daylyToDos.Clear();

            foreach (ToDoRecord date in thingsToDos)
            {
                if (Convert.ToDateTime(loadForDate).Day == Convert.ToDateTime(date.Date).Day)
                {
                    daylyToDos.Add(date);
                }

            }

            ToDoList.ItemsSource = daylyToDos;

            MonthWiev.Visibility = Visibility.Visible;
        }


        //Selection changed
        private void ToDoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (thingsToDos.Count() > 0)
            {
                try
                {
                    Description.Text = thingsToDos[ToDoList.SelectedIndex].GetDescription;
                    DoneButton.Visibility = Visibility.Visible;

                    DeleteToDoButton.Visibility = Visibility.Visible;
                }
                catch
                {

                }
            }

            if (ToDoList.SelectedItem == null)
            {
                DoneButton.Visibility = Visibility.Collapsed;
                DeleteToDoButton.Visibility = Visibility.Collapsed;
            }

        }
        

        //Mark task as done
        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<int> selectedID = new List<int>();

                if (ToDoList.ItemsSource == thingsToDos)
                {
                    foreach (object record in ToDoList.SelectedItems)
                    {
                        selectedID.Add(Convert.ToInt16(thingsToDos[ToDoList.Items.IndexOf(record)].ID));
                    }

                }

                else if (ToDoList.ItemsSource == daylyToDos)
                {
                    foreach (object record in ToDoList.SelectedItems)
                    {
                        selectedID.Add(Convert.ToInt16(daylyToDos[ToDoList.Items.IndexOf(record)].ID));
                    }

                }


                if (selectedID.Count() != 0)
                {
                    foreach(int i in selectedID)
                    {
                        DataAccessToDo changeStatus = new DataAccessToDo();
                        changeStatus.MarkAsDone(i.ToString());
                    }
                }
                
                MessageBox.Show("Status Changed!");

                selectedID = null;

                InitializeStartList();
            }
            catch
            {
                MessageBox.Show("Cant connect to DB");
            }
            finally
            {
                InitializeStartList();
            }
        }


        //Lost Focus calendar update
        private void ClndOfStuff_LostFocus(object sender, RoutedEventArgs e)
        {
            HighliteDatesOnCalendar();
        }


        //Change data display on calendar
        private void ClndOfStuff_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            CheckRecordsForMounth();

            HighliteDatesOnCalendar();
        }

        private void DateTDBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DateTDBox.Text = String.Format("{0}-{1}-{2}", DateTime.Today.Year.ToString(), DateTime.Today.Month.ToString(), DateTime.Today.Day.ToString());
        }


        //deleting selected idies from todo db
        private void DeleteToDoButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do You really want to remove records?", "Remove From DB", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
               //
            }
            else
            {
                List<int> selectedID = new List<int>();
                
                if (ToDoList.ItemsSource == thingsToDos)
                {
                    foreach (object record in ToDoList.SelectedItems)
                    {
                        selectedID.Add(Convert.ToInt16(thingsToDos[ToDoList.Items.IndexOf(record)].ID));
                    }

                    if (selectedID.Count() != 0)
                    {
                        ToDoRemove deleting = new ToDoRemove(selectedID);
                    }

                }

                else if (ToDoList.ItemsSource == daylyToDos)
                {
                    foreach (object record in ToDoList.SelectedItems)
                    {
                        selectedID.Add(Convert.ToInt16(daylyToDos[ToDoList.Items.IndexOf(record)].ID));
                    }

                    if (selectedID.Count() != 0)
                    {
                        ToDoRemove deleting = new ToDoRemove(selectedID);
                    }
                }

                selectedID = null;

                InitializeStartList();
            }
        }


        //Restart all month tasks view
        private void MonthWiev_Click(object sender, RoutedEventArgs e)
        {
            ToDoList.ItemsSource = thingsToDos;
            InitializeStartList();
            MonthWiev.Visibility = Visibility.Collapsed;
        }
    }
}
