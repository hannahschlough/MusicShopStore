using Microsoft.AspNetCore.Mvc;

namespace MusicShopStore.Controllers
{
    public class Success : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
