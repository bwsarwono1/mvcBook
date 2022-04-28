using Microsoft.AspNetCore.Mvc;

namespace mvcBook.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestView()
        {
            return View();
        }
    }

   
}
