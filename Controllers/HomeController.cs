using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ThirukuralinMVC.Models;
namespace ThirukuralinMVC.Controllers;

public class HomeController : Controller
{
    private IWebHostEnvironment Environment {get; set;}

    public HomeController(IWebHostEnvironment _environment) => Environment = _environment;

    public IActionResult Index()
    {
        string[] FileList = System.IO.Directory.GetFiles(System.IO.Path.Combine(Environment.ContentRootPath,"ThirukuralA2Z\\Thirukural"));
        foreach(string s in FileList)
        {
            string FilePath = s;
            if (System.IO.File.Exists(FilePath) == true)
            {
                string[] FileLine = System.IO.File.ReadAllLines(FilePath);
                ViewBag.FileLine = FileLine;
            }
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Athikarangal()
    {
        string ChapterPath = System.IO.Path.Combine(Environment.ContentRootPath,"ThirukuralA2Z\\chapters.txt");
        if(System.IO.File.Exists(ChapterPath))
        {
            string[] ChapterLines = System.IO.File.ReadAllLines(ChapterPath);
            ViewBag.ChapterLines = ChapterLines;
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
