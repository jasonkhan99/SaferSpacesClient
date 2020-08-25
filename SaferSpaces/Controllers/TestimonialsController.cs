using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaferSpacesClient.Models;

namespace SaferSpacesClient.Controllers
{
  public class TestimonialsController : Controller
  {
    public IActionResult Index()
    {
      var allTestimonials = Testimonial.GetTestimonials();
      return View(allTestimonials);
    }

    [HttpPost]
    public IActionResult Index(Testimonial testimonial)
    {
      Testimonial.Post(testimonial);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var testimonial = Testimonial.GetDetails(id);
      return View(testimonial);
    }

    public IActionResult Edit(int id)
    {
      var testimonial = Testimonial.GetDetails(id);
      return View(testimonial);
    }

    [HttpPost]
    public IActionResult Details(int id, Testimonial testimonial)
    {
      testimonial.TestimonialId = id;
      Testimonial.Put(testimonial);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Testimonial.Delete(id);
      return RedirectToAction("Index");
    }
  }
}

