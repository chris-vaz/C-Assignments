﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    // Add a private variable of type MyContext (or whatever you named your context file)
    private MyContext _context;
    // Here we can "inject" our context service into the constructor 
    // The "logger" was something that was already in our code, we're just adding around it   
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        // When our HomeController is instantiated, it will fill in _context with context
        // Remember that when context is initialized, it brings in everything we need from DbContext
        // which comes from Entity Framework Core
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        // Now any time we want to access our database we use _context   
        List<Dish> allDishes = _context.Dishes.ToList();
        ViewBag.AllDishes = _context.Dishes.ToList();
        return View();
    }

    [HttpGet("Create")]
    public IActionResult CreateOne()
    {
        // Now any time we want to access our database we use _context   
        // List<Dish> allDishes = _context.Dishes.ToList();
        return View("Create");
    }

    [HttpGet("dishes/{dishId}/edit")]
    public IActionResult EditDish(int dishId)
    {
        Dish? DishToEdit = _context.Dishes.FirstOrDefault(f => f.DishId == dishId);
        return View("EditDish", DishToEdit);
    }

    public IActionResult Privacy()
    {
        return View();
    }


    [HttpPost("dishes/{dishId}/update")]
    public IActionResult UpdateDish(int dishId, Dish UpdatedDish)
    {
        Dish? DishToUpdate = _context.Dishes.FirstOrDefault(a => a.DishId == dishId);
        if (DishToUpdate == null)
        {
            return RedirectToAction("Index");
        }

        if (ModelState.IsValid)
        {
            DishToUpdate.Chef = UpdatedDish.Chef;
            DishToUpdate.Name = UpdatedDish.Name;
            DishToUpdate.Tastiness = UpdatedDish.Tastiness;
            DishToUpdate.Calories = UpdatedDish.Calories;
            DishToUpdate.Description = UpdatedDish.Description;
            DishToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("EditDish", DishToUpdate);
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost("dishes/new")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            // We can take the Dish object created from a form submission
            // and pass the object through the .Add() method  
            // Remember that _context is our database  
            _context.Add(newDish);
            // OR _context.Dishes.Add(newMon); if we want to specify the table
            // EF Core will be able to figure out which table you meant based on the model  
            // VERY IMPORTANT: save your changes at the end! 
            _context.SaveChanges();
            return RedirectToAction("");
        }
        else
        {
            // Handle unsuccessful validations
            return View("~/Views/Home/Create.cshtml", newDish);
        }
    }

    [HttpPost("dishes/{dishId}/delete")]
    public IActionResult DeleteDish(int dishId)
    {
        Dish? DishtoDelete = _context.Dishes.SingleOrDefault(a => a.DishId == dishId);
        _context.Dishes.Remove(DishtoDelete);
        _context.SaveChanges();
        return RedirectToAction("");
    }

    [HttpGet("dishes/{id}")]
    public IActionResult ShowDish(int id)
    {
        Dish? oneDish = _context.Dishes.FirstOrDefault(a => a.DishId == id);
        return View("onedish", oneDish);
    }
}
