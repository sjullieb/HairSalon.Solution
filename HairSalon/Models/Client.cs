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

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (name, email, phoneNumber, stylist_id) VALUES (@name, @email, @phone_number, @stylist_id);";

      MySqlParameter prmName = new MySqlParameter();
      prmName.ParameterName = "@name";
      prmName.Value = Name;
      cmd.Parameters.Add(prmName);

      MySqlParameter prmEmail = new MySqlParameter();
      prmEmail.ParameterName = "@email";
      prmEmail.Value = Email;
      cmd.Parameters.Add(prmEmail);

      MySqlParameter prmPhoneNumber = new MySqlParameter();
      prmPhoneNumber.ParameterName = "@phone_number";
      prmPhoneNumber.Value = PhoneNumber;
      cmd.Parameters.Add(prmPhoneNumber);

      MySqlParameter prmStylistId = new MySqlParameter();
      prmStylistId.ParameterName = "@stylist_id";
      prmStylistId.Value = StylistId;
      cmd.Parameters.Add(prmStylistId);

      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }

    }

  }
}
