using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsnDishes.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ChefsnDishes.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.AllChefs = _context.Chefs.Include(dishes => dishes.allDishes).ToList();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost("/chef/create")]
    public IActionResult CreateChef(Chef newChef)

    {
        if (ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            // MyViewModel MyModel = new MyViewModel{
            //     AllChefs=_context.Chefs.ToList()
            // };
            return View("AddChef");
        }
    }

    [HttpGet("/chef/create")]
    public IActionResult ChefForm()
    {
        return View("AddChef");
    }

    [HttpGet("/dishes")]
    public IActionResult AllDishes()
    {
        ViewBag.AllDishes = _context.Dishes.ToList();
        return View("Dishes");
    }

    [HttpGet("/dish/create")]
    public IActionResult AddDish()
    {
        // ViewBag.AllDishes = _context.Dishes.ToList();
        ViewBag.AllChefs = _context.Chefs.ToList();
        return View("AddDish");
    }

    [HttpPost("/dish/create")]
    public IActionResult CreateDish(Dish newDish)

    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            // MyViewModel MyModel = new MyViewModel
            // {
            //     AllChefs = _context.Chefs.ToList()
            // };
            // ViewBag.AllDishes = _context.Dishes.ToList();
            ViewBag.AllChefs = _context.Chefs.ToList();
            return View("AddDish");
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
