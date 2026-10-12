using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MaquetteMarket.ClientApp.Messages;

public class ProductCountChangedMessage(int count) : ValueChangedMessage<int>(count);
