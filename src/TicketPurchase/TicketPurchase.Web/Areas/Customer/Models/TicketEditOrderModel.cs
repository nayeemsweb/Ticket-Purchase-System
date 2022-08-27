using Autofac;
using System.ComponentModel.DataAnnotations;
using TicketPurchase.Base.BusinessObjects;
using TicketPurchase.Base.Services;

namespace TicketPurchase.Web.Areas.Customer.Models
{
    public class TicketEditOrderModel
    {
        private ITicketPurchaseService _ticketPurchaseService;
        private ILifetimeScope _scope;

        public int Id { get; set; }

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

        [DataType(DataType.DateTime)]
        public DateTime OnboardingTime { get; set; }

        public TicketEditOrderModel()
        {

        }

        public TicketEditOrderModel(ITicketPurchaseService ticketPurchaseService)
        {
            _ticketPurchaseService = ticketPurchaseService;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _ticketPurchaseService = _scope.Resolve<ITicketPurchaseService>();
        }

        public void TicketEditOrder()
        {
            var ticketPurchase = new TicketPurchases();
            ticketPurchase.Id = Id;
            ticketPurchase.CustomerName = CustomerName;
            ticketPurchase.CustomerAddress = CustomerAddress;
            ticketPurchase.SeatNumber = SeatNumber;            
            ticketPurchase.TicketPrice = TicketPrice;
            ticketPurchase.BusNumber = BusNumber;
            ticketPurchase.OnboardingTime = OnboardingTime;
            
            _ticketPurchaseService.TicketEditOrder(ticketPurchase);
        }

        internal void LoadData(int id)
        {
            TicketPurchases ticketPurchased =  _ticketPurchaseService.GetPurchasedTicket(id);
            Id = ticketPurchased.Id;
            CustomerName = ticketPurchased.CustomerName;
            CustomerAddress = ticketPurchased.CustomerAddress;
            SeatNumber = ticketPurchased.SeatNumber;
            TicketPrice = ticketPurchased.TicketPrice;
            BusNumber = ticketPurchased.BusNumber;
            OnboardingTime = ticketPurchased.OnboardingTime;
        }
    }
}
