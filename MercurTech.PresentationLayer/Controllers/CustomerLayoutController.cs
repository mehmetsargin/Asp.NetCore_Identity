using Microsoft.AspNetCore.Mvc;

namespace MercurTech.PresentationLayer.Controllers
{
    public class CustomerLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
