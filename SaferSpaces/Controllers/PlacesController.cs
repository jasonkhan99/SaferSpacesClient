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
    public IActionResult Index(string searchRequest)
    {
      var allPlaces = Place.GetPlaces(EnvironmentVariables.ApiKey, searchRequest);
      return View(allPlaces);
    }
    // public IActionResult Index()
    // {
    //   var allPlaces = Place.GetPlaces();
    //   return View(allPlaces);
    // }

    [HttpPost]
    public IActionResult Index(Place place)
    {
      Place.Post(place);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var thisPlace = Place.GetDetails(id);
      return View(thisPlace);
    }

    public IActionResult Edit(int id)
    {
      var place = Place.GetDetails(id);
      return View(place);
    }

    // is this really Post route for Edit?
    [HttpPost]
    public IActionResult Edit(int id, Place place)
    {
      place.PlaceId = id;
      Place.Put(place);
      return RedirectToAction("Details", new { id = id });
    }

    public IActionResult Delete(int id)
    {
      Place.Delete(id);
      return RedirectToAction("Index");
    }
    //need Create get and post, Details get, Edit get and post, Delete post
  }
}