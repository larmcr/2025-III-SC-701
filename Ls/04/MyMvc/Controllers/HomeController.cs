using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using MyMvc.Models;

namespace MyMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var request = HttpContext.Request;
        ViewData["request"] = request;
        return View();
    }

    public IActionResult Privacy(string id)
    {
        // return View();
        // return id == "Luis" ? Ok() : NotFound();
        // return StatusCode(302);
        return StatusCode((int)HttpStatusCode.OK);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
