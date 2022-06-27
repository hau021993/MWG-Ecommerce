using Microsoft.AspNetCore.Mvc;

namespace MWG_Ecommerce.Controllers.Admin
{
    public class OrderManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
