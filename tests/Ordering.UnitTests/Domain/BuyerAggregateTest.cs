namespace MaquetteMarket.Ordering.UnitTests.Domain;

[TestClass]
public class BuyerAggregateTest
{
    public BuyerAggregateTest()
    { }

    [TestMethod]
    public void Create_buyer_item_success()
    {
        var identity = new Guid().ToString();
        var name = "fakeUser";

        var fakeBuyerItem = new Buyer(identity, name);

        Assert.IsNotNull(fakeBuyerItem);
    }

    [TestMethod]
    public void Create_buyer_item_fail()
    {
        var identity = string.Empty;
        var name = "fakeUser";

        Assert.ThrowsExactly<ArgumentNullException>(() => new Buyer(identity, name));
    }

    [TestMethod]
    public void add_payment_success()
    {
        var cardTypeId = 1;
        var alias = "fakeAlias";
        var cardNumber = "124";
        var securityNumber = "1234";
        var cardHolderName = "FakeHolderNAme";
        var expiration = DateTime.UtcNow.AddYears(1);
        var orderId = 1;
        var name = "fakeUser";
        var identity = new Guid().ToString();
        var fakeBuyerItem = new Buyer(identity, name);

        var result = fakeBuyerItem.VerifyOrAddPaymentMethod(cardTypeId, alias, cardNumber, securityNumber, cardHolderName, expiration, orderId);

        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void create_payment_method_success()
    {
        var cardTypeId = 1;
        var alias = "fakeAlias";
        var cardNumber = "124";
        var securityNumber = "1234";
        var cardHolderName = "FakeHolderNAme";
        var expiration = DateTime.UtcNow.AddYears(1);
        var fakePaymentMethod = new PaymentMethod(cardTypeId, alias, cardNumber, securityNumber, cardHolderName, expiration);

        var result = new PaymentMethod(cardTypeId, alias, cardNumber, securityNumber, cardHolderName, expiration);

        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void create_payment_method_expiration_fail()
    {
        var cardTypeId = 1;
        var alias = "fakeAlias";
        var cardNumber = "124";
        var securityNumber = "1234";
        var cardHolderName = "FakeHolderNAme";
        var expiration = DateTime.UtcNow.AddYears(-1);

        Assert.ThrowsExactly<OrderingDomainException>(() => new PaymentMethod(cardTypeId, alias, cardNumber, securityNumber, cardHolderName, expiration));
    }

    [TestMethod]
    public void payment_method_isEqualTo()
    {
        var cardTypeId = 1;
        var alias = "fakeAlias";
        var cardNumber = "124";
        var securityNumber = "1234";
        var cardHolderName = "FakeHolderNAme";
        var expiration = DateTime.UtcNow.AddYears(1);

        var fakePaymentMethod = new PaymentMethod(cardTypeId, alias, cardNumber, securityNumber, cardHolderName, expiration);
        var result = fakePaymentMethod.IsEqualTo(cardTypeId, cardNumber, expiration);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Add_new_PaymentMethod_raises_new_event()
    {
        var alias = "fakeAlias";
        var orderId = 1;
        var cardTypeId = 5;
        var cardNumber = "12";
        var cardSecurityNumber = "123";
        var cardHolderName = "FakeName";
        var cardExpiration = DateTime.UtcNow.AddYears(1);
        var expectedResult = 1;
        var name = "fakeUser";

        var fakeBuyer = new Buyer(Guid.NewGuid().ToString(), name);
        fakeBuyer.VerifyOrAddPaymentMethod(cardTypeId, alias, cardNumber, cardSecurityNumber, cardHolderName, cardExpiration, orderId);

        Assert.HasCount(expectedResult, fakeBuyer.DomainEvents);
    }
}

