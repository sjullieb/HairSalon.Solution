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
    public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      int id = 1;
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles, id);
      Assert.AreEqual(typeof(Stylist), newStylist.GetType());
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

    // [TestMethod]
    // public void GetStylists_ReturnsEmptyClientsList_ItemList()
    // {
    //   //Arrange
    //   string name = "Work";
    //   Category newCategory = new Category(name);
    //   List<Item> newList = new List<Item> { };
    //
    //   //Act
    //   List<Item> result = newCategory.GetClients();
    //
    //   //Assert
    //   CollectionAssert.AreEqual(newList, result);
    // }

    [TestMethod]
    public void GetAll_StylistEmptyAtFirst_List()
    {
      int result = Stylist.GetAll().Count;
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfStylistsAreTheSame_True()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist firstStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      Stylist secondStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      Assert.AreEqual(firstStylist, secondStylist);
    }

    [TestMethod]
    public void Save_SavesStylistToDatabase_StylistList()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();

      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{newStylist};

      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToStylist_Id()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();

      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.GetId();
      int testId = newStylist.GetId();

      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Find_ReturnsStylistInDatabase_Stylist()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist testStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      testStylist.Save();
      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      Assert.AreEqual(testStylist, foundStylist);
    }

    [TestMethod]
    public void DeleteAllClients_ReturnsEmptyClientsDatabase_EmptyClientsList()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist testStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      testStylist.Save();
      int stylistId = testStylist.GetId();

      string client1name = "Sunny";
      string client1email = "sunny@gmail.com";
      string client1phoneNumber = "(425)987-6543";
      Client testClient1 = new Client(client1name, client1email, client1phoneNumber, stylistId);
      testClient1.Save();

      string client2name = "Mike";
      string client2email = "mike@gmail.com";
      string client2phoneNumber = "(425)987-4356";
      Client testClient2 = new Client(client2name, client2email, client2phoneNumber, stylistId);
      testClient2.Save();

      testStylist.DeleteAllClients();

      List<Client> newList = new List<Client>{};
      List<Client> fromDatabaseList = Client.GetAll();

      CollectionAssert.AreEqual(newList, fromDatabaseList);
    }

    [TestMethod]
    public void Delete_ReturnsEmptyStylistsDatabase_EmptyStylistList()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist testStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      testStylist.Save();

      string client1name = "Sunny";
      string client1email = "sunny@gmail.com";
      string client1phoneNumber = "(425)987-6543";
      Client testClient1 = new Client(client1name, client1email, client1phoneNumber, testStylist.GetId());
      testClient1.Save();

      string client2name = "Mike";
      string client2email = "mike@gmail.com";
      string client2phoneNumber = "(425)987-4356";
      Client testClient2 = new Client(client2name, client2email, client2phoneNumber, testStylist.GetId());
      testClient2.Save();

      testStylist.Delete();

      List<Stylist> newList = new List<Stylist>{};
      List<Stylist> fromDatabaseList = Stylist.GetAll();

      CollectionAssert.AreEqual(newList, fromDatabaseList);
    }

    [TestMethod]
    public void Edit_UpdatesStylistInDatabase_Client()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist testStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      testStylist.Save();

      string newName = "Martina";
      string newEmail = "martina@gmail.com";
      string newPhoneNumber = "(425)111-1111";
      string newSchedule = "M,W,F 9-5";
      string newHaircutStyles = "Men Women";
      testStylist.Edit(newName, newEmail, newPhoneNumber, newSchedule, newHaircutStyles);

      Stylist editedStylist = Stylist.GetAll()[0];

      Assert.AreEqual(testStylist, editedStylist);
    }

    [TestMethod]
    public void GetAllClients_RetrievesAllClientsForStylist_ClientsList()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist testStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      testStylist.Save();

      string client1name = "Sunny";
      string client1email = "sunny@gmail.com";
      string client1phoneNumber = "(425)987-6543";
      Client testClient1 = new Client(client1name, client1email, client1phoneNumber, testStylist.GetId());
      testClient1.Save();

      string client2name = "Mike";
      string client2email = "mike@gmail.com";
      string client2phoneNumber = "(425)987-4356";
      Client testClient2 = new Client(client2name, client2email, client2phoneNumber, testStylist.GetId());
      testClient2.Save();

      List<Client> testClientList = new List<Client> {testClient1, testClient2};
      List<Client> resultClientList = testStylist.GetAllClients();

      CollectionAssert.AreEqual(testClientList, resultClientList);
    }
    [TestMethod]
    public void AddSpecialty_AddStylistSpecialtyToDB_Specialty()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();

      string description = "Kids";
      Specialty newSpecialty = new Specialty(description);
      newSpecialty.Save();

      newStylist.AddSpecialty(newSpecialty.GetId());
      Specialty testSpecialty = newStylist.GetAllStylistSpecialties()[0];

      Assert.AreEqual(testSpecialty, newSpecialty);
    }

    [TestMethod]
    public void GetStylistSpecialty_GetStylistSpecialtyFromDB_SpecialtyList()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();

      string description = "Kids";
      Specialty newSpecialty = new Specialty(description);
      newSpecialty.Save();

      newStylist.AddSpecialty(newSpecialty.GetId());
      List<Specialty> testList = new List<Specialty>{newSpecialty};
      List<Specialty> result = newStylist.GetAllStylistSpecialties();

      CollectionAssert.AreEqual(testList, result);
    }
  }
}
