using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPurchase.Base.BusinessObjects;
using TicketPurchase.Base.Exceptions;
using TicketPurchase.Base.UnitOfWorks;
using TicketPurchaseEntity = TicketPurchase.Base.Entities.TicketPurchases;

namespace TicketPurchase.Base.Services
{
    public class TicketPurchaseService : ITicketPurchaseService
    {
        private readonly ITicketPurchaseUnitOfWork _ticketPurchaseUnitOfWork;
        
        public TicketPurchaseService(ITicketPurchaseUnitOfWork ticketPurchaseUnitOfWork)
        {
            _ticketPurchaseUnitOfWork = ticketPurchaseUnitOfWork;
        }
        
        public void CreatePurchaseOrder(TicketPurchases ticketPurchases)
        {
            var ticketPurchaseCount = _ticketPurchaseUnitOfWork.TicketPurchases
                .GetCount(x => x.SeatNumber == ticketPurchases.SeatNumber);

            if (ticketPurchaseCount == 0)
            {
                var entity = new TicketPurchaseEntity
                {
                    CustomerName = ticketPurchases.CustomerName,
                    CustomerAddress = ticketPurchases.CustomerAddress,
                    SeatNumber = ticketPurchases.SeatNumber,
                    TicketPrice = ticketPurchases.TicketPrice,
                    BusNumber = ticketPurchases.BusNumber,
                    OnboardingTime = ticketPurchases.OnboardingTime,
                };

                _ticketPurchaseUnitOfWork.TicketPurchases.Add(entity);
                _ticketPurchaseUnitOfWork.Save();
            }
            else 
                throw new DuplicateException("Same seat already purcased!");
            
        }

        public void DeleteTicketOrder(int id)
        {
            _ticketPurchaseUnitOfWork.TicketPurchases.Remove(id);
            _ticketPurchaseUnitOfWork.Save();
        }

        public TicketPurchases GetPurchasedTicket(int id)
        {
            var ticketPurchaseEntity = _ticketPurchaseUnitOfWork.TicketPurchases.GetById(id);

            var ticketPurchase = new TicketPurchases();
            ticketPurchase.Id = ticketPurchaseEntity.Id;
            ticketPurchase.CustomerName = ticketPurchaseEntity.CustomerName;
            ticketPurchase.CustomerAddress = ticketPurchaseEntity.CustomerAddress;
            ticketPurchase.SeatNumber = ticketPurchaseEntity.SeatNumber;
            ticketPurchase.TicketPrice = ticketPurchaseEntity.TicketPrice;
            ticketPurchase.BusNumber = ticketPurchaseEntity.BusNumber;
            ticketPurchase.OnboardingTime = ticketPurchaseEntity.OnboardingTime;
            
            return ticketPurchase;
        }

        public (int total, int totalDisplay, IList<TicketPurchases> records) GetPurchasedTickets(int pageIndex, int pageSize, 
            string searchText, string orderBy)
        {
            var result = _ticketPurchaseUnitOfWork.TicketPurchases.GetDynamic(x => x.CustomerName.Contains(searchText),
                orderBy, string.Empty, pageIndex, pageSize, true);

            List<TicketPurchases> tickets = new List<TicketPurchases>();
            foreach(TicketPurchaseEntity purchase in result.data)
            {
                tickets.Add(new TicketPurchases
                {
                    Id = purchase.Id,
                    CustomerName = purchase.CustomerName,
                    CustomerAddress = purchase.CustomerAddress,
                    SeatNumber = purchase.SeatNumber,
                    TicketPrice = purchase.TicketPrice,
                    BusNumber = purchase.BusNumber,
                    OnboardingTime = purchase.OnboardingTime,
                });
            }
            return (result.total, result.totalDisplay, tickets);
        }

        public void TicketEditOrder(TicketPurchases ticketPurchase)
        {
            var ticketPurchaseCount = _ticketPurchaseUnitOfWork.TicketPurchases
                .GetCount(x => x.SeatNumber == ticketPurchase.SeatNumber
                && x.Id != ticketPurchase.Id);

            if (ticketPurchaseCount == 0)
            {
                var ticketPurchaseEntity = _ticketPurchaseUnitOfWork.TicketPurchases.GetById(ticketPurchase.Id);
                ticketPurchaseEntity.CustomerName = ticketPurchase.CustomerName;
                ticketPurchaseEntity.CustomerAddress = ticketPurchase.CustomerAddress;
                ticketPurchaseEntity.SeatNumber = ticketPurchase.SeatNumber;
                ticketPurchaseEntity.TicketPrice = ticketPurchase.TicketPrice;
                ticketPurchaseEntity.BusNumber = ticketPurchase.BusNumber;
                ticketPurchaseEntity.OnboardingTime = ticketPurchase.OnboardingTime;

                _ticketPurchaseUnitOfWork.Save();
            }
            else
            {
                throw new DuplicateException("This seat is already taken. Try again!");
            }                
        }
    }
}
