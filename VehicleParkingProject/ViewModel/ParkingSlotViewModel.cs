using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleParkingProject.Model;

namespace VehicleParkingProject.ViewModel
{
    public class ParkingSlotViewModel
    {
        public ParkingSlot Slot;

        public ParkingSlotViewModel(ParkingSlot slot)
        {
            this.Slot = slot;
        }

        public string GetSlotID()
        {
            return Slot.SlotID;
        }

        public Boolean Occupied()
        {
            return Slot.Occupied;
        }
    }
}
