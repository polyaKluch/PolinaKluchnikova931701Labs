using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackendLab.Models;

namespace BackendLab.Controllers
{
    public class CalcController : Controller
    {
        public IActionResult PassUsingModel()
        {
            CalcClass calc = new CalcClass();
            return View(calc);
        }
        public IActionResult AccessServiceDirectly()
        {
            CalcClass calc = new CalcClass();
            return View(calc);
        }
        public IActionResult PassUsingViewData()
        {
            CalcClass calc = new CalcClass();
            ViewData["CalcClass"] = calc;
            return View();
        }

        public IActionResult PassUsingViewBag()
        {
            CalcClass calc = new CalcClass();
            ViewBag.First = calc.First;
            ViewBag.Second = calc.Second;
            ViewBag.Add = calc.Add;
            ViewBag.Sub = calc.Sub;
            ViewBag.Mult = calc.Mult;
            ViewBag.Div = calc.Div;
            return View();
        }
    }
}
