using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtiesControllerTest
  {

    public SpecialtiesControllerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=yulia_shidlovskaya_test;";
    }
    // [HttpGet("/specialties")]
    // public ActionResult Index()
    // {
    //   return View(Specialty.GetAll());
    // }
    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      SpecialtiesController controller = new SpecialtiesController();
      ActionResult indexView = controller.Index();
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void Index_HasCorrectModelType_SpecialtyList()
    {
      SpecialtiesController controller = new SpecialtiesController();
      ViewResult indexView = controller.Index() as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<Specialty>));
    }
    // [HttpGet("/specialties/new")]
    // public ActionResult New()
    // {
    //   return View();
    // }
    [TestMethod]
    public void New_ReturnsCorrect_View_True()
    {
      SpecialtiesController controller = new SpecialtiesController();
      ActionResult indexView = controller.New();
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    // [HttpPost("/specialties")]
    // public ActionResult Create(string description)
    // {
    //   Specialty newSpecialty = new Specialty(description);
    //   newSpecialty.Save();
    //   return RedirectToAction("Index");
    // }

    [TestMethod]
    public void Create_ReturnsCorrectActionType_RedirectToActionResult()
    {
      SpecialtiesController controller = new SpecialtiesController();
      IActionResult view = controller.Create("Kids");

      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Create_RedirectsToCorrectAction_Index()
    {
      SpecialtiesController controller = new SpecialtiesController();
      RedirectToActionResult actionResult = controller.Create("Kids") as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual(result, "Index");
    }
    // [HttpGet("/specialties/{id}")]
    // public ActionResult Show(int id)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Specialty searchedSpecialty = Specialty.Find(id);
    //   model["specialty"] = searchedSpecialty;
    //   model["stylists"] = searchedSpecialty.GetSpecialtyStylists();
    //   return View(model);
    // }

    [TestMethod]
    public void Show_ReturnsCorrectView_True()
    {
      Specialty newSpecialty = new Specialty("Kids");
      newSpecialty.Save();
      int id = newSpecialty.GetId();

      SpecialtiesController controller = new SpecialtiesController();
      ActionResult indexView = controller.Show(id);
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void Show_HasCorrectModelType_Dictionary()
    {
      Specialty newSpecialty = new Specialty("Kids");
      newSpecialty.Save();
      int id = newSpecialty.GetId();

      SpecialtiesController controller = new SpecialtiesController();
      ViewResult indexView = controller.Show(id) as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    // [HttpGet("/specialties/{id}/edit")]
    // public ActionResult Edit(int id)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Specialty searchedSpecialty = Specialty.Find(id);
    //   model["specialty"] = searchedSpecialty;
    //   model["potential_stylists"] = searchedSpecialty.GetPotentialStylists();
    //   return View(model);
    // }

    [TestMethod]
    public void Edit_ReturnsCorrectView_True()
    {
      Specialty newSpecialty = new Specialty("Kids");
      newSpecialty.Save();
      int id = newSpecialty.GetId();

      SpecialtiesController controller = new SpecialtiesController();
      ActionResult indexView = controller.Edit(id);
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void Edit_HasCorrectModelType_Dictionary()
    {
      Specialty newSpecialty = new Specialty("Kids");
      newSpecialty.Save();
      int id = newSpecialty.GetId();

      SpecialtiesController controller = new SpecialtiesController();
      ViewResult indexView = controller.Edit(id) as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    // [HttpPost("/specialties/{id}")]
    // public ActionResult Update(int id, string description)
    // {
    //   Specialty searchedSpecialty = Specialty.Find(id);
    //   searchedSpecialty.Edit(description);
    //   return RedirectToAction("Show", id);
    // }
    [TestMethod]
    public void Update_ReturnsCorrectActionType_RedirectToActionResult()
    {
      Specialty newSpecialty = new Specialty("Men");
      newSpecialty.Save();
      int id = newSpecialty.GetId();

      SpecialtiesController controller = new SpecialtiesController();
      IActionResult view = controller.Update(id, "Women");

      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Update_RedirectsToCorrectAction_Show()
    {
      Specialty newSpecialty = new Specialty("Men");
      newSpecialty.Save();
      int id = newSpecialty.GetId();

      SpecialtiesController controller = new SpecialtiesController();
      RedirectToActionResult actionResult = controller.Update(id, "Women") as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual(result, "Show");
    }
    // [HttpPost("/specialties/{id}/add_stylist")]
    // public ActionResult AddStylist(int id, int stylistId)
    // {
    //   Specialty searchedSpecialty = Specialty.Find(id);
    //   searchedSpecialty.AddStylist(stylistId);
    //   return RedirectToAction("Show");
    // }

    [TestMethod]
    public void AddStylist_ReturnsCorrectActionType_RedirectToActionResult()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();
      int stylistId = newStylist.GetId();

      Specialty newSpecialty = new Specialty("Men");
      newSpecialty.Save();
      int id = newSpecialty.GetId();

      SpecialtiesController controller = new SpecialtiesController();
      IActionResult view = controller.AddStylist(id, stylistId);
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void AddStylist_RedirectsToCorrectAction_Show()
    {
      string name = "Marta";
      string email = "marta@gmail.com";
      string phoneNumber = "(425)123-4567";
      string schedule = "M-F 9-5";
      string haircutStyles = "Men Women Kids";
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();
      int stylistId = newStylist.GetId();

      Specialty newSpecialty = new Specialty("Men");
      newSpecialty.Save();
      int id = newSpecialty.GetId();

      SpecialtiesController controller = new SpecialtiesController();
      RedirectToActionResult actionResult = controller.AddStylist(id, stylistId) as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual(result, "Show");
    }
  }
}
