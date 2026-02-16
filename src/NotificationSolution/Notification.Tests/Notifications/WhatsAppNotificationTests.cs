using Notification.Console.Core.Models;
using Notification.Console.Notifications.WhatsApp;

namespace Notification.Tests.Notifications;

public class WhatsAppNotificationTests
{
    [Fact]
    public void Send_WithValidMessage_ShouldNotThrowException()
    {
        // Arrange
        var notification = new WhatsAppNotification();
        var message = new NotificationMessage
        {
            Recipient = "+5511999999999",
            Title = "Test WhatsApp",
            Body = "This is a WhatsApp message"
        };

        // Act & Assert
        var exception = Record.Exception(() => notification.Send(message));
        Assert.Null(exception);
    }

    [Fact]
    public void Send_WithPhoneNumber_ShouldProcessCorrectly()
    {
        // Arrange
        var notification = new WhatsAppNotification();
        var message = new NotificationMessage
        {
            Recipient = "+5521987654321",
            Title = "Payment Confirmation",
            Body = "Your payment was received successfully!"
        };

        // Act & Assert - Should not throw
        notification.Send(message);
    }

    [Fact]
    public void Send_WithLongMessage_ShouldProcessCorrectly()
    {
        // Arrange
        var notification = new WhatsAppNotification();
        var message = new NotificationMessage
        {
            Recipient = "+5511888888888",
            Title = "Long Message",
            Body = new string('B', 500) // WhatsApp can handle long messages
        };

        // Act & Assert - Should not throw
        notification.Send(message);
    }

    [Fact]
    public void Send_WithHtmlContent_ShouldProcessCorrectly()
    {
        // Arrange
        var notification = new WhatsAppNotification();
        var message = new NotificationMessage
        {
            Recipient = "+5511777777777",
            Title = "HTML Content",
            Body = "<b>Bold text</b> in WhatsApp",
            IsHtml = true
        };

        // Act & Assert - Should not throw
        notification.Send(message);
    }
}

