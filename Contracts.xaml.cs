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
        ContractItem item = new ContractItem();

        public List<ContractItem> Items = new List<ContractItem>();

        //Number of selected row-for seve data
        string idOfSelectedRow = "";
        int numberOfSelectedRow;

        public Contracts()
        {
            InitializeComponent();

            RefreshContractItems();

            ContractsDataGrind.ItemsSource = Items;
        }

        private void RefreshContractItems()
        {
            DataAccessContracts dataAccessContracts = new DataAccessContracts();

            Items = dataAccessContracts.GetContracts();

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

                /* if(idOfSelectedRow != "" && numberOfSelectedRow > Items.Count())
                 {
                     ContractItem contract = new ContractItem();
                     ContractsDataGrind.ItemsSource = Items;
                 }*/
            }
            catch
            {

            }
        }

        //save or update record
        private void SaveUpdate()
        {
            //MessageBox.Show(Items.Count().ToString() + " " + ContractsDataGrind.Items.Count);

            DataAccessContracts dataAccessContracts = new DataAccessContracts();

            MessageBox.Show(idOfSelectedRow);

            string status = "";
            if (ContractsDataGrind.Columns[1].GetCellContent(ContractsDataGrind.Items[numberOfSelectedRow]) is TextBlock x)
            {
                status = x.Text;
            }
            

            dataAccessContracts.AddNewContract(
                idOfSelectedRow,
                status,
                "",
                DateTime.Today.ToString("yyy-MM-dd"), "", "",
                DateTime.Today.AddMonths(1).ToString("yyy-MM-dd"), "");

            RefreshContractItems();
        }
        

        private void DatePicker1_CalendarClosed(object sender, RoutedEventArgs e)
        {
            CheckSelection();
            if (idOfSelectedRow != "")
            {
                SaveUpdate();
            }
        }
    }
}
