using Autofac;
using System.ComponentModel.DataAnnotations;
using TicketPurchase.Base.BusinessObjects;
using TicketPurchase.Base.Services;

namespace TicketPurchase.Web.Areas.Customer.Models
{
    public class TicketPlaceOrderModel
    {
        private ITicketPurchaseService _ticketPurchaseService;
        private ILifetimeScope _scope;

        [StringLength(100, ErrorMessage = "Customer Name shouldn't be more than 100 characters")]
        public string? CustomerName { get; set; }

        [StringLength(400)]
        public string? CustomerAddress { get; set; }

        [StringLength(3, ErrorMessage = "Enter the Seat Number in correct format")]
        public string? SeatNumber { get; set; }

        [DataType(DataType.Currency), Range(500, 10000, ErrorMessage = "Price should be between Tk 500 to Tk 80,000")]
        public int TicketPrice { get; set; }

        [StringLength(10, ErrorMessage = "Bus Number shouldn't be more than 10 characters")]
        public string? BusNumber { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Please enter Date & Time in correct format.")]
        public DateTime OnboardingTime { get; set; } = DateTime.UtcNow;

        public TicketPlaceOrderModel()
        {

        }

        public TicketPlaceOrderModel(ITicketPurchaseService ticketPurchaseService)
        {
            _ticketPurchaseService = ticketPurchaseService;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _ticketPurchaseService = _scope.Resolve<ITicketPurchaseService>();
        }

        internal void TicketPlaceOrder()
        {
            var ticketPurchase = new TicketPurchases()
            {
                CustomerName = CustomerName,
                CustomerAddress = CustomerAddress,
                SeatNumber = SeatNumber,
                TicketPrice = TicketPrice,
                BusNumber = BusNumber,
                OnboardingTime = OnboardingTime,
            };

            _ticketPurchaseService.CreatePurchaseOrder(ticketPurchase);
        }
    }
}
