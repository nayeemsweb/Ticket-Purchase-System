using Autofac;
using TicketPurchase.Web.Areas.Customer.Models;
using TicketPurchase.Web.Models;

public class WebModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        //builder.RegisterType<TestClass>().As<ITestClass1>()
        //    .InstancePerLifetimeScope();

        builder.RegisterType<TicketPurchaseModel>().AsSelf();
        builder.RegisterType<TicketPlaceOrderModel>().AsSelf();
        builder.RegisterType<PurchasedTicketsListModel>().AsSelf();
        builder.RegisterType<TicketEditOrderModel>().AsSelf();

        base.Load(builder);
    }
}