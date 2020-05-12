using Microsoft.AspNetCore.Mvc;
using BackendLab.Models;
namespace BackendLab.Controllers
{
    public class MockupsController : Controller
    {
        [HttpGet]
        public IActionResult Quiz()
        {
            OperAndNumb opernumb = new OperAndNumb();
            return View(opernumb);
        }

        [HttpPost]
        public IActionResult Quiz(OperAndNumb opernumb, string action)
        {
            double number;
            if (double.TryParse(opernumb.YourAnswer, out number) & ModelState.IsValid)
            {
                TotalAndCorrectAns tawa = TotalAndCorrectAns.Instance;
                tawa.Total+= 1;
                opernumb.Solution(); 
                ViewData["NotANumber"] = "" + opernumb.First +  "  ||  " + opernumb.Second;
                if (opernumb.RightOrWrong())
                    tawa.Correct += 1;
                (tawa.Answers).Add(opernumb);
            }
            else
                ViewData["NotANumber"] = "Not a number!";
            if (action == "Next")
                return View(new OperAndNumb());
            return RedirectToAction("QuizResult");
        }

      

        public IActionResult QuizResult()
        {
            ViewBag.Result = TotalAndCorrectAns.Instance.Answers;
            ViewData["Correct"] = "" + TotalAndCorrectAns.Instance.Correct;
            ViewData["Total"] = "" + TotalAndCorrectAns.Instance.Total;
            return View();
        }
    }
}