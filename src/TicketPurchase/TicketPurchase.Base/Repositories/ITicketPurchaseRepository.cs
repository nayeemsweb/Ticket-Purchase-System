using TicketPurchase.Base.Entities;
using TicketPurchase.Data;

namespace TicketPurchase.Base.Repositories
{
    public interface ITicketPurchaseRepository : IRepository<TicketPurchases, int>
    {
    }
}