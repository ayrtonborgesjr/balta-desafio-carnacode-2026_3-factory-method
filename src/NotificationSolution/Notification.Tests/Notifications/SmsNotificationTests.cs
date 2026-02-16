using Notification.Console.Core.Models;
using Notification.Console.Notifications.Sms;

namespace Notification.Tests.Notifications;

public class SmsNotificationTests
{
    [Fact]
    public void Send_WithValidMessage_ShouldNotThrowException()
    {
        // Arrange
        var notification = new SmsNotification();
        var message = new NotificationMessage
        {
            Recipient = "+5511999999999",
            Title = "Test SMS",
            Body = "This is a test SMS message"
        };

        // Act & Assert
        var exception = Record.Exception(() => notification.Send(message));
        Assert.Null(exception);
    }

    [Fact]
    public void Send_WithPhoneNumber_ShouldProcessCorrectly()
    {
        // Arrange
        var notification = new SmsNotification();
        var message = new NotificationMessage
        {
            Recipient = "+1234567890",
            Title = "Notification",
            Body = "Your code is 123456"
        };

        // Act & Assert - Should not throw
        notification.Send(message);
    }

    [Fact]
    public void Send_WithLongMessage_ShouldProcessCorrectly()
    {
        // Arrange
        var notification = new SmsNotification();
        var message = new NotificationMessage
        {
            Recipient = "+5511888888888",
            Title = "Long SMS",
            Body = new string('A', 160) // SMS typical length
        };

        // Act & Assert - Should not throw
        notification.Send(message);
    }
}

