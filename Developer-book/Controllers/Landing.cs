using Microsoft.AspNetCore.Mvc;

namespace Developer_book.Controllers
{
    public class Landing : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
