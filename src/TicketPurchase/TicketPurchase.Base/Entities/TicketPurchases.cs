using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPurchase.Data;

namespace TicketPurchase.Base.Entities
{
    public class TicketPurchases : IEntity<int>
    {
        public int Id { get; set; }

        public string? CustomerName { get; set; }

        public string? CustomerAddress { get; set; }

        public string? SeatNumber { get; set; }

        public int TicketPrice { get; set; }

        public string? BusNumber { get; set; }

        public DateTime OnboardingTime { get; set; }
    }
}
