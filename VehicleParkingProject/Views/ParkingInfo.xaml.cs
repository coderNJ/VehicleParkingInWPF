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
using VehicleParkingProject.ViewModel;

namespace VehicleParkingProject.Views
{
    /// <summary>
    /// Interaction logic for ParkingInfo.xaml
    /// </summary>
    public partial class ParkingInfo : Window
    {
        public static string SlotID { get; set; }
        public static Boolean SlotFreed = false;
        private DateTime timeout;
        private decimal amount;

        class Person {  public string EntryID { get; set; } }
        
        public ParkingInfo()
        {
            InitializeComponent();
            this.DataContext = new ParkingEntryViewModel(SlotID);
            
        }

        private void CalculateAmount_Click(object sender, RoutedEventArgs e)
        {
            ParkingEntryViewModel entryVM = (ParkingEntryViewModel)this.DataContext;
            string entryid = entryVM.GetEntryID(SlotID);
            DateTime tout = DateTime.Now;
            timeout = tout;
            decimal totalamount = entryVM.GetAmount(entryid, tout);
            amount = totalamount;
            TimeOutText.Text = tout.ToString();
            AmountText.Text = totalamount.ToString();

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FreeSlot_Click(object sender, RoutedEventArgs e)
        {
            if (TimeOutText.Text== "" || TimeOutText.Text == null)
            { 
                MessageBox.Show("Please Calculate the amount first!");
                return;
            }
            ParkingEntryViewModel entryVM = (ParkingEntryViewModel)this.DataContext;
            entryVM.SetTimeOut(timeout, SlotID);
            entryVM.SetTotalAmount(amount, SlotID);

            try
            {
                if (entryVM.FreeSlot(SlotID, timeout, amount))
                {
                    SlotFreed = true;
                    MessageBox.Show("Slot Free!");
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }
    }
}
