using Microsoft.AspNetCore.Mvc;

namespace sql_deneme.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
