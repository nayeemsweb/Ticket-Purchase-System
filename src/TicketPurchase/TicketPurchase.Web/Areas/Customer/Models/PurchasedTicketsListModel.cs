using TicketPurchase.Base.Services;
using TicketPurchase.Web.Models;

namespace TicketPurchase.Web.Areas.Customer.Models
{
    public class PurchasedTicketsListModel
    {
        private readonly ITicketPurchaseService _ticketPurchaseService;
        public PurchasedTicketsListModel(ITicketPurchaseService ticketPurchaseService)
        {
            _ticketPurchaseService = ticketPurchaseService;
        }
        public object GetPagedPurchasedTickets(DataTablesAjaxRequestModel model)
        {
            var data = _ticketPurchaseService.GetPurchasedTickets(
               model.PageIndex,
               model.PageSize,
               model.SearchText,
               model.GetSortText(new string[] { "CustomerName", "SeatNumber", "BusNumber", "OnboardingTime" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.CustomerName,
                                record.SeatNumber,
                                record.BusNumber,
                                record.OnboardingTime.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        internal void DeleteTicketOrder(int id)
        {
            _ticketPurchaseService.DeleteTicketOrder(id);
        }
    }
}
