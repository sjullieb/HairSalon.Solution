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
    private string HaricutStyles;

    public Stylist (string name, string email, string phoneNumber, string scheudle, string haricutStyles, int id = 0)
    {
      Id = id;
      Name = name;
      Email = email;
      PhoneNumber = phoneNumber;
      Schedule = schedule;
      HaircutStyles = haricutStyles;
    }
  }
}
