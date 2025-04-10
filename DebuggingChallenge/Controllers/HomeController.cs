﻿// SOLUTION PROJECT FOR C# ASSIGNMENT - DEBUGGING CHALLENGE
// DO NOT COPY FOR ASSIGNMENT SUBMISSION
// TRY THE ASSIGNMENT BEFORE COMING HERE

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DebuggingChallenge.Models;

namespace DebuggingChallenge.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Hint on a few errors: pay close attention to how things are named

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("user/create")]
    public IActionResult CreateUser(User newUser)
    {
        if(ModelState.IsValid)
        {
            HttpContext.Session.SetString("Username", newUser.Name);
            if(newUser.Location != null)
            {
                HttpContext.Session.SetString("Location", $"{newUser.Location}");
            } else {
                HttpContext.Session.SetString("Location", "Undisclosed");
            }
            return RedirectToAction("Generator");
        } else {
            return View("Index");
        }
    }

    [HttpGet("generator")]
    
    public IActionResult Generator()
    {
        // FIX: Incorrect session name "Name" instead of "Username"
        if(HttpContext.Session.GetString("Username") == null)
        {
            return RedirectToAction("Index");
        }
        if(HttpContext.Session.GetString("Passcode") == null)
        {
            GeneratePasscode();
        }
        // FIX: Name of cshtml and action did not match so could not find the file
        // Updated the View to list the chstml file
        return View("Generate");
    }

    [HttpPost("reset")]
    public IActionResult Reset()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    // Hint: Something isn't right here...
    [HttpPost("generate/new")]
    public IActionResult GenerateNew()
    {
        // FIX: GeneratePasscode function never called so we never make a new password
        GeneratePasscode();
        return RedirectToAction("Generator");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public void GeneratePasscode()
    {
        string passcode = "";
        string CharOptions = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string NumOptions = "0123456789";
        Random rand = new Random();
        for(int i = 1; i < 15; i++)
        {
            int odds = rand.Next(2);
            if(odds == 0)
            {
                passcode += CharOptions[rand.Next(CharOptions.Length)];
            } else {
                passcode += NumOptions[rand.Next(NumOptions.Length)];
            }
        }
        HttpContext.Session.SetString("Passcode", passcode);
    }
}