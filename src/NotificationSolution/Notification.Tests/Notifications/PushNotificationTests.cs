using Notification.Console.Core.Models;
using Notification.Console.Notifications.Push;

namespace Notification.Tests.Notifications;

public class PushNotificationTests
{
    [Fact]
    public void Send_WithValidMessage_ShouldNotThrowException()
    {
        // Arrange
        var notification = new PushNotification();
        var message = new NotificationMessage
        {
            Recipient = "device-token-123",
            Title = "Test Push",
            Body = "This is a push notification",
            Badge = 5
        };

        // Act & Assert
        var exception = Record.Exception(() => notification.Send(message));
        Assert.Null(exception);
    }

    [Fact]
    public void Send_WithBadge_ShouldProcessCorrectly()
    {
        // Arrange
        var notification = new PushNotification();
        var message = new NotificationMessage
        {
            Recipient = "device-token-abc",
            Title = "New Message",
            Body = "You have a new message",
            Badge = 10
        };

        // Act & Assert - Should not throw
        notification.Send(message);
    }

    [Fact]
    public void Send_WithoutBadge_ShouldProcessCorrectly()
    {
        // Arrange
        var notification = new PushNotification();
        var message = new NotificationMessage
        {
            Recipient = "device-token-xyz",
            Title = "Alert",
            Body = "Important alert",
            Badge = null
        };

        // Act & Assert - Should not throw
        notification.Send(message);
    }

    [Fact]
    public void Send_WithDeviceToken_ShouldProcessCorrectly()
    {
        // Arrange
        var notification = new PushNotification();
        var message = new NotificationMessage
        {
            Recipient = "fcm-token-very-long-string-12345",
            Title = "Reminder",
            Body = "Don't forget!",
            Badge = 1
        };

        // Act & Assert - Should not throw
        notification.Send(message);
    }
}

