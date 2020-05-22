using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BackendLab.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BackendLab.Controllers
{
    public class ControlsController : Controller
    {
        public IActionResult Controls()
        {
            return View();

        }

        public IActionResult TextBox(string Value)
        {
            if (Request.Method == "GET")
                return View();
            ViewData["Type"] = "Text Box";
            ViewData["Value1"] = "Text";
            ViewData["Value2"] = Value;
            return View("Result");
        }
        public IActionResult TextArea(string Value)
        {
            if (Request.Method == "GET")
                return View();
            ViewData["Type"] = "Text Area";
            ViewData["Value1"] = "Text";
            ViewData["Value2"] = Value;
            return View("Result");
        }
        public IActionResult CheckBox(string Value)
        {
            if (Request.Method == "GET")
                return View();
            ViewData["Type"] = "Check Box";
            ViewData["Value1"] = "IsSelected";
            ViewData["Value2"] = Value;
            return View("Result");
        }
        public IActionResult Radio(string Value)
        {
            if (Request.Method == "GET")
                return View();
            ViewData["Type"] = "Radio";
            ViewData["Value1"] = "Month";
            ViewData["Value2"] = Value;
            return View("Result");
        }
        public IActionResult ListBox(string Value)
        {
            if (Request.Method == "GET")
                return View();
            ViewData["Type"] = "Radio";
            ViewData["Value1"] = "Month";
            ViewData["Value2"] = Value;
            return View("Result");
        }
    
        public IActionResult DropDownList(string Value)
        {
            if (Request.Method == "GET")
                return View();
            ViewData["Type"] = "Radio";
            ViewData["Value1"] = "Month";
            ViewData["Value2"] = Value;
            return View("Result");
        }
        public IActionResult Result()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
