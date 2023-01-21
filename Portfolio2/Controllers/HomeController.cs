using Microsoft.AspNetCore.Mvc;
namespace Portfolio2.Controllers;
public class HomeController : Controller
{
    // Route declaration Option A
    // This will go to "localhost:5XXX"
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }
    
    // Route declaration Option B
    // This will go to "localhost:5XXX/user/more"
    [HttpGet("projects")]
    public ViewResult Projects()
    {
        return View("Project");
    }

    [HttpGet("contact")]
    public ViewResult Contact()
    {
        return View("Contact");
    }
    
    // Post request example
    // This will go to "localhost:5XXX/submission"
    // [HttpPost]
    // [Route("submission")]
    // // Don't worry about what the form is doing for now. We'll get to those soon!
    // public string FormSubmission(string formInput)
    // {
    // 	// Logic for post request here
    //     return "I handled a request!";
    // }
}