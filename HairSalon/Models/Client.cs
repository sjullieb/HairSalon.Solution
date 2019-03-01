using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    private int Id;
    private string Name;
    private string Email;
    private string PhoneNumber;
    private int StylistId;

    public Client (string name, string email, string phoneNumber, int stylistId, int id = 0)
    {
      Id = id;
      Name = name;
      Email = email;
      PhoneNumber = phoneNumber;
      StylistId = stylistId;
    }

    public int GetId()
    {
      return Id;
    }

    public string GetName()
    {
      return Name;
    }

    public string GetPhoneNumber()
    {
      return PhoneNumber;
    }

    public string GetEmail()
    {
      return Email;
    }

    public int GetStylistId()
    {
      return StylistId;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }
    }
  }
}
