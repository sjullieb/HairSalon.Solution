using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {

    public void Dispose()
    {
      Stylist.ClearAll();
    }

    public StylistTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=yulia_shidlovskaya_test;";
    }

    [TestMethod]
    public void GetId_ReturnsId_Int()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      int id = 1;
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles, id);
      int result = newStylist.GetId();
      Assert.AreEqual(id, result);
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      int id = 1;
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles, id);
      string result = newStylist.GetName();
      Assert.AreEqual(name, result);
    }


    [TestMethod]
    public void GetEmail_ReturnsEmail_String()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      int id = 1;
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles, id);
      string result = newStylist.GetEmail();
      Assert.AreEqual(email, result);
    }

    [TestMethod]
    public void GetPhoneNumber_ReturnsPhoneNumber_String()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      int id = 1;
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles, id);
      string result = newStylist.GetPhoneNumber();
      Assert.AreEqual(phoneNumber, result);
    }

    [TestMethod]
    public void GetSchedule_ReturnsSchedule_String()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      int id = 1;
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles, id);
      string result = newStylist.GetSchedule();
      Assert.AreEqual(schedule, result);
    }

    [TestMethod]
    public void GetHaricutStyles_ReturnsHaricutStyles_String()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      int id = 1;
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles, id);
      string result = newStylist.GetHaircutStyles();
      Assert.AreEqual(haircutStyles, result);
    }

  }
}
