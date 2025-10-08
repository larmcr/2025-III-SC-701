using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyFirstMvc.Models;

namespace MyFirstMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Minimal([FromRoute] int id, [FromQuery] string name)
    {
        ViewData["Id"] = id;
        ViewData["Name"] = name;
        return View();
    }

    public IActionResult WithMyModel(MyModel myModel)
    {
        return View(myModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
