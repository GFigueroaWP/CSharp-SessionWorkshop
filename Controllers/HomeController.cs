using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        HttpContext.Session.Clear();
        return View();
    }

    [HttpPost]
    public IActionResult Login(string Name)
    {
        HttpContext.Session.SetString("username", Name);
        HttpContext.Session.SetInt32("number", 22);
        return RedirectToAction("Dashboard");
    }
    [HttpGet("Dashboard")]
    public IActionResult Dashboard()
    {
        return View("Dashboard");
    }

    [HttpPost("AddOne")]
    public IActionResult AddOne()
    {
        int? number = HttpContext.Session.GetInt32("number");
        if (number != null)
        {
            HttpContext.Session.SetInt32("number", (int)number + 1);
        }
        return RedirectToAction("Dashboard");
    }

    [HttpPost("SubOne")]
    public IActionResult SubOne()
    {
        int? number = HttpContext.Session.GetInt32("number");
        if (number != null)
        {
            HttpContext.Session.SetInt32("number", (int)number - 1);
        }
        return RedirectToAction("Dashboard");
    }

    [HttpPost("MultTwo")]
    public IActionResult MultTwo()
    {
        int? number = HttpContext.Session.GetInt32("number");
        if (number != null)
        {
            HttpContext.Session.SetInt32("number", (int)number * 2);
        }
        return RedirectToAction("Dashboard");
    }

    [HttpPost("AddRandom")]
    public IActionResult AddRandom()
    {
        Random rand = new Random();
        int? number = HttpContext.Session.GetInt32("number");
        if (number != null)
        {
            HttpContext.Session.SetInt32("number", (int)number + rand.Next(1, 11));
        }
        return RedirectToAction("Dashboard");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


