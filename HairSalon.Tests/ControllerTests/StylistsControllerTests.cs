using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistsControllerTest
  {

    public StylistsControllerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=yulia_shidlovskaya_test;";
    }

    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      StylistsController controller = new StylistsController();
      ActionResult indexView = controller.Index();
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void Index_HasCorrectModelType_StylistsList()
    {
      StylistsController controller = new StylistsController();
      ViewResult indexView = controller.Index() as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<Stylist>));
    }

    [TestMethod]
    public void New_ReturnsCorrect_View_True()
    {
      StylistsController controller = new StylistsController();
      ActionResult indexView = controller.New();
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void New_HasCorrectModelType_SpecialtiesList()
    {
      StylistsController controller = new StylistsController();
      ViewResult indexView = controller.New() as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<Specialty>));
    }

    [TestMethod]
    public void Show_ReturnsCorrectView_True()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();
      int id = newStylist.GetId();

      StylistsController controller = new StylistsController();
      ActionResult indexView = controller.Show(id);
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
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();
      int id = newStylist.GetId();

      StylistsController controller = new StylistsController();
      ViewResult indexView = controller.Show(id) as ViewResult;
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
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();
      int id = newStylist.GetId();

      StylistsController controller = new StylistsController();
      ActionResult indexView = controller.Edit(id);
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
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();
      int id = newStylist.GetId();

      StylistsController controller = new StylistsController();
      ViewResult indexView = controller.Edit(id) as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void Create_ReturnsCorrectActionType_RedirectToActionResult()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";

      Specialty newSpecialty = new Specialty("Kids");
      newSpecialty.Save();

      StylistsController controller = new StylistsController();
      IActionResult view = controller.Create(name, email, phoneNumber, schedule, haircutStyles, newSpecialty.GetId());

      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Create_RedirectsToCorrectAction_Index()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";

      Specialty newSpecialty = new Specialty("Kids");
      newSpecialty.Save();

      StylistsController controller = new StylistsController();
      RedirectToActionResult actionResult = controller.Create(name, email, phoneNumber, schedule, haircutStyles, newSpecialty.GetId()) as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual(result, "Index");
    }

    [TestMethod]
    public void Update_ReturnsCorrectActionType_RedirectToActionResult()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();
      int id = newStylist.GetId();

      StylistsController controller = new StylistsController();
      IActionResult view = controller.Update(id, name, email, phoneNumber, schedule, haircutStyles);
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Update_RedirectsToCorrectAction_Show()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();
      int id = newStylist.GetId();

      StylistsController controller = new StylistsController();
      RedirectToActionResult actionResult = controller.Update(id, name, email, phoneNumber, schedule, haircutStyles) as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual(result, "Show");
    }

    [TestMethod]
    public void Delete_ReturnsCorrectActionType_RedirectToActionResult()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();
      int id = newStylist.GetId();

      StylistsController controller = new StylistsController();
      IActionResult view = controller.Delete(id);
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Delete_RedirectsToCorrectAction_Index()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();
      int id = newStylist.GetId();

      StylistsController controller = new StylistsController();
      RedirectToActionResult actionResult = controller.Delete(id) as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual(result, "Index");
    }

    // creates client for a stylist
    [TestMethod]
    public void Create_Client_RedirectsToCorrectAction_Show()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();
      int id = newStylist.GetId();

      string clientName = "Mike";
      string clientEmail = "mike@gmail.com";
      string clientPhoneNumber = "(425)345-6789";

      StylistsController controller = new StylistsController();
      RedirectToActionResult actionResult = controller.Create(id, clientName, clientEmail, clientPhoneNumber) as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual(result, "Show");
    }

    // creates client for a stylist
    [TestMethod]
    public void Create_Client_ReturnsCorrectActionType_RedirectToActionResult()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();
      int stylistId = newStylist.GetId();

      string clientName = "Mike";
      string clientEmail = "mike@gmail.com";
      string clientPhoneNumber = "(425)111-2222";

      StylistsController controller = new StylistsController();
      IActionResult view = controller.Create(stylistId, clientName, clientEmail, clientPhoneNumber);
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Delete_Client_ReturnsCorrectActionType_RedirectToActionResult()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();
      int stylistId = newStylist.GetId();

      string clientName = "Sunny";
      string clientEmail = "sunny@gmail.com";
      string clientPhoneNumber = "(425)987-6543";
      Client testClient = new Client(clientName, clientEmail, clientPhoneNumber, newStylist.GetId());
      testClient.Save();
      int clientId = testClient.GetId();


      StylistsController controller = new StylistsController();
      IActionResult view = controller.Delete(clientId, stylistId);
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Delete_Client_RedirectsToCorrectAction_Show()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();
      int stylistId = newStylist.GetId();

      string clientName = "Sunny";
      string clientEmail = "sunny@gmail.com";
      string clientPhoneNumber = "(425)987-6543";
      Client testClient = new Client(clientName, clientEmail, clientPhoneNumber, newStylist.GetId());
      testClient.Save();
      int clientId = testClient.GetId();

      StylistsController controller = new StylistsController();
      RedirectToActionResult actionResult = controller.Delete(clientId, stylistId) as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual(result, "Show");
    }

    [TestMethod]
    public void AddSpecialty_ReturnsCorrectActionType_RedirectToAction()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();
      int stylistId = newStylist.GetId();

      Specialty newSpecialty = new Specialty("Kids");
      newSpecialty.Save();

      StylistsController controller = new StylistsController();
      IActionResult view = controller.AddSpecialty(stylistId, newSpecialty.GetId());
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void AddSpecialty_RedirectsToCorrectAction_Show()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();
      int stylistId = newStylist.GetId();

      Specialty newSpecialty = new Specialty("Kids");
      newSpecialty.Save();

      StylistsController controller = new StylistsController();
      RedirectToActionResult actionResult = controller.AddSpecialty(stylistId, newSpecialty.GetId()) as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual(result, "Show");
    }

    [TestMethod]
    public void DeleteAll_ReturnsCorrectActionType_RedirectToActionResult()
    {
      StylistsController controller = new StylistsController();
      IActionResult view = controller.DeleteAll();
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void DeleteAll_RedirectsToCorrectAction_Index()
    {
      StylistsController controller = new StylistsController();
      RedirectToActionResult actionResult = controller.DeleteAll() as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual(result, "Index");
    }
  }
}
