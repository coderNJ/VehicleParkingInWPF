using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleParkingEntities
{
    public class ParkingSlotEntity : IComparable<ParkingSlotEntity>
    {   
        public string SlotID { get; set; }
        public int Index { get; set; }
        public int Floor { get; set; }
        public string VehicleType { get; set; }
        public Boolean Occupied { get; set; }
        public decimal Cost { get; set; }

        public int CompareTo(ParkingSlotEntity other)
        {
            if (other == null) return -1;

            if (this.Index < other.Index) return -1;
            if (this.Index > other.Index) return 1;

            return 0;
        }
    }

    public class ParkingEntryEntity
    {
        public string EntryID { get; set; }
        public string SlotID { get; set; }
        public int VehicleNumber { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
