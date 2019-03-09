using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientsControllerTest
  {

    public ClientsControllerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=yulia_shidlovskaya_test;";
    }

    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      ClientsController controller = new ClientsController();
      ActionResult indexView = controller.Index();
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void Index_HasCorrectModelType_ClientsList()
    {
      ClientsController controller = new ClientsController();
      ViewResult indexView = controller.Index() as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<Client>));
    }

    [TestMethod]
    public void DeleteAll_ReturnsCorrectActionType_RedirectToActionResult()
    {
      ClientsController controller = new ClientsController();
      IActionResult view = controller.DeleteAll();

      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void DeleteAll_RedirectsToCorrectAction_Index()
    {
      ClientsController controller = new ClientsController();
      RedirectToActionResult actionResult = controller.DeleteAll() as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual(result, "Index");
    }

    [TestMethod]
    public void New_ReturnsCorrectView_True()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();
      int id = newStylist.GetId();

      ClientsController controller = new ClientsController();
      ActionResult indexView = controller.New(id);
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void New_HasCorrectModelType_Stylist()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();
      int id = newStylist.GetId();

      ClientsController controller = new ClientsController();
      ViewResult indexView = controller.New(id) as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Stylist));
    }

    [TestMethod]
    public void Show_ReturnsCorrectView_True()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist testStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      testStylist.Save();
      int stylistId = testStylist.GetId();

      string clientName = "Sunny";
      string clientEmail = "sunny@gmail.com";
      string clientPhoneNumber = "(425)987-6543";
      Client testClient = new Client(clientName, clientEmail, clientPhoneNumber, testStylist.GetId());
      testClient.Save();
      int clientId = testClient.GetId();

      ClientsController controller = new ClientsController();
      ActionResult indexView = controller.Show(stylistId, clientId);
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void Show_HasCorrectModelType_Dictionary()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist testStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      testStylist.Save();
      int stylistId = testStylist.GetId();

      string clientName = "Sunny";
      string clientEmail = "sunny@gmail.com";
      string clientPhoneNumber = "(425)987-6543";
      Client testClient = new Client(clientName, clientEmail, clientPhoneNumber, testStylist.GetId());
      testClient.Save();
      int clientId = testClient.GetId();

      ClientsController controller = new ClientsController();
      ViewResult indexView = controller.Show(stylistId, clientId) as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void Edit_ReturnsCorrectView_True()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist testStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      testStylist.Save();
      int stylistId = testStylist.GetId();

      string clientName = "Sunny";
      string clientEmail = "sunny@gmail.com";
      string clientPhoneNumber = "(425)987-6543";
      Client testClient = new Client(clientName, clientEmail, clientPhoneNumber, testStylist.GetId());
      testClient.Save();
      int clientId = testClient.GetId();

      ClientsController controller = new ClientsController();
      ActionResult indexView = controller.Edit(clientId, stylistId);
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void Edit_HasCorrectModelType_Dictionary()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist testStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      testStylist.Save();
      int stylistId = testStylist.GetId();

      string clientName = "Sunny";
      string clientEmail = "sunny@gmail.com";
      string clientPhoneNumber = "(425)987-6543";
      Client testClient = new Client(clientName, clientEmail, clientPhoneNumber, testStylist.GetId());
      testClient.Save();
      int clientId = testClient.GetId();

      ClientsController controller = new ClientsController();
      ViewResult indexView = controller.Edit(clientId, stylistId) as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void Update_ReturnsCorrectView_True()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist testStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      testStylist.Save();
      int stylistId = testStylist.GetId();

      string clientName = "Sunny";
      string clientEmail = "sunny@gmail.com";
      string clientPhoneNumber = "(425)987-6543";
      Client testClient = new Client(clientName, clientEmail, clientPhoneNumber, testStylist.GetId());
      testClient.Save();
      int clientId = testClient.GetId();

      ClientsController controller = new ClientsController();
      ActionResult indexView = controller.Update(clientId, stylistId, "Sun", "sun@hotmail.com", "(123)456-7890");
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void Update_HasCorrectModelType_Dictionary()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist testStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      testStylist.Save();
      int stylistId = testStylist.GetId();

      string clientName = "Sunny";
      string clientEmail = "sunny@gmail.com";
      string clientPhoneNumber = "(425)987-6543";
      Client testClient = new Client(clientName, clientEmail, clientPhoneNumber, testStylist.GetId());
      testClient.Save();
      int clientId = testClient.GetId();

      ClientsController controller = new ClientsController();
      ViewResult indexView = controller.Update(clientId, stylistId, "Sun", "sun@hotmail.com", "(123)456-7890") as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }
  }
}
