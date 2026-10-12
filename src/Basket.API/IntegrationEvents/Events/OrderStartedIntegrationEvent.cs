namespace MaquetteMarket.Basket.API.IntegrationEvents.EventHandling.Events;

public record OrderStartedIntegrationEvent(string UserId) : IntegrationEvent;

