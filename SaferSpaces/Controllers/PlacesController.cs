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
      var allPlaces = Place.GetPlaces();
      return View(allPlaces);
    }

    public IActionResult Details(int id)
    {
      var place = Place.GetDetails(id);
      return View(place);
    }
    //need Create get and post, Details get, Edit get and post, Delete post
  }
}