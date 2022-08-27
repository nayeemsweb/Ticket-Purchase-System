using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPurchase.Base.DbContexts;
using TicketPurchase.Base.Entities;
using TicketPurchase.Data;

namespace TicketPurchase.Base.Repositories
{
    public class TicketPurchaseRepository : Repository<TicketPurchases, int>, ITicketPurchaseRepository
    {
        public TicketPurchaseRepository(IPurchasingDbContext purchasingDbContext) : base((DbContext)purchasingDbContext)
        {
        }
    }
}
