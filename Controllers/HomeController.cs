using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ThirukuralinMVC.Models;
namespace ThirukuralinMVC.Controllers;

public class HomeController : Controller
{
    private IWebHostEnvironment Environment {get; set;}
    
    public HomeController(IWebHostEnvironment _environment) => Environment = _environment;

    public IActionResult Index(int x)
    {
        
        string ChapterPath = System.IO.Path.Combine(Environment.ContentRootPath,"ThirukuralA2Z\\chapters.txt");
        if(System.IO.File.Exists(ChapterPath))
        {
            string[] ChapterLines = System.IO.File.ReadAllLines(ChapterPath);
            ViewBag.ChapterLines = ChapterLines;
        }

        string[] FileList = System.IO.Directory.GetFiles(System.IO.Path.Combine(Environment.ContentRootPath,"ThirukuralA2Z\\Thirukural"));
        for(int i = 0; i < FileList.Length; i++)
        {
            foreach(string s in FileList)
            {
                string FilePath = s;
                if (System.IO.File.Exists(FilePath) == true)
                {
                    string[] FileLine = System.IO.File.ReadAllLines(FilePath);
                    ViewBag.FileLine = FileLine;
                }
            }
            
            // int j = i+1;
            // if(x == j)
            // {
            //     string FilePath = FileList[i];
            //     string[] FileLine = System.IO.File.ReadAllLines(FilePath);
            //     ViewBag.FileLine = FileLine;
            // }
        }
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Athikarangal(int y = 0)
    {
        string[] FirstChapter = new string[38];
        string[] SecoundChapter = new string[70];
        string[] thirdChapter = new string[25];
        string ChapterPath = System.IO.Path.Combine(Environment.ContentRootPath,"ThirukuralA2Z\\chapters.txt");
        if(System.IO.File.Exists(ChapterPath))
        {
            string[] ChapterLines = System.IO.File.ReadAllLines(ChapterPath);
            if(y == 0)
            {
                ViewBag.ChapterLines = ChapterLines;
            }
            else if(y == 1)
            {
                for(int i = 0; i <= 37; i++)
                {
                    FirstChapter.SetValue(ChapterLines[i],i);   
                }
                ViewBag.ChapterLines = 0;
                ViewBag.FirstChapter = FirstChapter;
                ViewBag.SecoundChapter = 0;
                ViewBag.thirdChapter = 0; 
            }
            else if(y == 2)
            {
                for(int i = 0; i <= 69; i++)
                {
                    int j = 38 + i;
                    SecoundChapter.SetValue(ChapterLines[j],i);                      
                }
                ViewBag.ChapterLines = 0;
                ViewBag.FirstChapter = 0;
                ViewBag.SecoundChapter = SecoundChapter;
                ViewBag.thirdChapter = 0; 
            }
            else if(y == 3)
            {
                for(int i = 0; i <= 24; i++)
                {
                    int j = 109 + i;
                    thirdChapter.SetValue(ChapterLines[j],i);  
                }
                ViewBag.ChapterLines = 0;
                ViewBag.FirstChapter = 0;
                ViewBag.SecoundChapter = 0;
                ViewBag.thirdChapter = thirdChapter;  
            }
        }  

        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
