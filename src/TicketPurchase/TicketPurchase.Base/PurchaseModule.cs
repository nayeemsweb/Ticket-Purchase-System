using Autofac;
using TicketPurchase.Base.DbContexts;
using TicketPurchase.Base.Repositories;
using TicketPurchase.Base.Services;
using TicketPurchase.Base.UnitOfWorks;

public class PurchaseModule : Module
{
    private readonly string _connectionString;
    private readonly string _assemblyName;

    public PurchaseModule(string connectionString, string assemblyName)
    {
        _connectionString = connectionString;
        _assemblyName = assemblyName;
    }
    
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<PurchasingDbContext>().AsSelf()
            .WithParameter("connectionString", _connectionString)
            .WithParameter("assemblyName", _assemblyName)
            .InstancePerLifetimeScope();

        builder.RegisterType<PurchasingDbContext>().As<IPurchasingDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("assemblyName", _assemblyName)
                .InstancePerLifetimeScope();

        builder.RegisterType<TicketPurchaseRepository>().As<ITicketPurchaseRepository>()
            .InstancePerLifetimeScope();

        builder.RegisterType<TicketPurchaseUnitOfWork>().As<ITicketPurchaseUnitOfWork>()
            .InstancePerLifetimeScope();

        builder.RegisterType<TicketPurchaseService>().As<ITicketPurchaseService>()
            .InstancePerLifetimeScope();

        base.Load(builder);
    }
}