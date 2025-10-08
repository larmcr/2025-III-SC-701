using System.Diagnostics;
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
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult MyList()
    {
        var list = new List<int>() { 0, 2, 4, 45, 3, 1, 8 };
        return View(list);
    }

    [HttpGet]
    public IActionResult MyForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult MyForm(MyProduct myProduct)
    {
        return View(myProduct);
    }

    public IActionResult MyDivisors(MyNumber myNumber)
    {
        return View(myNumber);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
