using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class Customer : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
