using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      return View(Stylist.GetAll());
    }

    [HttpGet("/stylists/new")]
    public ActionResult New()
    {
      return View(Specialty.GetAll());
    }

    [HttpPost("/stylists/delete")]
    public ActionResult DeleteAll()
    {
      Stylist.DeleteAll();
      return RedirectToAction("Index");
    }

    [HttpPost("/stylists")]
    public ActionResult Create(string name, string email, string phoneNumber, string schedule, string haircutStyles, int specialtyId)
    {
      Stylist newStylist = new Stylist(name, email, phoneNumber, schedule, haircutStyles);
      newStylist.Save();
      newStylist.AddSpecialty(specialtyId);
      return RedirectToAction("Index");
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Show(int id)
    {
//      Console.WriteLine("{0}", id);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist searchedStylist = Stylist.Find(id);
      model["stylist"] = searchedStylist;
      model["clients"] = searchedStylist.GetAllClients();
      model["specialties"] = searchedStylist.GetAllStylistSpecialties();
      return View(model);
    }

    [HttpGet("/stylists/{id}/edit")]
    public ActionResult Edit(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist searchedStylist = Stylist.Find(id);
      model["stylist"] = searchedStylist;
      model["clients"] = searchedStylist.GetAllClients();
      model["potential_specialties"] = searchedStylist.GetPotentialSpecialties();
      return View(model);
    }

    [HttpPost("/stylists/{id}")]
    public ActionResult Update(int id, string name, string email, string phoneNumber, string schedule, string haircutStyles)
    {
      Stylist searchedStylist = Stylist.Find(id);
      searchedStylist.Edit(name, email,  phoneNumber, schedule, haircutStyles);
      return RedirectToAction("Show", id);
    }

    [HttpPost("/stylists/{id}/delete")]
    public ActionResult Delete(int id)
    {
      Stylist currentStylist = Stylist.Find(id);
      currentStylist.DeleteAllClients();
      currentStylist.Delete();
      return RedirectToAction("Index");
    }

    [HttpPost("/stylists/{id}/clients")]
    public ActionResult Create(int id, string name, string email, string phoneNumber)
    {
      Stylist searchedStylist = Stylist.Find(id);
      Client newClient = new Client(name, email, phoneNumber, id);
      newClient.Save();
      return RedirectToAction("Show", id);
    }

    [HttpPost("/stylists/{stylistId}/clients/{id}/delete")]
    public ActionResult Delete(int stylistId, int id)
    {
      //Console.WriteLine("{0} {1}", stylistId, id);
      Client.Find(id).Delete();
      //Console.WriteLine("{0} {1}", stylistId, id);
      //id = stylistId;
      return RedirectToAction("Show", new {id = stylistId});
    }

    [HttpPost("/stylists/{id}/add_specialty/")]
    public ActionResult AddSpecialty(int id, int specialtyId)
    {
      Stylist searchedStylist = Stylist.Find(id);
      searchedStylist.AddSpecialty(specialtyId);
      return RedirectToAction("Show");
    }
  }
}
