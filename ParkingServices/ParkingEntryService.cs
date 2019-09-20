using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleParkingEntities;

namespace ParkingServices
{
    public class ParkingEntryService
    {
        static string connString = "Host=localhost;Username=postgres;Password=1234;Database=vehiclepark-db;";

        public static Boolean AddParkingEntry(string slotID, int vNum, DateTime timein)
        {
            NpgsqlConnection con = new NpgsqlConnection(connString);
            try
            {
                con.Open();
                string q = "insert into \"ParkingEntry\" values (@eid, @sid, @vnum, @timein)";
                NpgsqlCommand cmd = new NpgsqlCommand(q, con);
                string entryID = GenerateEntryID().ToString();
                cmd.Parameters.AddWithValue("@eid", entryID);
                cmd.Parameters.AddWithValue("@sid", slotID);
                cmd.Parameters.AddWithValue("@vnum", vNum);
                cmd.Parameters.AddWithValue("@timein", timein);
                int res = cmd.ExecuteNonQuery();

                if (res < 1)
                    return false;

                string q1 = "update \"ParkingSlot\" set occupied=@occ, currententryid=@cid where slotid=@sid";
                NpgsqlCommand cmd2 = new NpgsqlCommand(q1, con);
                cmd2.Parameters.AddWithValue("@occ", true);
                cmd2.Parameters.AddWithValue("@cid", entryID);
                cmd2.Parameters.AddWithValue("@sid", slotID);
                int res2 = cmd2.ExecuteNonQuery();

                if (res == res2)
                    return true;
                else //Revert changes to DB ?
                    return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        private static long GenerateEntryID()
        {
            DateTimeOffset offset = new DateTimeOffset(DateTime.Now);
            return offset.ToUnixTimeMilliseconds();
        }

        public static ParkingEntryEntity GetCurrentParkingEntryInfo(string slotid)
        {
            NpgsqlConnection con = new NpgsqlConnection(connString);
            try
            {
                con.Open();
                string q1 = "select currententryid from \"ParkingSlot\" where slotid=@sid";
                NpgsqlCommand cmd1 = new NpgsqlCommand(q1, con);
                cmd1.Parameters.AddWithValue("@sid", slotid);
                string entryid = cmd1.ExecuteScalar().ToString();

                if (entryid == null)
                    throw new Exception("No entry present for Slot ID = " + slotid);

                string q2 = "SELECT entryid, slotid, vehiclenumber, timein, timeout, amount FROM \"ParkingEntry\" where entryid=@eid";
                NpgsqlCommand cmd2 = new NpgsqlCommand(q2, con);
                cmd2.Parameters.AddWithValue("@eid", entryid);
                NpgsqlDataReader reader = cmd2.ExecuteReader();
                if (reader.Read())
                {
                    //string slotid = reader.GetString(1);
                    int vehNum = reader.GetInt32(2);
                    DateTime timein = reader.GetDateTime(3);
                    DateTime timeout = DateTime.MinValue;
                    if (!reader.IsDBNull(4))
                        timeout = reader.GetDateTime(4);
                    decimal amount = 0;
                    if(!reader.IsDBNull(5))
                        amount = reader.GetDecimal(5);

                    ParkingEntryEntity e = new ParkingEntryEntity { EntryID = entryid, SlotID = slotid, TimeIn = timein, TimeOut = timeout, TotalAmount = amount, VehicleNumber = vehNum };
                    return e;
                }

                throw new Exception("No entry found for Entry ID : " + entryid);

            } catch (Exception ex)
            {
                throw ex;
            } finally
            {
                con.Close();
            }

        }


        public static decimal GetTotalAmount(string entryid, DateTime timeout)
        {
            NpgsqlConnection con = new NpgsqlConnection(connString);
            try
            {
                con.Open();

                string q = "select cost from \"ParkingSlot\" where currententryid=@eid";
                NpgsqlCommand cmd = new NpgsqlCommand(q, con);
                cmd.Parameters.AddWithValue("@eid", entryid);
                decimal rate = (decimal)cmd.ExecuteScalar();

                string q1 = "select timein from \"ParkingEntry\" where entryid=@eid";
                NpgsqlCommand cmd1 = new NpgsqlCommand(q1, con);
                cmd1.Parameters.AddWithValue("@eid", entryid);
                DateTime timein = (DateTime)cmd1.ExecuteScalar();

                DateTime tout = timeout;
                double totaltime = (tout- timein).TotalHours;
                double amount = totaltime * (double)rate;

                return (decimal)amount;


            } catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            
        }

        public static Boolean FreeSlot(string slotid, DateTime tout, decimal amount)
        {
            NpgsqlConnection con = new NpgsqlConnection(connString);
            try
            {
                con.Open();
                string q1 = "select currententryid from \"ParkingSlot\" where slotid=@sid";
                NpgsqlCommand cmd1 = new NpgsqlCommand(q1, con);
                cmd1.Parameters.AddWithValue("@sid", slotid);
                string entryid = cmd1.ExecuteScalar().ToString();

                if (entryid == null)
                    throw new Exception("No entry present for Slot ID = " + slotid);

                string q2 = "update \"ParkingSlot\" set occupied=@occ, currententryid=@cid where slotid=@sid";
                NpgsqlCommand cmd2 = new NpgsqlCommand(q2, con);
                cmd2.Parameters.AddWithValue("@occ", false);
                cmd2.Parameters.AddWithValue("@cid", string.Empty);
                cmd2.Parameters.AddWithValue("@sid", slotid);
                int res2 = cmd2.ExecuteNonQuery();

                if (res2 < 1)
                    return false;

                q2 = "update \"ParkingEntry\" set timeout=@tout, amount=@amt where entryid=@eid";
                cmd2 = new NpgsqlCommand(q2, con);
                cmd2.Parameters.AddWithValue("@eid", entryid);
                cmd2.Parameters.AddWithValue("@amt", amount);
                cmd2.Parameters.AddWithValue("@tout", tout);
                int res3 = cmd2.ExecuteNonQuery();

                if (res3 == res2)
                    return true;

                throw new Exception("Could not update Parking Entry");

            } catch(Exception ex)
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
