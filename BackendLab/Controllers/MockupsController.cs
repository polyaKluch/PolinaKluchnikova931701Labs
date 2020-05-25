using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BackendLab.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BackendLab.Controllers
{
    public class MockupsController : Controller
    {
        public IActionResult Mockups()
        {
            return View();
        }
        public IActionResult Reset(Acc acc)
        {
            if (ModelState["Email"].ValidationState==ModelValidationState.Valid)
                return Redirect("ResetCon");
            return View(acc);
        }
        public IActionResult ResetCon(string value)
        {
            Acc acc = new Acc();
            if (Request.Method == "GET")
                return View();
            if ((acc.Code).ToString() == value)
                ViewData["error"] = "Password reset";
            else
            ViewData["error"] = "Wrong code";
            return View();
        }
        [HttpGet]
        public IActionResult Signup()
        {
            dateset();
            return View();
        }
        [HttpPost]
        public IActionResult Signup(Acc acc)
        {
            Acc a = new Acc();
            dateset();
            if (ModelState["FirstName"].ValidationState == ModelValidationState.Valid &
                ModelState["LastName"].ValidationState == ModelValidationState.Valid &
                ModelState["Gender"].ValidationState == ModelValidationState.Valid)
                return RedirectToAction("Signup2", acc);
            return View();
        }
        public IActionResult Signup2(Acc acc)
        {
            if (Request.Method == "GET")
                return View();
            if (ModelState["Email"].ValidationState == ModelValidationState.Valid &
                ModelState["Password"].ValidationState == ModelValidationState.Valid)
                if (acc.Password == acc.ComparePassword)
                    return View("Result", acc);
                else
                    ModelState["Password"].Errors.Add("Passwords don't match"); 
            return View();
        }
        public IActionResult Result(Acc acc)
        {
            return View(acc);
        }
        public void dateset()
        {
            string[] month = { "January", "February", "March", "April",
                "May", "June", "July", "August", "Septemer", "October", "November", "December"};
            ViewBag.MonthsSelect = new SelectList(month);

            int[] day = new int[31];
            for (int i = 0; i < 31; i++)
                day[i] = i + 1;
            ViewBag.DaysSelect = new SelectList(day);

            int[] year = new int[120];
            for (int i = 0; i < 120; i++)
                year[i] = 2020 - i;
            ViewBag.YearsSelect = new SelectList(year);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
