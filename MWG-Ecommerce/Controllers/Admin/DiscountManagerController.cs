using Microsoft.AspNetCore.Mvc;

namespace MWG_Ecommerce.Controllers.Admin
{
    public class DiscountManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
