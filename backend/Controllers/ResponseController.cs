using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

public class ResponseController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}