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

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = @"SELECT * FROM clients;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string name = rdr.GetString(2);
        string email = rdr.GetString(3);
        string phoneNumber = rdr.GetString(4);
        int stylistId = rdr.GetInt32(1);
        int id = rdr.GetInt32(0);
        Client newClient = new Client(name, email, phoneNumber, stylistId, id);
        allClients.Add(newClient);
      }
      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }
      return allClients;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (name, email, phone_number, stylist_id) VALUES (@name, @email, @phone_number, @stylist_id);";

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

    public override bool Equals(System.Object otherClient)
    {
      if(!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client)otherClient;
        bool nameEquality = this.GetName().Equals(newClient.GetName());
        bool emailEquality = this.GetEmail().Equals(newClient.GetEmail());
        bool phoneNumberEquality = this.GetPhoneNumber().Equals(newClient.GetPhoneNumber());
        bool stylistIdEquality = this.GetStylistId().Equals(newClient.GetStylistId());
        bool idEquality = this.GetId().Equals(newClient.GetId());
        return (nameEquality && idEquality && emailEquality && phoneNumberEquality && stylistIdEquality);
      }
    }

    public void Edit(string newName, string newEmail, string newPhoneNumber)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE clients SET name=@name, email=@email, phone_number=@phone_number WHERE id=@id;";

      MySqlParameter prmName = new MySqlParameter();
      prmName.ParameterName = "@name";
      prmName.Value = newName;
      cmd.Parameters.Add(prmName);

      MySqlParameter prmEmail = new MySqlParameter();
      prmEmail.ParameterName = "@email";
      prmEmail.Value = newEmail;
      cmd.Parameters.Add(prmEmail);

      MySqlParameter prmPhoneNumber = new MySqlParameter();
      prmPhoneNumber.ParameterName = "@phone_number";
      prmPhoneNumber.Value = newPhoneNumber;
      cmd.Parameters.Add(prmPhoneNumber);

      MySqlParameter prmId = new MySqlParameter();
      prmId.ParameterName = "@id";
      prmId.Value = Id;
      cmd.Parameters.Add(prmId);

      cmd.ExecuteNonQuery();
      
      Name = newName;
      Email = newEmail;
      PhoneNumber = newPhoneNumber;

      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients WHERE id=@id;";

      MySqlParameter prmId = new MySqlParameter();
      prmId.ParameterName = "@id";
      prmId.Value = Id;
      cmd.Parameters.Add(prmId);

      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn!=null)
      {
        conn.Dispose();
      }
    }

    public static Client Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE id=@id;";

      MySqlParameter prmId = new MySqlParameter();
      prmId.ParameterName = "@id";
      prmId.Value = id;
      cmd.Parameters.Add(prmId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      rdr.Read();

      string name = rdr.GetString(2);
      string email = rdr.GetString(3);
      string phoneNumber = rdr.GetString(4);
      int stylistId = rdr.GetInt32(1);

      Client newClient = new Client(name, email, phoneNumber, stylistId, id);

      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }
      return newClient;
    }
  }
}
