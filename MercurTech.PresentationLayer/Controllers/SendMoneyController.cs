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
        private readonly ICostumerAccountProcessService _customerAccountProcessService;

        public SendMoneyController(UserManager<AppUser> userManager, ICostumerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Index(SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcessDto)
        {
            var context = new Context();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
			var receiverAccountNumberID = context.CustomerAccounts.Where(x => x.CustomerAccountNumber ==
			    sendMoneyForCustomerAccountProcessDto.ReceiverAccountNumber).Select(y => y.CustomerAccountID).FirstOrDefault();

			sendMoneyForCustomerAccountProcessDto.SenderID = user.Id;
            sendMoneyForCustomerAccountProcessDto.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            sendMoneyForCustomerAccountProcessDto.ProcessType = "Havale";
            sendMoneyForCustomerAccountProcessDto.ReceiverID= receiverAccountNumberID;


            return RedirectToAction("Index", "Deneme"); 
        }
    }
}
