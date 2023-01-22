using Microsoft.AspNetCore.Mvc;
namespace Portfolio2.Controllers;
public class TimeController : Controller
{
    // Route declaration Option A
    // This will go to "localhost:5XXX"
    [HttpGet("")]
    public ActionResult Index()
    {
        DateTime CurrentTime = DateTime.Now;
        DateTime EndDate = new DateTime(2023,1,30);

        TimeSpan remaining=EndDate-CurrentTime;

        int remainingDays=(int)remaining.TotalDays;
        ViewData["RemainingDays"]=remainingDays;
        ViewData["CurrentTime"]=CurrentTime;
        ViewData["EndDate"]=EndDate;
        return View();
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
    
}