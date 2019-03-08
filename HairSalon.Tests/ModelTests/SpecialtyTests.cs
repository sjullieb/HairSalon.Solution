using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTest : IDisposable
  {

    public void Dispose()
    {
      Specialty.ClearAll();
    }

    public SpecialtyTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=yulia_shidlovskaya_test;";
    }

    [TestMethod]
    public void SpecialtyConstructor_CreatesInstanceOfSpecialty_Specialty()
    {
      string description = "Kids";
      int id = 1;
      Specialty newSpecialty = new Specialty(description, id);
      Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
    }

    [TestMethod]
    public void GetId_ReturnsId_Int()
    {
      string description = "Kids";
      int id = 1;
      Specialty newSpecialty = new Specialty(description, id);
      int result = newSpecialty.GetId();
      Assert.AreEqual(id, result);
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      string description = "Kids";
      int id = 1;
      Specialty newSpecialty = new Specialty(description, id);
      string result = newSpecialty.GetDescription();
      Assert.AreEqual(description, result);
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
    public void GetAll_SpecialtiesEmptyAtFirst_List()
    {
      int result = Specialty.GetAll().Count;
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfSpecialtiesAreTheSame_True()
    {
      string description = "Kids";
      Specialty firstSpecialty = new Specialty(description);
      Specialty secondSpecialty = new Specialty(description);
      Assert.AreEqual(firstSpecialty, secondSpecialty);
    }

    [TestMethod]
    public void Save_SavesSpecialtyToDatabase_SpecialtyList()
    {
      string description = "Kids";
      Specialty newSpecialty = new Specialty(description);
      newSpecialty.Save();

      List<Specialty> result = Specialty.GetAll();
      List<Specialty> testList = new List<Specialty>{newSpecialty};

      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToSpecialty_Id()
    {
      string description = "Kids";
      Specialty newSpecialty = new Specialty(description);
      newSpecialty.Save();

      Specialty savedSpecialty = Specialty.GetAll()[0];

      int result = savedSpecialty.GetId();
      int testId = newSpecialty.GetId();
      Console.WriteLine("{0} {1}", result, testId);
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Find_ReturnsSpecialtyFromDatabase_Specialty()
    {
      string description = "Kids";
      Specialty testSpecialty = new Specialty(description);
      testSpecialty.Save();
      Specialty foundSpecialty = Specialty.Find(testSpecialty.GetId());

      Assert.AreEqual(testSpecialty, foundSpecialty);
    }

    // [TestMethod]
    // public void DeleteAllClients_ReturnsEmptyClientsDatabase_EmptyClientsList()
    // {
    //   string name = "Marta";
    //   string email = "marta@gmail.com";
    //   string phoneNumber = "(425)123-4567";
    //   string schedule = "M-F 9-5";
    //   string haircutStyles = "Men Women Kids";
    //   Stylist testStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
    //   testStylist.Save();
    //   int stylistId = testStylist.GetId();
    //
    //   string client1name = "Sunny";
    //   string client1email = "sunny@gmail.com";
    //   string client1phoneNumber = "(425)987-6543";
    //   Client testClient1 = new Client(client1name, client1email, client1phoneNumber, stylistId);
    //   testClient1.Save();
    //
    //   string client2name = "Mike";
    //   string client2email = "mike@gmail.com";
    //   string client2phoneNumber = "(425)987-4356";
    //   Client testClient2 = new Client(client2name, client2email, client2phoneNumber, stylistId);
    //   testClient2.Save();
    //
    //   testStylist.DeleteAllClients();
    //
    //   List<Client> newList = new List<Client>{};
    //   List<Client> fromDatabaseList = Client.GetAll();
    //
    //   CollectionAssert.AreEqual(newList, fromDatabaseList);
    // }

    // [TestMethod]
    // public void Delete_ReturnsEmptyStylistsDatabase_EmptyStylistList()
    // {
    //   string name = "Marta";
    //   string email = "marta@gmail.com";
    //   string phoneNumber = "(425)123-4567";
    //   string schedule = "M-F 9-5";
    //   string haircutStyles = "Men Women Kids";
    //   Stylist testStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
    //   testStylist.Save();
    //
    //   string client1name = "Sunny";
    //   string client1email = "sunny@gmail.com";
    //   string client1phoneNumber = "(425)987-6543";
    //   Client testClient1 = new Client(client1name, client1email, client1phoneNumber, testStylist.GetId());
    //   testClient1.Save();
    //
    //   string client2name = "Mike";
    //   string client2email = "mike@gmail.com";
    //   string client2phoneNumber = "(425)987-4356";
    //   Client testClient2 = new Client(client2name, client2email, client2phoneNumber, testStylist.GetId());
    //   testClient2.Save();
    //
    //   testStylist.Delete();
    //
    //   List<Stylist> newList = new List<Stylist>{};
    //   List<Stylist> fromDatabaseList = Stylist.GetAll();
    //
    //   CollectionAssert.AreEqual(newList, fromDatabaseList);
    // }

    [TestMethod]
    public void Edit_UpdatesSpecialtyInDatabase_Specialty()
    {
      string description = "Kids";
      Specialty testSpecialty = new Specialty(description);
      testSpecialty.Save();

      string newDescription = "Men";
      testSpecialty.Edit(newDescription);

      Specialty editedSpecialty = Specialty.GetAll()[0];

      Assert.AreEqual(testSpecialty, editedSpecialty);
    }
    [TestMethod]
    public void AddStylist_AddStylistWithSpecialtyToDB_Stylist()
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

      newSpecialty.AddStylist(newStylist.GetId());
      Stylist testStylist = newSpecialty.GetSpecialtyStylists()[0];

      Assert.AreEqual(testStylist, newStylist);
    }

    [TestMethod]
    public void GetSpecialtyStylists_GetStylistsWithSpecialtyFromDB_StylistList()
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

      newSpecialty.AddStylist(newStylist.GetId());
      List<Stylist> testList = new List<Stylist>{newStylist};
      List<Stylist> result = newSpecialty.GetSpecialtyStylists();

      CollectionAssert.AreEqual(testList, result);
    }
    //
    // [TestMethod]
    // public void GetItems_RetrievesAllItemsWithCategory_ItemList()
    // {
    //   string name = "Marta";
    //   string email = "marta@gmail.com";
    //   string phoneNumber = "(425)123-4567";
    //   string schedule = "M-F 9-5";
    //   string haircutStyles = "Men Women Kids";
    //   Stylist testStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
    //   testStylist.Save();
    //
    //   string client1name = "Sunny";
    //   string client1email = "sunny@gmail.com";
    //   string client1phoneNumber = "(425)987-6543";
    //   Client testClient1 = new Client(client1name, client1email, client1phoneNumber, testStylist.GetId());
    //   testClient1.Save();
    //
    //   string client2name = "Mike";
    //   string client2email = "mike@gmail.com";
    //   string client2phoneNumber = "(425)987-4356";
    //   Client testClient2 = new Client(client2name, client2email, client2phoneNumber, testStylist.GetId());
    //   testClient2.Save();
    //
    //   List<Client> testClientList = new List<Client> {testClient1, testClient2};
    //   List<Client> resultClientList = testStylist.GetAllClients();
    //
    //   CollectionAssert.AreEqual(testClientList, resultClientList);
    // }
  }
}
