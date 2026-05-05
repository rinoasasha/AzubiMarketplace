using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

public class LoginController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}