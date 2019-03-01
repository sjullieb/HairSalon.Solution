using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {

    public void Dispose()
    {
      Client.ClearAll();
    }

    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=yulia_shidlovskaya_test;";
    }

    [TestMethod]
    public void GetId_ReturnsId_Int()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      int stylistId = 0;
      int id = 0;
      Client newClient = new Client(name, email, phoneNumber, stylistId, id);
      int result = newClient.GetId();
      Assert.AreEqual(id, result);
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      int stylistId = 0;
      int id = 0;
      Client newClient = new Client(name, email, phoneNumber, stylistId, id);
      string result = newClient.GetName();
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetEmail_ReturnsEmail_String()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      int stylistId = 0;
      int id = 0;
      Client newClient = new Client(name, email, phoneNumber, stylistId, id);
      string result = newClient.GetEmail();
      Assert.AreEqual(email, result);
    }

    [TestMethod]
    public void GetPhoneNumber_ReturnsPhoneNumber_String()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      int stylistId = 0;
      int id = 0;
      Client newClient = new Client(name, email, phoneNumber, stylistId, id);
      string result = newClient.GetPhoneNumber();
      Assert.AreEqual(phoneNumber, result);
    }

    [TestMethod]
    public void GetStylistId_ReturnsStylistId_Int()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      int stylistId = 0;
      int id = 0;
      Client newClient = new Client(name, email, phoneNumber, stylistId, id);
      int result = newClient.GetStylistId();
      Assert.AreEqual(stylistId, result);
    }
  }
}
