using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsnCategories.Models;

namespace ProductsnCategories.Controllers;

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
        ViewBag.AllProducts = _context.Products.ToList();
        return View();
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

    [HttpGet("/categories")]
    public IActionResult Categories()
    {
        ViewBag.AllCategories = _context.Categories.ToList();
        return View("Categories");
    }

    [HttpGet("/categories/{id}")]
    public IActionResult OneCategory(int id)
    {
        Category? oneCat = _context.Categories.Include(a => a.CAssociations).ThenInclude(a => a.Product).FirstOrDefault(c => c.CategoryId == id);
        List<Product> NotUsedProduct = _context.Products.ToList();

        foreach (Product p in NotUsedProduct.ToList())
        {
            foreach (Association product in oneCat.CAssociations.ToList())
            {
                if (product.Product.Name == p.Name)
                {
                    Console.WriteLine("HIT");
                    NotUsedProduct.Remove(product.Product);
                }
            }
        }
        MyViewModel AllInfo = new MyViewModel
        {
            Category = oneCat,
            AllProducts = NotUsedProduct
        };
        return View(AllInfo);
    }

    [HttpGet("/products/{id}")]
    public IActionResult OneProduct(int id)
    {
        Product? onePro = _context.Products.FirstOrDefault(c => c.ProductId == id);
        if (onePro == null)
        {
            return NotFound();
        }
        return View("OneProduct", onePro);
    }

    [HttpPost("/product/create")]
    public IActionResult CreateProduct(Product newProduct)

    {
        if (ModelState.IsValid)
        {
            _context.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpPost("/products/addCategory")]
    public IActionResult CreateAssociation(Association newAssociation)
    {

        if (ModelState.IsValid)
        {
            Console.WriteLine(newAssociation.CategoryId);
            Console.WriteLine(newAssociation.ProductId);
            _context.Add(newAssociation);
            _context.SaveChanges();
            return Redirect($"/products/{newAssociation.ProductId}");
        }

        else
        {
            return View($"/products/{newAssociation.ProductId}");
        }
    }



    [HttpPost("/category/create")]
    public IActionResult CreateCategory(Category newCategory)

    {
        if (ModelState.IsValid)
        {
            _context.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("Categories");
        }
        else
        {
            return View("Categories");
        }
    }
}
