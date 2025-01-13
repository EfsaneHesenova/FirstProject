using Microsoft.AspNetCore.Mvc;

namespace FirstProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CartItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
