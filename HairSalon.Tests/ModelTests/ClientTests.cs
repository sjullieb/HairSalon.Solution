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
      Client newClient = new Client(name, email, phoneNumber, stylistId);
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
      Client newClient = new Client(name, email, phoneNumber, stylistId);
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
      Client newClient = new Client(name, email, phoneNumber, stylistId);
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
      Client newClient = new Client(name, email, phoneNumber, stylistId);
      int result = newClient.GetStylistId();
      Assert.AreEqual(stylistId, result);
    }

    [TestMethod]
    public void Save_SavesClientToDatabase_ClientList()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      int stylistId = 1;
      Client newClient = new Client(name, email, phoneNumber, stylistId);
      newClient.Save();

      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{newClient};

      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToClient_Id()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      int stylistId = 1;
      Client newClient = new Client(name, email, phoneNumber, stylistId);
      newClient.Save();

      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int testId = newClient.GetId();

      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Find_ReturnsClientInDatabase_Client()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      int stylistId = 1;
      Client testClient = new Client(name, email, phoneNumber, stylistId);
      testClient.Save();
      Console.WriteLine(testClient.GetId().ToString());
      Client foundClient = Client.Find(testClient.GetId());
      Console.WriteLine(foundClient.GetId().ToString());
      Assert.AreEqual(testClient, foundClient);
    }

    [TestMethod]
    public void Delete_ReturnsClientInDatabase_Client()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      int stylistId = 1;
      Client testClient = new Client(name, email, phoneNumber, stylistId);
      testClient.Save();
      testClient.Delete();

      List<Client> newList = new List<Client>{};
      List<Client> fromDatabaseList = Client.GetAll();

      CollectionAssert.AreEqual(newList, fromDatabaseList);
    }

    // [TestMethod]
    // public void Edit_UpdatesClientInDatabase_Client()
    // {
    //   string name = "Marta";
    //   string email = "marta@gmail.com";
    //   string phoneNumber = "(425)123-4567";
    //   int stylistId = 1;
    //   Client testClient = new Client(name, email, phoneNumber, stylistId);
    //   testClient.Save();
    //
    //   string newName = "Marta";
    //   string email = "marta@gmail.com";
    //   string phoneNumber = "(425)123-4567";
    //   int stylistId = 1;
    //   testClient.Edit(name, email, "(425)111-1111");
    //
    //   List<Client> newList = new List<Client>{};
    //   List<Client> fromDatabaseList = Client.GetAll();
    //
    //   CollectionAssert.AreEqual(newList, fromDatabaseList);
    // }


  }
}
