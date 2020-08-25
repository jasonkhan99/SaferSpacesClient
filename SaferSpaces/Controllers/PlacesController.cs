using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExplorationClient.Models;

namespace SaferSpacesClient.Controller
{
  public IActionResult Index()
  {
    var allPlaces = Place.GetPlaces();
    return View(allPlaces);
  }

  //need Create get and post, Details get, Edit get and post, Delete post
}