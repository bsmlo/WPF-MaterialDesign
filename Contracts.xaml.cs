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
    /// Interaction logic for Contracts.xaml
    /// </summary>
    public partial class Contracts : Page
    {
        //ContractItem item = new ContractItem();

        public List<ContractItem> Items = new List<ContractItem>();

        //Number of selected row-for seve data
        string idOfSelectedRow = "";
        int numberOfSelectedRow;
        string actualSelectedDate = "";

        public Contracts()
        {
            InitializeComponent();

            RefreshContractItems();

            CollectionViewSource itemCollectionViewSource;
            itemCollectionViewSource = (CollectionViewSource)(FindResource("ItemContractsSource"));
            itemCollectionViewSource.Source = Items;

            //ContractsDataGrind.ItemsSource = Items;
        }

        private void RefreshContractItems()
        {
            DataAccessContracts dataAccessContracts = new DataAccessContracts();

            Items = dataAccessContracts.GetContracts();

            //empty last item with default values
            ContractItem itemLast = new ContractItem();
            itemLast.ContractItemSet("", "Priceing", User.GetUserName(), DateTime.Today.ToString("yyyy-MM-dd"),
                "", "", "", DateTime.Today.AddMonths(1).ToString("yyyy-MM-dd"), "");

            Items.Add(itemLast);

            ContractsDataGrind.ItemsSource = Items;
            
            CheckSelection();
        }

        //End of row editing
        private void ContractsDataGrind_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            SaveUpdate();
        }

        //selection changed event
        private void ContractsDataGrind_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckSelection();
        }

        //check datagrind selection
        private void CheckSelection()
        {
            
            try
            {
                numberOfSelectedRow = ContractsDataGrind.SelectedIndex;

                if (ContractsDataGrind.Columns[0].GetCellContent(ContractsDataGrind.Items[numberOfSelectedRow]) is TextBlock x)
                {
                    idOfSelectedRow = x.Text;
                }
                
            }
            catch
            {

            }
        }

        //save or update record
        private void SaveUpdate()
        {
            DataAccessContracts dataAccessContracts = new DataAccessContracts();

            try
            {
                dataAccessContracts.AddNewContract(
                    idOfSelectedRow,
                    Items[numberOfSelectedRow].Status,
                    Items[numberOfSelectedRow].Worker,
                    Convert.ToDateTime(Items[numberOfSelectedRow].Date).ToString("yyyy-MM-dd"),
                    Items[numberOfSelectedRow].Client,
                    Items[numberOfSelectedRow].Contact,
                    Items[numberOfSelectedRow].InvoiceStatus,
                    Convert.ToDateTime(Items[numberOfSelectedRow].ExpiryDate).ToString("yyyy-MM-dd"),
                    Items[numberOfSelectedRow].Other);
            }
            catch
            {
                MessageBox.Show("Update Error");
            }
            RefreshContractItems();
        }

        //Save date when close calendar
        private void DataPicker2_CalendarClosed_1(object sender, RoutedEventArgs e)
        {
            CheckSelection();
            if (idOfSelectedRow != "")
            {
                SaveUpdate();
            }
        }

        //Save date when close calendar
        private void DataPicker1_CalendarClosed(object sender, RoutedEventArgs e)
        {
            CheckSelection();
            if (idOfSelectedRow != "")
            {
                SaveUpdate();
            }
        }
/*
        //Save date when keyboard input data
        private void DataPicker1_GotFocus(object sender, RoutedEventArgs e)
        {
            CheckSelection();
            try
            {
                actualSelectedDate = Convert.ToDateTime(Items[numberOfSelectedRow].Date).ToString("yyyy-MM-dd");
            }
            catch
            {
                actualSelectedDate = "";
            }
        }
        //Save date when keyboard input data
        private void DataPicker1_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (actualSelectedDate != "" && Convert.ToDateTime(Items[numberOfSelectedRow].Date).ToString("yyyy-MM-dd") != actualSelectedDate)
                {
                    SaveUpdate();
                }
            }
            catch
            {
                actualSelectedDate = "";
            }
        }
   */     

        // Delete selected row
        private void DeleteRowBUtton_Click(object sender, RoutedEventArgs e)
        {
            CheckSelection();
            if(idOfSelectedRow != null && idOfSelectedRow !="")
            {
                DeleteContract dataAccessContracts = new DeleteContract();
                dataAccessContracts.RemoveContract(idOfSelectedRow);
            }

            RefreshContractItems();
        }

    }
}
