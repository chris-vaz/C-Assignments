using Microsoft.AspNetCore.Mvc;
namespace ProjectName.Controllers;
public class FunController : Controller
{
    // Route declaration Option A
    // This will go to "localhost:5XXX"
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View();
    }

    // Route declaration Option B
    // This will go to "localhost:5XXX/user/more"
    [HttpGet("user/more")]
    public string UserPage()
    {
        return "Hello user";
    }


    [HttpGet("elsewhere")]

    public ViewResult ElseWhere()
    {
        return View("Index");
    }
}