using Microsoft.AspNetCore.Mvc;

namespace Developer_book.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
        
            return View();
        }
    }
}
