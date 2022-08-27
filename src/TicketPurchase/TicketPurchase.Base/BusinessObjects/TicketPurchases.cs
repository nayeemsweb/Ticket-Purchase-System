using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketPurchase.Base.BusinessObjects
{
    public class TicketPurchases
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
