using Microsoft.AspNetCore.Mvc;

namespace MWG_Ecommerce.Controllers.Admin
{
    public class CategoryManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
