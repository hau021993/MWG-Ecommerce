using Microsoft.AspNetCore.Mvc;

namespace MWG_Ecommerce.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
