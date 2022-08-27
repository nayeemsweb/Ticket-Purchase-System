using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPurchase.Base.Repositories;
using TicketPurchase.Data;

namespace TicketPurchase.Base.UnitOfWorks
{
    public interface ITicketPurchaseUnitOfWork : IUnitOfWork
    {
        ITicketPurchaseRepository TicketPurchases { get; }
    }
}
