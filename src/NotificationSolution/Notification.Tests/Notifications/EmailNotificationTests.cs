using Notification.Console.Core.Models;
using Notification.Console.Notifications.Email;

namespace Notification.Tests.Notifications;

public class EmailNotificationTests
{
    [Fact]
    public void Send_WithValidMessage_ShouldNotThrowException()
    {
        // Arrange
        var notification = new EmailNotification();
        var message = new NotificationMessage
        {
            Recipient = "test@email.com",
            Title = "Test Title",
            Body = "Test Body",
            IsHtml = true
        };

        // Act & Assert
        var exception = Record.Exception(() => notification.Send(message));
        Assert.Null(exception);
    }

    [Fact]
    public void Send_WithHtmlMessage_ShouldProcessCorrectly()
    {
        // Arrange
        var notification = new EmailNotification();
        var message = new NotificationMessage
        {
            Recipient = "user@domain.com",
            Title = "HTML Email",
            Body = "<h1>Hello World</h1>",
            IsHtml = true
        };

        // Act & Assert - Should not throw
        notification.Send(message);
    }

    [Fact]
    public void Send_WithPlainTextMessage_ShouldProcessCorrectly()
    {
        // Arrange
        var notification = new EmailNotification();
        var message = new NotificationMessage
        {
            Recipient = "user@domain.com",
            Title = "Plain Text Email",
            Body = "Simple text message",
            IsHtml = false
        };

        // Act & Assert - Should not throw
        notification.Send(message);
    }
}

