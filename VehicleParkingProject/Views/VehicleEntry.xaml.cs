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
    /// Interaction logic for VehicleEntry.xaml
    /// </summary>
    public partial class VehicleEntry : Window
    {
        public static Boolean EntryAdded = false;
        public VehicleEntry(ParkingSlotViewModel slotVM)
        {
            InitializeComponent();
            //this.slotid = slotid;
            lblSlotID.Content = slotVM.Slot.SlotID ;
            this.DataContext = slotVM;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int vehNum = Convert.ToInt32(VehicleNumber.Text);
            string slotid = lblSlotID.Content.ToString();
            AddEntryViewModel entryViewModel = new AddEntryViewModel {SlotID=slotid, VehicleNumber=vehNum };
            try
            {
               if(entryViewModel.AddParkingEntry())
                    EntryAdded = true;

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
