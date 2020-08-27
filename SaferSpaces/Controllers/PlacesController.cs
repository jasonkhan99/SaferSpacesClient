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
    public IActionResult Details(string id)
    {
      var specificPlace = Place.GetDetails(EnvironmentVariables.ApiKey, id);
      Console.WriteLine(specificPlace);
      return View(specificPlace);
    }

    public IActionResult AddTestimonials()
    {
      return View();
    }

    public IActionResult AddEvents()
    {
      return View();
    }

    // [HttpPost, ActionName("AddEvents")]
    // public ActionResult ConfirmAddEvents(int Place_Id, Event gathering)
    // {
      // if(Place_Id != 0)
      // {
      //   Add the join relationship to the database EventPlace
      // }
      // then save the changes
    //   return RedirectToAction("Index");
    // }

    // [HttpPost]
    // public IActionResult Create(Place place)
    // {
    //   Place.Post(place);
    //   return View();
    // }

  //  [HttpPost]
  //   public ActionResult Edit(Item item, int CategoryId)
  //   {
  //     if (CategoryId != 0)
  //     {
  //       _db.CategoryItem.Add(new CategoryItem() { CategoryId = CategoryId, ItemId = item.ItemId });
  //     }
  //     _db.Entry(item).State = EntityState.Modified;
  //     _db.SaveChanges();
  //     return RedirectToAction("Index");
  //   }

    // public IActionResult Details(int id)
    // {
    //   var thisPlace = Place.GetDetails(id);
    //   return View(thisPlace);
    // }

    // public IActionResult Edit(int id)
    // {
    //   var place = Place.GetDetails(id);
    //   return View(place);
    // }

    // // is this really Post route for Edit?
    // [HttpPost]
    // public IActionResult Edit(int id, Place place)
    // {
    //   place.PlaceId = id;
    //   Place.Put(place);
    //   return RedirectToAction("Details", new { id = id });
    // }

    // public IActionResult Delete(int id)
    // {
    //   Place.Delete(id);
    //   return RedirectToAction("Index");
    // }
    //need Create get and post, Details get, Edit get and post, Delete post
  }
}