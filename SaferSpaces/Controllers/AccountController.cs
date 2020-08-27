//allows users to register for accounts - Identity
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks; //allows us to use asynchrounous tasks
using SaferSpacesClient.ViewModels;
using SaferSpacesClient.Models;

namespace SaferSpacesClient.Controllers
{
  public class AccountController : Controller
  {
    private readonly SaferSpacesClientContext _db;
    private readonly UserManager<ApplicationUser> _userManager; //helps manage saving and updating user account information
    private readonly SignInManager<ApplicationUser> _signInManager; //provides functionality for users to log into their accounts

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, SaferSpacesClientContext db)
    {
      //inject userManager and signInManager services into the constructor so that our controller will have access to these services as needed
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public ActionResult Register()
    {
      return View();
    }

    [HttpPost] //creating user accounts will be asynchronous 
    // Task = built in class, represents async actions that haven't been completed yet
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      var user = new ApplicationUser { UserName = model.UserName };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
        return RedirectToAction("Login");//need to update
      }
      else
      {
        return View();
      }
    }

    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: true, lockoutOnFailure: false);
      if (result.Succeeded)
      {
        return RedirectToAction("Index", "Home");
      }
      else
      {
        return View();
      }
    }

    [HttpPost]
    public async Task<ActionResult> LogOff()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index", "Home");
    }
  }
}