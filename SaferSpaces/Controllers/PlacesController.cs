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

    [HttpPost, ActionName("AddTestimonials")]
    public IActionResult AddNewTestimonial(string place_id, Testimonial testimonial)
    {
      if(place_id != null)
      {
        Testimonial.Post(place_id, testimonial);
      }
      return RedirectToAction("Details");
    }
    // public IActionResult AddTestimonials(string id)
    // {
    //   var place = new Place();
    //   place.Place_Id = id;
    //   return View(place);
    // }

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
    // public IActionResult AddTestimonials(string place_id, Testimonial testimonial)
    // {
    //   if(place_id != null)
    //   {
    //     PlaceTestimonial.Post(new PlaceTestimonial() {TestimonialId = testimonial.TestimonialId, Place_Id = place_id});
    //   }
    //   return RedirectToAction("Details");
    // }



    // public static void Post(Animal animal)
    // {
    //   string jsonAnimal = JsonConvert.SerializeObject(animal);
    //   var apiCallTask = ApiHelper.Post(jsonAnimal);
    // }
// [HttpPost]
//     public ActionResult AddEngineer(Machine machine, int EngineerId)
//     {
//       if(EngineerId != 0)
//       {
//         _db.EngineerMachine.Add(new EngineerMachine() {MachineId = machine.MachineId, EngineerId = EngineerId});
//       }
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

    //  [HttpPost]
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