using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Logging;
using SomeGoroscopes.Models;

namespace SomeGoroscopes.Controllers
{
    public class HomeController : Controller
    {
        HoroscopeContext db;
        
        public HomeController(HoroscopeContext context)
        {
            db = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        public ActionResult Watch1(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            
            int SomeId = Convert.ToInt32(id);
           
                   
                        var some = new ZSign();
                        ViewBag.ZSign = some.Characteristic[SomeId-1];
                         ViewBag.ZSignN=some.Name[SomeId - 1];
                         ViewBag.id = id;
                          return View(); 
               
                    }
             
       public IActionResult WatchToday(int? id)//get random prediction for the day
       {
            
                        if (id == null) return RedirectToAction("Index");
                        int SomeId = Convert.ToInt32(id);
                        DateTime date = DateTime.Today;
                        int today = date.Day;
                        var some = new Prediction();
                        Random rnd = new Random(today + SomeId);
                        int value = rnd.Next(1, some.ThisPrediction.Count);
                        string str = Convert.ToString(some.ThisPrediction[value - 1]);
                        ViewBag.Prediction = str;
            return View();
        }
        
       public IActionResult WatchMonth(int? id)//get random prediction for the month
        {
            if (id == null) return RedirectToAction("Index");
            int SomeId = Convert.ToInt32(id);
            DateTime date = DateTime.Today;
            int month = date.Month;
            var some = new Prediction();
            Random rnd = new Random(month + SomeId);
            int value = rnd.Next(1, some.ThisMonthPrediction.Count);
            string str = Convert.ToString(some.ThisMonthPrediction[value - 1]);
            ViewBag.MonthPrediction = str;
            return View();
        }
        
        public IActionResult About()
        {
            return View();
        }

    }
}
