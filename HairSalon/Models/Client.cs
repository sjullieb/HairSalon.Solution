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

    public Stylist (string name, string email, string phoneNumber, int stylistId, int id = 0)
    {
      Id = id;
      Name = name;
      Email = email;
      PhoneNumber = phoneNumber;
      StylistId = stylistId;
    }  
  }
}
