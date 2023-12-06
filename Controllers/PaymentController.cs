using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicShopStore.Models;

namespace MusicShopStore.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            
                return View();
           
        }
    }
}
