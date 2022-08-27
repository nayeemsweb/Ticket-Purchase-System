using Microsoft.AspNetCore.Mvc;

namespace TicketPurchase.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
