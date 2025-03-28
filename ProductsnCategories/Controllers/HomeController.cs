﻿using System.Diagnostics;
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
        Category? oneCat = _context.Categories.Include(a => a.CAssociations).ThenInclude(b => b.Product).FirstOrDefault(c => c.CategoryId == id);
        List<Product> allProducts = _context.Products.ToList();
        MyViewModel AllInfo = new MyViewModel
        {
            Category = oneCat,
            AllProducts = allProducts
        };
        return View("OneCategory", AllInfo);
    }

    [HttpGet("/products/{id}")]
    public IActionResult OneProduct(int id)
    {
        Product? onePro = _context.Products.Include(a => a.PAssociations).ThenInclude(b => b.Category).FirstOrDefault(c => c.ProductId == id);
        List<Category> allCategories = _context.Categories.ToList();
        MyViewModel AllInfop = new MyViewModel
        {
            Product = onePro,
            AllCategories = allCategories
        };
        return View("OneProduct", AllInfop);
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

    // [HttpPost("/products/addCategory")]
    // public IActionResult CreateAssociation(Association newAssociation)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         // newAssociation.CategoryId = categoryId;
    //         _context.Add(newAssociation);
    //         _context.SaveChanges();
    //         return RedirectToAction("Index");
    //     }
    //     else
    //     {
    //         return View("Privacy");
    //     }
    // }

    // This is the POST route for creating a Category association 
    [HttpPost("association/create")]
    public IActionResult CreateAssociation(Association newAssociation)
    {
        if (ModelState.IsValid)
        {
            _context.Associations.Add(newAssociation);
            _context.SaveChanges();
            return RedirectToAction("Categories");
        }

        else
        {
            return View("OneCategory");
        }

    }

    // This is the POST route for creating a product association 
    [HttpPost("associationp/create")]
    public IActionResult CreateAssociationP(Association newAssociation)
    {
        if (ModelState.IsValid)
        {
            _context.Associations.Add(newAssociation);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        else
        {
            return View("OneProduct");
        }

    }

    // [HttpPost("/categories/addProduct")]
    // public IActionResult CreateAssociationP(Association newAssociation)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         // newAssociation.CategoryId = categoryId;
    //         _context.Add(newAssociation);
    //         _context.SaveChanges();
    //         return RedirectToAction("Index");
    //     }
    //     else
    //     {
    //         return View("Privacy");
    //     }
    // }



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
