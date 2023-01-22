// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace DojoSurvey.Controllers;
public class FormController : Controller
{
    // Route declaration Option A
    // This will go to "localhost:5XXX"
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    // Post request example
    [HttpPost("process")]
    public IActionResult Process(string name, string location, string lang, string comment)
    {
        @ViewBag.Name = name;
        @ViewBag.Location = location;
        @ViewBag.Lang = lang;
        @ViewBag.Comment= comment;
        return View("results");
    }
}