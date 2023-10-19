using MailKit.Net.Smtp;
using MercurTech.DtoLayer.Dtos.AppUserDtos;
using MercurTech.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace MercurTech.PresentationLayer.Controllers
{

    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            if(ModelState.IsValid)
            {
                Random random = new Random();
                int code;
                code= random.Next(100000, 1000000);
				AppUser appUser = new AppUser();
                {
                    appUser.UserName = appUserRegisterDto.Username;
                    appUser.Name = appUserRegisterDto.Name;
                    appUser.Surname = appUserRegisterDto.Surname;
                    appUser.Email = appUserRegisterDto.Email;
                    appUser.City = "sd";
                    appUser.ImageUrl = "sad";
                    appUser.District = "ds";
                    appUser.ConfirmCode = code;
                }
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                if (result.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Mercur Tech Admin", "mehmetsrgnn@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User",appUser.Email);

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Kayıt işlemini tamamlamak için onay kodunuz: " + code;
                    mimeMessage.Body=bodyBuilder.ToMessageBody();

                    mimeMessage.Subject = "MercurTech Onay Kodu";

                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("mehmetsrgnn@gmail.com", "write your code here");
                    client.Send(mimeMessage);
                    client.Disconnect(true);

                    TempData["Mail"] = appUserRegisterDto.Email;

                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();  
        }
    }
}
