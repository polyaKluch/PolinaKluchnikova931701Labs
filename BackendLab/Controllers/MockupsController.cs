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
            if (action == "Next")
                if (ModelState.IsValid)
                {
                    TotalAndCorrectAns tawa = TotalAndCorrectAns.Instance;
                    tawa.Total += 1;
                    opernumb.Solution();
                    if (opernumb.RightOrWrong())
                        tawa.Correct += 1;
                    (tawa.Answers).Add(opernumb);
                    return View(new OperAndNumb());
                }
                else
                    return View(opernumb);
            else
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