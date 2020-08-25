using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaferSpacesClient.Models;

namespace SaferSpacesClient.Controllers
{
  public class EventsController : Controller
  {

    public IActionResult Index()
    {
      var allEvents = Event.GetEvents();
      return View(allEvents);
    }

    [HttpPost]
    public IActionResult Index(Event gathering)
    {
      Event.Post(gathering);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var gathering = Event.GetDetails(id);
      return View(gathering);
    }

    public IActionResult Edit(int id)
    {
      var gathering = Event.GetDetails(id);
      return View(gathering);
    }

    [HttpPost]
    public IActionResult Details(int id, Event gathering)
    {
      gathering.EventId = id;
      Event.Put(gathering);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Event.Delete(id);
      return RedirectToAction("Index");
    }
  }
}