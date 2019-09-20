using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleParkingProject.Model;
using ParkingServices;
using VehicleParkingEntities;

namespace VehicleParkingProject.ViewModel
{
    class ParkFloorViewModel
    {
        public int Floor { get; protected set; }
        public ObservableCollection<ParkingSlot> 
            Slots { get; protected set; }

        public ParkFloorViewModel(int floor)
        {
            Slots = new ObservableCollection<ParkingSlot>();
            //get all rows with floor 
            try
            {
                Floor = floor;
                List<ParkingSlotEntity> results = FloorInfoService.GetFloorInfo(floor);
                
                foreach(var slotEntity in results)
                {
                    Slots.Add(new ParkingSlot(slotEntity));
                }

            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean UpdateOccupiedStatusInModel(string slotid, Boolean occupied)
        {
            foreach(ParkingSlot p in Slots)
            {
                if(p.SlotID == slotid)
                {
                    p.Occupied = occupied;
                    return true;
                }
            }

            return false;
        }

        public Boolean SlotOccupied(string slotid)
        {
            foreach(ParkingSlot p in Slots)
            {
                if(p.SlotID == slotid)
                {
                    return p.Occupied;
                }
            }

            throw new Exception("Slot not found for Slot ID = " + slotid);
        }

        public ParkingSlotViewModel GetParkingSlotVM(string slotid)
        {
            foreach(ParkingSlot p in Slots)
            {
                if (p.SlotID == slotid)
                    return new ParkingSlotViewModel(p);
            }

            throw new Exception("Could not find Parking Slot with ID: " + slotid);
        }

    }
}
