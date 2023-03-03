using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Wedding_Planner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Wedding_Planner.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("users/create")]
    public IActionResult CreateUser(User newUser)
    {
        if (ModelState.IsValid)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserID", newUser.UserId);
            return RedirectToAction("Success");
        }
        else
        {
            Console.WriteLine("Invalid");
            return View("Index");
        }
    }


    [HttpPost("users/login")]
    public IActionResult LoginUser(LoginUser loguser)
    {
        if (ModelState.IsValid)
        {
            // Look up our user in the database
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == loguser.LEmail);
            // Verifying if user exists
            if (userInDb == null)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("Index");
            }
            // Verify the password matches what's in the database
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            var result = hasher.VerifyHashedPassword(loguser, userInDb.Password, loguser.LPassword);
            if (result == 0)
            {
                // A failure, We did not use the right password
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("Index");
            }
            else
            {
                // Set session and head to Success
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                return RedirectToAction("Success");
            }
        }
        else
        {
            return View("Index");
        }
    }

    [HttpPost("wedding/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {

        if (ModelState.IsValid)
        {

            _context.Weddings.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction("Success");
        }

        else
        {
            return View("PlanWedding");
        }
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [SessionCheck]
    [HttpGet(("success"))]
    public IActionResult Success()
    {
        MyViewModel AllWeddingInfo = new MyViewModel
        {
            AllWeddings = _context.Weddings.Include(a => a.GuestList).ToList(),
        };
        return View(AllWeddingInfo);
    }

    [HttpGet("plan")]
    public IActionResult PlanWedding()
    {
        return View();
    }

    [HttpPost("wedding/{WeddingId}/delete")]
    public IActionResult DeleteWedding(int WeddingId)
    {
        Wedding? WeddingToDelete = _context.Weddings.FirstOrDefault(w => w.WeddingId == WeddingId);

        _context.Weddings.Remove(WeddingToDelete);

        _context.SaveChanges();

        return RedirectToAction("Success");
    }

    [HttpPost("association/create")]
    public IActionResult CreateAssociation(Association newAssociation)
    {
        if (ModelState.IsValid)
        {
            _context.Associations.Add(newAssociation);
            _context.SaveChanges();
            return RedirectToAction("Success");
        }

        else
        {
            return View("Success");
        }

    }


    [HttpPost("association/{AssociationId}/delete")]
    public IActionResult DeleteAssociation(int AssociationId)
    {
        Association? AssociationToDelete = _context.Associations.FirstOrDefault(a => a.AssociationId == AssociationId);

        _context.Associations.Remove(AssociationToDelete);

        _context.SaveChanges();

        return RedirectToAction("Success");
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
// User authentication - This section allows only logged-in users to view any pages
// beyond the logn/register page

// Anyone who is not logged in and who attempts to access any other pages should be 
// redirected to the login page
public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        if (userId == null)
        {
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}