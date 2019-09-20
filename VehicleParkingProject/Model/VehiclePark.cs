using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleParkingEntities;

namespace VehicleParkingProject.Model
{
    class VehiclePark
    {
    }

    public class ParkingSlot: INotifyPropertyChanged
    {
        bool occupied;
        public string SlotID { get; set; }
        public int Index { get; set; }
        public int Floor { get; set; }
        public string VehicleType { get; set; }
        public Boolean Occupied { 
            get {
                return this.occupied;
            }
            set
            {
                if (value != occupied)
                {
                    occupied = value;
                    NotifyChanged("Occupied");
                }
            }
        }
        public decimal Cost { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        public ParkingSlot(ParkingSlotEntity e)
        {
            SlotID = e.SlotID;
            Index = e.Index;
            Floor = e.Floor;
            VehicleType = e.VehicleType;
            Occupied = e.Occupied;
            Cost = e.Cost;
        }
    }

    class ParkingEntry
    {
        public string EntryID { get; set; }
        public string SlotID { get; set; }
        public int VehicleNumber { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public decimal TotalAmount { get; set; }

        public ParkingEntry(ParkingEntryEntity e)
        {
            EntryID = e.EntryID;
            SlotID = e.SlotID;
            VehicleNumber = e.VehicleNumber;
            TimeIn = e.TimeIn;
            TimeOut = e.TimeOut;
            TotalAmount = e.TotalAmount;
        }

    }

}
