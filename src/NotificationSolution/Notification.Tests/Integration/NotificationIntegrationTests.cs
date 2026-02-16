using Notification.Console.Core.Enums;
using Notification.Console.Factories;
using Notification.Console.Services;
using Notification.Console.Templates;

namespace Notification.Tests.Integration;

public class NotificationIntegrationTests
{
    [Fact]
    public void CompleteFlow_OrderConfirmation_WithEmail_ShouldExecuteSuccessfully()
    {
        // Arrange
        var factory = new NotificationFactory();
        var manager = new NotificationManager(factory);
        var template = new OrderConfirmationTemplate("ORDER-12345");

        // Act & Assert - Should not throw
        var exception = Record.Exception(() => 
            manager.Send(template, NotificationChannel.Email, "customer@email.com"));
        
        Assert.Null(exception);
    }

    [Fact]
    public void CompleteFlow_ShippingUpdate_WithPush_ShouldExecuteSuccessfully()
    {
        // Arrange
        var factory = new NotificationFactory();
        var manager = new NotificationManager(factory);
        var template = new ShippingUpdateTemplate("BR123456789");

        // Act & Assert - Should not throw
        var exception = Record.Exception(() => 
            manager.Send(template, NotificationChannel.Push, "device-token-abc"));
        
        Assert.Null(exception);
    }

    [Fact]
    public void CompleteFlow_PaymentReminder_WithWhatsApp_ShouldExecuteSuccessfully()
    {
        // Arrange
        var factory = new NotificationFactory();
        var manager = new NotificationManager(factory);
        var template = new PaymentReminderTemplate(150.00m);

        // Act & Assert - Should not throw
        var exception = Record.Exception(() => 
            manager.Send(template, NotificationChannel.WhatsApp, "+551199999999"));
        
        Assert.Null(exception);
    }

    [Fact]
    public void CompleteFlow_PaymentReminder_WithSms_ShouldExecuteSuccessfully()
    {
        // Arrange
        var factory = new NotificationFactory();
        var manager = new NotificationManager(factory);
        var template = new PaymentReminderTemplate(99.90m);

        // Act & Assert - Should not throw
        var exception = Record.Exception(() => 
            manager.Send(template, NotificationChannel.Sms, "+5511888888888"));
        
        Assert.Null(exception);
    }

    [Fact]
    public void CompleteFlow_MultipleNotifications_ShouldExecuteSuccessfully()
    {
        // Arrange
        var factory = new NotificationFactory();
        var manager = new NotificationManager(factory);

        // Act & Assert - Send multiple notifications
        manager.Send(
            new OrderConfirmationTemplate("ORD-001"),
            NotificationChannel.Email,
            "user1@email.com");

        manager.Send(
            new ShippingUpdateTemplate("TRACK-001"),
            NotificationChannel.Push,
            "device-1");

        manager.Send(
            new PaymentReminderTemplate(200.00m),
            NotificationChannel.WhatsApp,
            "+5511999999999");

        manager.Send(
            new OrderConfirmationTemplate("ORD-002"),
            NotificationChannel.Sms,
            "+5511888888888");

        // If we reach here, all notifications were sent successfully
        Assert.True(true);
    }

    [Fact]
    public void CompleteFlow_AllChannelsWithSameTemplate_ShouldExecuteSuccessfully()
    {
        // Arrange
        var factory = new NotificationFactory();
        var manager = new NotificationManager(factory);
        var template = new OrderConfirmationTemplate("ORD-MULTI");

        // Act & Assert - Send same template to all channels
        manager.Send(template, NotificationChannel.Email, "test@email.com");
        manager.Send(template, NotificationChannel.Sms, "+5511999999999");
        manager.Send(template, NotificationChannel.Push, "device-token");
        manager.Send(template, NotificationChannel.WhatsApp, "+5511888888888");

        // If we reach here, all notifications were sent successfully
        Assert.True(true);
    }
}

