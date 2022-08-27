using TicketPurchase.Base.BusinessObjects;
using TicketPurchase.Base.Services;

namespace TicketPurchase.Web.Models
{
    public class TicketPurchaseModel
    {
        private readonly ITicketPurchaseService _ticketPurchaseService;

        public TicketPurchaseModel(ITicketPurchaseService ticketPurchaseService)
        {
            _ticketPurchaseService = ticketPurchaseService;
        }

        internal void CreatePurchaseOrder(string customerName, string customerAddress, 
            string seatNumber, int ticketPrice, string busNumber, DateTime onboardingTime)
        {
            var ticketPurchase = new TicketPurchases
            {
                CustomerName = customerName,
                CustomerAddress = customerAddress,
                SeatNumber = seatNumber,
                TicketPrice = ticketPrice,
                BusNumber = busNumber,
                OnboardingTime = onboardingTime
            };

            _ticketPurchaseService.CreatePurchaseOrder(ticketPurchase);
        }
    }
}
