using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    private int Id;
    private string Name;
    private string Email;
    private string PhoneNumber;
    private string Schedule;
    private string HaircutStyles;

    public Stylist (string name, string email, string phoneNumber, string schedule, string haricutStyles, int id = 0)
    {
      Id = id;
      Name = name;
      Email = email;
      PhoneNumber = phoneNumber;
      Schedule = schedule;
      HaircutStyles = haricutStyles;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }
    }
  }
}
