using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleParkingProject.Model;
using ParkingServices;
using System.Collections.ObjectModel;
using VehicleParkingProject.Model;
using VehicleParkingEntities;

namespace VehicleParkingProject.ViewModel
{
    class ParkingEntryViewModel
    {
        public ObservableCollection<ParkingEntry> Entries { get; set; }

        public ParkingEntryViewModel(string slotid)
        {
            Entries = new ObservableCollection<ParkingEntry>();
            try
            {
                ParkingEntryEntity e = ParkingEntryService.GetCurrentParkingEntryInfo(slotid);
                Entries.Add(new ParkingEntry(e));

            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal GetAmount(string entryid, DateTime tout)
        {
            try
            {
                return ParkingEntryService.GetTotalAmount(entryid, tout);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean SetTimeOut(DateTime time, string slotid)
        {
            foreach(ParkingEntry e in Entries)
            {
                if(e.SlotID == slotid)
                {
                    e.TimeOut = time;
                    return true;
                }
            }
            throw new Exception("Parking Entry is not found for slot id" + slotid);
        }

        public Boolean SetTotalAmount(decimal amount, string slotid)
        {
            foreach(ParkingEntry e in Entries)
            {
                if(e.SlotID == slotid)
                {
                    e.TotalAmount = amount;
                    return true;
                }
            }
            throw new Exception("Parking Entry is not found for slot id" + slotid);
        }


        public string GetEntryID(string slotid)
        {
            foreach (ParkingEntry e in Entries)
            {
                if (e.SlotID == slotid)
                    return e.EntryID;
            }

            throw new Exception("Parking Entry is not found for slot id" + slotid);
        }

        public Boolean FreeSlot(string slotid, DateTime tout, decimal amount)
        {
            try
            {
                return ParkingEntryService.FreeSlot(slotid, tout, amount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

    public class AddEntryViewModel
    {
        public string SlotID { get; set; }
        public int VehicleNumber { get; set; }
        public DateTime TimeIn { get; set; }

        public Boolean AddParkingEntry()
        {
            if (SlotID == null)
                throw new Exception("Slot ID not set");
            if (VehicleNumber == 0)
                throw new Exception("Vehicle number not provided");

            TimeIn = DateTime.Now;

            try
            {
                var result = ParkingEntryService.AddParkingEntry(SlotID, VehicleNumber, TimeIn);
                return result;
                
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
