using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPurchase.Base.Entities;

namespace TicketPurchase.Base.DbContexts
{
    public class PurchasingDbContext : DbContext, IPurchasingDbContext
    {
        private readonly string _connectionString;
        private readonly string _assemblyName;

        public PurchasingDbContext(string connectionString, string assemblyName)
        {
            _assemblyName = assemblyName;
            _connectionString = connectionString;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString, m => m.MigrationsAssembly(_assemblyName));

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<TicketPurchases> TicketPurchases { get; set; }
    }
}
