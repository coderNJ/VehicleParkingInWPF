using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleParkingEntities;

namespace ParkingServices
{
    public class FloorInfoService
    {
        static string connString = "Host=localhost;Username=postgres;Password=1234;Database=vehiclepark-db;";
        public static List<ParkingSlotEntity> GetFloorInfo(int floor)
        {
            List<ParkingSlotEntity> Slots = new List<ParkingSlotEntity>();
            NpgsqlConnection con = new NpgsqlConnection(connString);
            try
            {
                con.Open();
                string q = "SELECT slotid, index, floor, vehicletype, cost, occupied FROM public.\"ParkingSlot\" where floor=@flr";
                NpgsqlCommand cmd = new NpgsqlCommand(q, con);
                cmd.Parameters.AddWithValue("@flr", floor);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    string slotid = reader.GetString(0);
                    int index = reader.GetInt32(1);
                    int flr = reader.GetInt32(2);
                    string vehType = reader.GetString(3);
                    decimal cost = reader.GetDecimal(4);
                    bool occupied = reader.GetBoolean(5);

                    ParkingSlotEntity slot = new ParkingSlotEntity { SlotID = slotid, Index = index, Floor = flr, VehicleType = vehType, Occupied = occupied, Cost = cost };
                    Slots.Add(slot);
                }

                //this makes sure that the slots are always returned in the same order,
                // which is, as per their index(which represents the location)
                Slots.Sort(); 

                return Slots;

            } catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

    }
}
