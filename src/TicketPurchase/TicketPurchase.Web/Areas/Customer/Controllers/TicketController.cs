using Autofac;
using Microsoft.AspNetCore.Mvc;
using TicketPurchase.Base.Exceptions;
using TicketPurchase.Web.Areas.Customer.Models;
using TicketPurchase.Web.Models;

namespace TicketPurchase.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class TicketController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<TicketController> _logger;

        public TicketController(ILogger<TicketController> logger, ILifetimeScope scope)
        {
            _scope = scope;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetPurchasedTickets()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<PurchasedTicketsListModel>();
            return Json(model.GetPagedPurchasedTickets(dataTableModel));
        }

        #region Place Order
        public IActionResult PlaceOrder()
        {
            var model = _scope.Resolve<TicketPlaceOrderModel>();
            return View(model);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult PlaceOrder(TicketPlaceOrderModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);
                try
                {
                    model.TicketPlaceOrder();
                    
                    TempData["ResponseMessage"] = "Great Job! Ticket Purchased Successfully.";
                    TempData["ResponseType"] = ResponseTypes.Success;
                    
                    return RedirectToAction("Index");
                }
                catch (DuplicateException ioe)
                {
                    _logger.LogError(ioe, ioe.Message);

                    TempData["ResponseMessage"] = ioe.Message;
                    TempData["ResponseType"] = ResponseTypes.Danger;
                    
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);

                    TempData["ResponseMessage"] = "There was a problem in Purchasing your desired ticket";
                    TempData["ResponseType"] = ResponseTypes.Danger;                    
                }
            }            
            return View(model);
        }
        #endregion

        #region Edit
        public IActionResult Edit(int id)
        {
            var model = _scope.Resolve<TicketEditOrderModel>();
            model.LoadData(id);
            return View(model);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Edit(TicketEditOrderModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);
                try
                {
                    model.TicketEditOrder();

                    TempData["ResponseMessage"] = "Great Job! Update completed Successfully.";
                    TempData["ResponseType"] = ResponseTypes.Success;

                    return RedirectToAction("Index");
                }
                catch (DuplicateException ioe)
                {
                    _logger.LogError(ioe, ioe.Message);

                    TempData["ResponseMessage"] = ioe.Message;
                    TempData["ResponseType"] = ResponseTypes.Danger;

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);

                    TempData["ResponseMessage"] = "There was a problem in Purchasing your desired ticket";
                    TempData["ResponseType"] = ResponseTypes.Danger;
                }
            }
            return View(model);
        }
        #endregion

        #region Delete
        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = _scope.Resolve<PurchasedTicketsListModel>();
                model.DeleteTicketOrder(id);

                TempData["ResponseMessage"] = "Successfully Deleted!";
                TempData["ResponseType"] = ResponseTypes.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                TempData["ResponseMessage"] = "There was a problem in Deleting your ticket order.";
                TempData["ResponseType"] = ResponseTypes.Danger;
            }

            return RedirectToAction("Index");
        }
        #endregion
    }
}
