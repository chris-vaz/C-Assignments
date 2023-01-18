using Microsoft.AspNetCore.Mvc;
namespace Portfolio1.Controllers;
public class HomeController : Controller
{
    // Route declaration Option A
    // This will go to "localhost:5XXX"
    [HttpGet("")]
    public string Index()
    {
        return "This is my Index!";
    }
    
    // Route declaration Option B
    // This will go to "localhost:5XXX/user/more"
    [HttpGet("projects")]
    public string Projects()
    {
        return "These are my projects";
    }

    [HttpGet("contact")]
    public string Contact()
    {
        return "This is my Contacts!";
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