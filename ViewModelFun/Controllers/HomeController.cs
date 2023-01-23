using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    [HttpGet("user")]
    public IActionResult AUser()
    {
        User newUser = new User()
        {
            FirstName = "Neil",
            LastName = "Gaiman"
        };
        return View("User", newUser);
    }
    [HttpGet("users")]
    public IActionResult AUsers()
    {
        List<string> allUsers = new List<string>();
        allUsers.Add("Neil Gaiman");
        allUsers.Add("Terry Pratchet");
        allUsers.Add("Jane Austen");
        allUsers.Add("Stephen King");
        allUsers.Add("Mary Shelley");
        return View("Users", allUsers);
    }
    [HttpGet("number")]
    public IActionResult ANumber()
    {
        List<int> numbers = new List<int>();
        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(10);
        numbers.Add(21);
        numbers.Add(8);
        numbers.Add(7);
        numbers.Add(3);
        var model = new NumberModel { Numbers = numbers };
        return View("Number",model);
    }
}
