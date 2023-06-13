using Microsoft.AspNetCore.Mvc;

namespace MiniHospitalProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Patient()
        {
            return View();
        }
        public IActionResult Doctor()
        {
            return View();
        }


    }
}
