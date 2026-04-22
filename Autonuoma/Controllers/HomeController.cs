using Microsoft.AspNetCore.Mvc;

namespace Lab_2_DB.Controllers;

public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        ViewData["title"] = "Pagrindinis";
        return View();
    }
}
