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
  }
}
