using Microsoft.AspNetCore.Mvc;

namespace sistemaVentas8.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
