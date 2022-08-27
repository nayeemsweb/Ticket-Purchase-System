using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPurchase.Base.DbContexts;
using TicketPurchase.Base.Repositories;
using TicketPurchase.Data;

namespace TicketPurchase.Base.UnitOfWorks
{
    public class TicketPurchaseUnitOfWork : UnitOfWork, ITicketPurchaseUnitOfWork
    {
        public ITicketPurchaseRepository TicketPurchases { get; private set; }
        
        public TicketPurchaseUnitOfWork(IPurchasingDbContext purchasingDbContext, 
            ITicketPurchaseRepository ticketPurchaseRepository) : base((DbContext)purchasingDbContext)
        {
            TicketPurchases = ticketPurchaseRepository;
        }
    }
}
