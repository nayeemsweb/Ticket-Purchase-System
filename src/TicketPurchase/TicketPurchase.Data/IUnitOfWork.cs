namespace TicketPurchase.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}