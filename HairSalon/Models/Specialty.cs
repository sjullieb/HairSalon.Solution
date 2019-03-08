using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Specialty
  {
    private int Id;
    private string Description;

    public Specialty (string description, int id = 0)
    {
      Id = id;
      Description = description;
    }
    public int GetId()
    {
      return Id;
    }

    public string GetDescription()
    {
      return Description;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialties;";
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
      cmd.CommandText = @"INSERT INTO specialties (description) VALUES (@description);";

      MySqlParameter prmDescription = new MySqlParameter();
      prmDescription.ParameterName = "@description";
      prmDescription.Value = Description;
      cmd.Parameters.Add(prmDescription);

      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }
    }

    public void Edit(string newDescription)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE specialties SET description=@description WHERE id=@id;";

      MySqlParameter prmId = new MySqlParameter();
      prmId.ParameterName = "@id";
      prmId.Value = Id;
      cmd.Parameters.Add(prmId);

      cmd.ExecuteNonQuery();

      Description = newDescription;

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
      cmd.CommandText = @"DELETE FROM specialties WHERE id=@id;";

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

    public static Specialty Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties WHERE id=@id;";

      MySqlParameter prmId = new MySqlParameter();
      prmId.ParameterName = "@id";
      prmId.Value = id;
      cmd.Parameters.Add(prmId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      string description = "";

      while(rdr.Read())
      {
        description = rdr.GetString(1);
      }
      Specialty newSpecialty = new Specialty(description, id);

      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }
      return newSpecialty;
    }

    public override bool Equals(System.Object otherSpecialty)
    {
      if(!(otherStylist is Specialty))
      {
        return false;
      }
      else
      {
        Specialty newSpecialty = (Specialty)otherSpecialty;
        bool descriptionEquality = this.GetDescription().Equals(newSpecialty.GetDescription());
        bool idEquality = this.GetId().Equals(newSpecialty.GetId());
        return (descriptionEquality && idEquality);
      }
    }

    public static List<Specialty> GetAll()
    {
      List<Specialty> allSpecialties = new List<Specialty>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = @"SELECT * FROM specialties;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string description = rdr.GetString(1);
        int id = rdr.GetInt32(0);
        Specialty newSpecialty = new Specialty(description, id);
        allSpecialties.Add(newSpecialty);
      }
      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }
      return allSpecialties;
    }
    //
    // public void DeleteAllClients()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"DELETE FROM clients WHERE stylist_id=@id;";
    //
    //   MySqlParameter prmId = new MySqlParameter();
    //   prmId.ParameterName = "@id";
    //   prmId.Value = Id;
    //   cmd.Parameters.Add(prmId);
    //
    //   cmd.ExecuteNonQuery();
    //   conn.Close();
    //   if (conn!=null)
    //   {
    //     conn.Dispose();
    //   }
    // }
    public void AddStylist(int stylistId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists_specialties (stylist_id, specialty_id) VALUES (@stylistId, @specialtyId);";

      MySqlParameter prmStylistId = new MySqlParameter();
      prmStylistId.ParameterName = "@stylistId";
      prmStylistId.Value = stylistId;
      cmd.Parameters.Add(prmStylistId);

      MySqlParameter prmSpecialtyId = new MySqlParameter();
      prmSpecialtyId.ParameterName = "@specialtyId";
      prmSpecialtyId.Value = Id;
      cmd.Parameters.Add(prmSpecialtyId);

      cmd.ExecuteNonQuery();
      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }
    }

    public List<Client> GetAllStylists()
    {
      List<Stylist> allStylistsForSpecialty = new List<Stylist>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT stylists.* FROM stylists JOIN stylists_specialties ss ON ss.stylist_id = stylists.id JOIN specialties sp ON sp.id = ss.specialty_id WHERE sp.id=@specialty_id;";
      MySqlParameter prmId = new MySqlParameter();
      prmId.ParameterName = "@specialty_id";
      prmId.Value = Id;
      cmd.Parameters.Add(prmId);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      string name = "";
      string email = "";
      string phoneNumber = "";
      string schedule = "";
      string haricutStyles = "";

      while(rdr.Read())
      {
        name = rdr.GetString(1);
        email = rdr.GetString(2);
        phoneNumber = rdr.GetString(3);
        schedule = rdr.GetString(4);
        haricutStyles = rdr.GetString(5);
        Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haricutStyles, id);
        allStylistsForSpecialty.Add(newStylist);
      }
      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }
      return allStylistsForSpecialty;
    }

  }
}
