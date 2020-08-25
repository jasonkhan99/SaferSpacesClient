using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaferSpacesClient.Models;

namespace SaferSpacesClient.Controllers
{
  public class PlacesController : Controller
  {
    public IActionResult Index()
    {
      var allPlaces = Places.GetPlaces();
      return View(allPlaces);
    }

    [HttpPost]
    public IActionResult Index(Places places)
    {
      Places.Post(places);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var places = Places.GetDetails(id);
      return View(places);
    }

    public IActionResult Edit(int id)
    {
      var places = Places.GetDetails(id);
      return View(places);
    }

    // is this really Post route for Edit?
    [HttpPost]
    public IActionResult Details(int id, Places places)
    {
      places.PlacesId = id;
      Places.Put(places);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Places.Delete(id);
      return RedirectToAction("Index");
    }
    //need Create get and post, Details get, Edit get and post, Delete post
  }
}