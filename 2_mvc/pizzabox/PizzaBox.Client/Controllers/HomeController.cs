using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  [Route("/[controller]/[action]")]
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{tyler}")]

    public IActionResult Index(string tyler)
    {
      ViewBag.Name = tyler;
      ViewData["Name"] = tyler;
      TempData["Name"] = tyler;
      return View(new Pizza());
    }

    [HttpPost()]
    public IActionResult Order(Pizza p)
    {
      if (ModelState.IsValid)
      {
        ViewBag.Pizza = p;
        return View("Index", new Pizza());
      }

      return View("Index", p);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
