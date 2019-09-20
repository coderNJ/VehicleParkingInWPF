using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleParkingProject
{
    class TemporaryClass
    {
        //string connString = ConfigurationManager.ConnectionStrings["PostGreSQL"].ToString();
        //public ParkFloorViewModel(int floor)
        //{
        //Slots = new ObservableCollection<ParkingSlot>();
        //get all rows with floor 
        //NpgsqlConnection con = new NpgsqlConnection(connString);
        //try
        //{
        //    con.Open();
        //    string q = "SELECT slotid, index, floor, vehicletype, cost, occupied FROM public.\"ParkingSlot\" where floor=@flr";
        //    NpgsqlCommand cmd = new NpgsqlCommand(q, con);
        //    cmd.Parameters.AddWithValue("@flr", floor);
        //    NpgsqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        string slotid = reader.GetString(0);
        //        int index = reader.GetInt32(1);
        //        int flr = reader.GetInt32(2);
        //        string vehType = reader.GetString(3);
        //        decimal cost = reader.GetDecimal(4);
        //        bool occupied = reader.GetBoolean(5);

        //        Slots.Add(new ParkingSlot { SlotID = slotid, Index = index, Floor = flr, Cost = cost, VehicleType = vehType, Occupied = occupied });

        //    }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
    }
}
