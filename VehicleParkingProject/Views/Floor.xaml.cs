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
using VehicleParkingProject.ViewModel;

namespace VehicleParkingProject.Views
{
    /// <summary>
    /// Interaction logic for Floor.xaml
    /// </summary>
    public partial class Floor : UserControl
    {
        public Floor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string slotid = ((Button)sender).Content.ToString();
            ParkFloorViewModel floorVM = (ParkFloorViewModel)this.DataContext;

            if (floorVM.SlotOccupied(slotid)) {
                ParkingInfo.SlotID = slotid;
                Window detailsWindow = new ParkingInfo();
                detailsWindow.Owner = Application.Current.MainWindow;
                detailsWindow.Show();
                detailsWindow.Closed += (sender1, e1) => ParkingEntryWindowClosed(sender1, e1, slotid);

            } else
            {
                ParkingSlotViewModel slotVM = floorVM.GetParkingSlotVM(slotid);
                Window entryWindow = new VehicleEntry(slotVM);
                entryWindow.Owner = Application.Current.MainWindow;
                entryWindow.Show();
                entryWindow.Closed += (sender1, e1) => AddEntryWindowClosed(sender1, e1, slotid);
            }

        }

        private void AddEntryWindowClosed(object sender, EventArgs e, string slotid)
        {
            if (VehicleEntry.EntryAdded)
            {
                ParkFloorViewModel floorVM = (ParkFloorViewModel)this.DataContext;
                floorVM.UpdateOccupiedStatusInModel(slotid, true);
                VehicleEntry.EntryAdded = false;
            }
        }

        private void ParkingEntryWindowClosed(object sender, EventArgs e, string slotid)
        {
            if (ParkingInfo.SlotFreed)
            {
                ParkFloorViewModel floorVM = (ParkFloorViewModel)this.DataContext;
                floorVM.UpdateOccupiedStatusInModel(slotid, false);
                ParkingInfo.SlotFreed = false;
            }
        }
    }
}
