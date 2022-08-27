using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPurchase.Base.Entities;

namespace TicketPurchase.Base.DbContexts
{
    public interface IPurchasingDbContext
    {
        DbSet<TicketPurchases> TicketPurchases { get; set; }
    }
}
