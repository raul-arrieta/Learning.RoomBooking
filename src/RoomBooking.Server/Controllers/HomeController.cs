using Microsoft.AspNetCore.Mvc;

namespace RoomBooking.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}