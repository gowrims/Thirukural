using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ThirukuralinMVC.Models;

namespace ThirukuralinMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string FilePath = @"C:\Users\Gowrishankar\Documents\Program\ThirukuralinMVC\திருக்குறள்";
        string[] KuralCount = System.IO.File.ReadAllLines(FilePath);
        ViewBag.Kural = KuralCount;
        ViewBag.count = KuralCount.Length;
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
}
