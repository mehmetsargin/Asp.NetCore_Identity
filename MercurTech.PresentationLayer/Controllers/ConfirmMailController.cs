using MercurTech.EntityLayer.Concrete;
using MercurTech.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MercurTech.PresentationLayer.Controllers
{
	public class ConfirmMailController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
		public IActionResult Index()
		{
			var value = TempData["Mail"];
            ViewBag.v = value;
			return View();
		}

		[HttpPost]
        public async Task <IActionResult> Index(ConfirmMailViewModel confirmMailViewModel)
        {
            //var value = "mehmetsargin456@gmail.com";
            var user = await _userManager.FindByEmailAsync(confirmMailViewModel.Mail);
            if(user.ConfirmCode == confirmMailViewModel.ConfirmCode)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
