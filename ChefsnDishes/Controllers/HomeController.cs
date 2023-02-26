using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsnDishes.Models;
using System.ComponentModel.DataAnnotations;

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
        ViewBag.AllChefs = _context.Chefs.ToList();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost("/chef/create")]
    public IActionResult CreateChef(Chef newChef)

    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(newChef);
        if (!Validator.TryValidateObject(newChef, context, results, true))
        {
            foreach (var error in results)
            {
                ModelState.AddModelError(error.MemberNames.First(), error.ErrorMessage);
            }
        }
        if (ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("AddChef");
        }
    }

    [HttpGet("/chef/create")]
    public IActionResult ChefForm()
    {
        return View("AddChef");
    }

    [HttpGet("/dish/create")]
    public IActionResult DishForm()
    {
        return View("AddDish");
    }

[HttpPost("/dish/create")]
    public IActionResult CreateDish(Dish newDish)

    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(newDish);
        if (!Validator.TryValidateObject(newDish, context, results, true))
        {
            foreach (var error in results)
            {
                ModelState.AddModelError(error.MemberNames.First(), error.ErrorMessage);
            }
        }
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("AddDish");
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
