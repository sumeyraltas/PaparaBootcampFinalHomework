using Microsoft.AspNetCore.Mvc;

namespace PaparaBootcampFinalHomework.Controllers
{
    public class MonthlyExpenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
