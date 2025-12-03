using Microsoft.AspNetCore.Mvc;
using Transportation.Interfaces;
using Transportation.Models;

namespace Transportation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index([FromServices] IAirplanes airbus, [FromServices] IAirplanes boeing)
    {
        // using var db = new CarsContext();
        // var customer = db.Customers.First((c) => c.LastName == "Mouse");
        // var ownership = db.CustomerOwnerships.First((o) => o.CustomerId == customer.CustomerId);
        // var vin = db.CarVins.First((v) => v.Vin == ownership.Vin);
        // var model = db.Models.First((m) => m.ModelId == vin.Vin);
        // var brand = db.Brands.First((b) => b.BrandId == model.BrandId);
        // ViewData["BrandModel"] = $"{brand.BrandName} - {model.ModelName}";

        ViewData["Dealer"] = "";

        ViewData["Airbus"] = $"{airbus.GetBrand}: {string.Join(" - ", airbus.GetModels)}";
        ViewData["Boeing"] = $"{boeing.GetBrand}: {string.Join(" - ", boeing.GetModels)}";

        return View();
    }
}
