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
        // HttpContext.Session.SetString("Username", "Chris Vaz");
        HttpContext.Session.SetInt32("MyNum", 22);
        return View();
    }

    public IActionResult Privacy()
    {
        string? Username = HttpContext.Session.GetString("Username");
        if (Username == null)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    [HttpPost("login")]
    public IActionResult Login(string Name)
    {
        HttpContext.Session.SetString("Username", Name);
        HttpContext.Session.SetInt32("MyNum", 22);
        return RedirectToAction("Privacy");
    }

    [HttpPost("operation")]
    public IActionResult Operation(string op)
    {

        int? NewTotal = HttpContext.Session.GetInt32("MyNum");
        if(NewTotal==null){
            NewTotal=0;
        }
        if (op == "add")
        {
            NewTotal += 1;
        }
        else if (op == "minus")
        {
            NewTotal -= 1;
        }
        else if (op == "multiply")
        {
            NewTotal *= 2;
        }
        else
        {
            Random rand = new Random();
            int randNum = rand.Next(1, 11);
            NewTotal += randNum;
            HttpContext.Session.SetInt32("MyNum",(int)NewTotal);
        }
        HttpContext.Session.SetInt32("MyNum", (int)NewTotal);
        return RedirectToAction("Privacy");
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return Redirect("/");
    }
}
