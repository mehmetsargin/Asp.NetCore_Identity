using Microsoft.AspNetCore.Mvc;

namespace MercurTech.PresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutHeaderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
