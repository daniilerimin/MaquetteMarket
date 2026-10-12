using MaquetteMarket.EventBus.Abstractions;
using MaquetteMarket.OrderProcessor;
using MaquetteMarket.OrderProcessor.Events;
using MaquetteMarket.OrderProcessor.Services;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace MaquetteMarket.Application.UnitTests;

[TestClass]
public class OrderProcessorTests
{
    public TestContext TestContext { get; set; } = null!;

    [TestMethod]
    public async Task PublishesGracePeriodConfirmationForEveryEligibleOrder()
    {
        var repository = Substitute.For<IGracePeriodOrdersRepository>();
        repository.GetConfirmedGracePeriodOrdersAsync(
                TimeSpan.FromMinutes(1),
                Arg.Any<CancellationToken>())
            .Returns([12, 34]);
        var eventBus = Substitute.For<IEventBus>();
        var service = new GracePeriodManagerService(
            Options.Create(new BackgroundTaskOptions
            {
                GracePeriodTime = 1,
                CheckUpdateTime = 30
            }),
            eventBus,
            NullLogger<GracePeriodManagerService>.Instance,
            repository);

        await service.CheckConfirmedGracePeriodOrders(TestContext.CancellationToken);

        await eventBus.Received(1).PublishAsync(
            Arg.Is<GracePeriodConfirmedIntegrationEvent>(e => e.OrderId == 12));
        await eventBus.Received(1).PublishAsync(
            Arg.Is<GracePeriodConfirmedIntegrationEvent>(e => e.OrderId == 34));
    }
}
