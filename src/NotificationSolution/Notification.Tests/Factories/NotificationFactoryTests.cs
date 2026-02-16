using Notification.Console.Core.Enums;
using Notification.Console.Factories;
using Notification.Console.Notifications.Email;
using Notification.Console.Notifications.Push;
using Notification.Console.Notifications.Sms;
using Notification.Console.Notifications.WhatsApp;

namespace Notification.Tests.Factories;

public class NotificationFactoryTests
{
    private readonly NotificationFactory _factory;

    public NotificationFactoryTests()
    {
        _factory = new NotificationFactory();
    }

    [Fact]
    public void Create_WithEmailChannel_ShouldReturnEmailNotification()
    {
        // Act
        var notification = _factory.Create(NotificationChannel.Email);

        // Assert
        Assert.NotNull(notification);
        Assert.IsType<EmailNotification>(notification);
    }

    [Fact]
    public void Create_WithSmsChannel_ShouldReturnSmsNotification()
    {
        // Act
        var notification = _factory.Create(NotificationChannel.Sms);

        // Assert
        Assert.NotNull(notification);
        Assert.IsType<SmsNotification>(notification);
    }

    [Fact]
    public void Create_WithPushChannel_ShouldReturnPushNotification()
    {
        // Act
        var notification = _factory.Create(NotificationChannel.Push);

        // Assert
        Assert.NotNull(notification);
        Assert.IsType<PushNotification>(notification);
    }

    [Fact]
    public void Create_WithWhatsAppChannel_ShouldReturnWhatsAppNotification()
    {
        // Act
        var notification = _factory.Create(NotificationChannel.WhatsApp);

        // Assert
        Assert.NotNull(notification);
        Assert.IsType<WhatsAppNotification>(notification);
    }

    [Fact]
    public void Create_WithInvalidChannel_ShouldThrowArgumentException()
    {
        // Arrange
        var invalidChannel = (NotificationChannel)999;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _factory.Create(invalidChannel));
    }
}

