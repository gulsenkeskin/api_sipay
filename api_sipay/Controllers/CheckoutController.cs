using Microsoft.AspNetCore.Mvc;

namespace ApiSipay.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
