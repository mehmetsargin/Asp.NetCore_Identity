using MercurTech.BusinessLayer.Abstract;
using MercurTech.DataAccessLayer.Concrete;
using MercurTech.DtoLayer.Dtos.CustomerAccountProcessDtos;
using MercurTech.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MercurTech.PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
        }

        [HttpGet]
        public IActionResult Index(string mycurrency)
        {
            ViewBag.currency = mycurrency;
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Index(SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcessDto)
        {
            var context = new Context();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
			var receiverAccountNumberID = context.CustomerAccounts.Where(x => x.CustomerAccountNumber ==
			    sendMoneyForCustomerAccountProcessDto.ReceiverAccountNumber).Select(y => y.CustomerAccountID).FirstOrDefault();
            
            var sendeAccountNumberID= context.CustomerAccounts.Where(x => x.AppUserID==user.Id).Where(y=> y.CustomerAccountCurrency=="Türk Lirası").Select(z => z.CustomerAccountID).FirstOrDefault();

            var values = new CustomerAccountProcess();
            values.ProcessDate= Convert.ToDateTime(DateTime.Now.ToShortDateString());
            values.SenderID = sendeAccountNumberID;
            values.ReceiverID = receiverAccountNumberID;
            values.ProcessType = "Havale";
            values.Amount= sendMoneyForCustomerAccountProcessDto.Amount;
            values.Description = sendMoneyForCustomerAccountProcessDto.Description;

            _customerAccountProcessService.TInsert(values);


            return RedirectToAction("Index", "Deneme"); 
        }
    }
}
