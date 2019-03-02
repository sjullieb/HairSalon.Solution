using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    [HttpGet("/stylists/{id}/clients/new")]
    public ActionResult New(int id)
    {
      Stylist searchedStylist = Stylist.Find(id);
      return View(searchedStylist);
    }

    [HttpGet("/stylists/{stylistId}/clients/{id}")]
    public ActionResult Show(int stylistId, int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist searchedStylist = Stylist.Find(stylistId);
      Client searchedClient = Client.Find(id);
      model.Add("stylist", searchedStylist);
      model.Add("client", searchedClient);
      return View(model);
    }

    [HttpGet("/stylists/{stylistId}/clients/{id}/edit")]
    public ActionResult Edit(int stylistId, int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist searchedStylist = Stylist.Find(stylistId);
      Client searchedClient = Client.Find(id);
      model.Add("styist", searchedStylist);
      model.Add("client", searchedClient);
      return View(model);
    }

    [HttpPost("/stylists/{stylistId}/clients/{id}")]
    public ActionResult Update(int id, int stylistId, string name, string email, string phoneNumber)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Client searchedClient = Client.Find(id);
      searchedClient.Edit(name, email, phoneNumber);
      Stylist searchedStylist = Stylist.Find(stylistId);
      model.Add("stylist", searchedStylist);
      model.Add("client", searchedClient);
      return View("Show", model);
    }
  }
}
