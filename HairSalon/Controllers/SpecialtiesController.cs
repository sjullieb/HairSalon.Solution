using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class SpecialtiesController : Controller
  {
    [HttpGet("/specialties")]
    public ActionResult Index()
    {
      return View(Specialty.GetAll());
    }

    [HttpGet("/specialties/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/specialties")]
    public ActionResult Create(string description)
    {
      Specialty newSpecialty = new Specialty(description);
      newSpecialty.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/specialties/{id}")]
    public ActionResult Show(int id)
    {
      Console.WriteLine("{0}", id);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty searchedSpecialty = Specialty.Find(id);
      model["specialty"] = searchedSpecialty;
      model["stylists"] = searchedSpecialty.GetSpecialtyStylists();
      return View(model);
    }

    [HttpGet("/specialties/{id}/edit")]
    public ActionResult Edit(int id)
    {
      Specialty searchedSpecialty = Specialty.Find(id);
      return View(searchedSpecialty);
    }

    [HttpPost("/specialties/{id}")]
    public ActionResult Update(int id, string description)
    {
      Specialty searchedSpecialty = Specialty.Find(id);
      searchedSpecialty.Edit(description);
      return RedirectToAction("Show", id);
    }
//----------------------------------
    // [HttpPost("/specialties/{id}/delete")]
    // public ActionResult Delete(int id)
    // {
    //   Stylist currentSpecialty = Specialty.Find(id);
    //   //currentStylist.DeleteAllClients();
    //   currentSpecialty.Delete();
    //   return RedirectToAction("Index");
    // }
    //
    // [HttpPost("/specialties/{id}/clients")]
    // public ActionResult Create(int id, string name, string email, string phoneNumber)
    // {
    //   Stylist searchedStylist = Stylist.Find(id);
    //   Client newClient = new Client(name, email, phoneNumber, id);
    //   newClient.Save();
    //   return RedirectToAction("Show", id);
    // }
    //
    // [HttpPost("/specialties/{stylistId}/clients/{id}/delete")]
    // public ActionResult Delete(int stylistId, int id)
    // {
    //   //Console.WriteLine("{0} {1}", stylistId, id);
    //   Client.Find(id).Delete();
    //   //Console.WriteLine("{0} {1}", stylistId, id);
    //   //id = stylistId;
    //   return RedirectToAction("Show", new {id = stylistId});
    // }

  }
}
