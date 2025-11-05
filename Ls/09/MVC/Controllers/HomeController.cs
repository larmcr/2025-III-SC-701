using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers;

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

    public IActionResult Cart()
    {
        var products = new List<ProductModel>();
        var random = new Random();
        string[] items = ["Carritos", "Guitarra", "Connect4"];
        items.ToList().ForEach(name =>
        {
            products.Add(new ProductModel
            {
                Id = random.Next(),
                Name = name,
                Price = random.NextDouble() * 1000,
            });
        });
        var cart = new CartModel
        {
            Products = products
        };
        return View(cart);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
