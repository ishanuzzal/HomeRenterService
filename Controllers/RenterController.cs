using Microsoft.AspNetCore.Mvc;

namespace MyRent.Controllers
{
    public class RenterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
