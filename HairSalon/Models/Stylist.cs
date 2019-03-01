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

    public string GetSchedule()
    {
      return Schedule;
    }

    public string GetHaircutStyles()
    {
      return HaircutStyles;
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

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (name, email, schedule, haircut_styles) VALUES (@name, @email, @schedule, @haircut_styles);";

      MySqlParameter prmName = new MySqlParameter();
      prmName.ParameterName = "@name";
      prmName.Value = Name;
      cmd.Parameters.Add(prmName);

      MySqlParameter prmEmail = new MySqlParameter();
      prmEmail.ParameterName = "@email";
      prmEmail.Value = Email;
      cmd.Parameters.Add(prmEmail);

      MySqlParameter prmSchedule = new MySqlParameter();
      prmSchedule.ParameterName = "@schedule";
      prmSchedule.Value = Schedule;
      cmd.Parameters.Add(prmSchedule);

      MySqlParameter prmHaircutStyles = new MySqlParameter();
      prmHaircutStyles.ParameterName = "@haircut_styles";
      prmHaircutStyles.Value = HaircutStyles;
      cmd.Parameters.Add(prmHaircutStyles);

      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }
    }

    public void Edit(string newType)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE stylists SET name=@name, email=@email, schedule=@schedule, haircut_styles=@haircut_styles WHERE id=@id;";

      MySqlParameter prmName = new MySqlParameter();
      prmName.ParameterName = "@name";
      prmName.Value = Name;
      cmd.Parameters.Add(prmName);

      MySqlParameter prmEmail = new MySqlParameter();
      prmEmail.ParameterName = "@email";
      prmEmail.Value = Email;
      cmd.Parameters.Add(prmEmail);

      MySqlParameter prmSchedule = new MySqlParameter();
      prmSchedule.ParameterName = "@schedule";
      prmSchedule.Value = Schedule;
      cmd.Parameters.Add(prmSchedule);

      MySqlParameter prmHaircutStyles = new MySqlParameter();
      prmHaircutStyles.ParameterName = "@haircut_styles";
      prmHaircutStyles.Value = HaircutStyles;
      cmd.Parameters.Add(prmHaircutStyles);

      MySqlParameter prmId = new MySqlParameter();
      prmId.ParameterName = "@id";
      prmId.Value = Id;
      cmd.Parameters.Add(prmId);

      cmd.ExecuteNonQuery();
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
      cmd.CommandText = @"DELETE FROM stylists WHERE id=@id;";

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

    public static Stylist Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists WHERE id=@id;";

      MySqlParameter prmId = new MySqlParameter();
      prmId.ParameterName = "@id";
      prmId.Value = id;
      cmd.Parameters.Add(prmId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      rdr.Read();
      Stylist newStylist = new Stylist(rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(4), id);

      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }
      return newStylist;
    }

    public override bool Equals(System.Object otherStylist)
    {
      if(!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist)otherStylist;
        bool nameEquality = this.GetName().Equals(newStylist.GetName());
        bool emailEquality = this.GetEmail().Equals(newStylist.GetEmail());
        bool scheduleEquality = this.GetSchedule().Equals(newStylist.GetSchedule());
        bool phoneNumberEquality = this.GetPhoneNumber().Equals(newStylist.GetPhoneNumber());
        bool haircutStylesEquality = this.GetHaircutStyles().Equals(newStylist.GetHaircutStyles());
        bool idEquality = this.GetId().Equals(newStylist.GetId());
        return (nameEquality && idEquality && emailEquality && scheduleEquality && phoneNumberEquality && haircutStylesEquality);
      }
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = @"SELECT * FROM stylists;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string name = rdr.GetString(1);
        string email = rdr.GetString(2);
        string phoneNumber = rdr.GetString(3);
        string schedule = rdr.GetString(4);
        string haricutStyles = rdr.GetString(5);
        int id = rdr.GetInt32(0);
        Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haricutStyles, id);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

    public List<Client> GetAllClients()
    {
      return new List<Client>{};
    }
  }
}
