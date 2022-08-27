using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPurchase.Base.BusinessObjects;

namespace TicketPurchase.Base.Services
{
    public interface ITicketPurchaseService
    {
        void CreatePurchaseOrder(TicketPurchases ticketPurchases);
        (int total, int totalDisplay, IList<TicketPurchases> records) GetPurchasedTickets(int pageIndex, int pageSize, 
            string searchText, string orderBy);
        void TicketEditOrder(TicketPurchases ticketPurchase);
        TicketPurchases GetPurchasedTicket(int id);
        void DeleteTicketOrder(int id);
    }
}
