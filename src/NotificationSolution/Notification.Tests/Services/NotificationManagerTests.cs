using Notification.Console.Core.Enums;
using Notification.Console.Core.Interfaces;
using Notification.Console.Core.Models;
using Notification.Console.Services;

namespace Notification.Tests.Services;

public class NotificationManagerTests
{
    [Fact]
    public void Send_ShouldCreateNotificationAndSendMessage()
    {
        // Arrange
        var mockFactory = new MockNotificationFactory();
        var mockTemplate = new MockNotificationTemplate();
        var manager = new NotificationManager(mockFactory);

        // Act
        manager.Send(mockTemplate, NotificationChannel.Email, "test@example.com");

        // Assert
        Assert.True(mockFactory.CreateWasCalled);
        Assert.Equal(NotificationChannel.Email, mockFactory.LastChannel);
        Assert.True(mockTemplate.CreateMessageWasCalled);
        Assert.Equal("test@example.com", mockTemplate.LastRecipient);
        Assert.True(mockFactory.LastNotification.SendWasCalled);
    }

    [Fact]
    public void Send_WithDifferentChannels_ShouldCallFactoryWithCorrectChannel()
    {
        // Arrange
        var mockFactory = new MockNotificationFactory();
        var mockTemplate = new MockNotificationTemplate();
        var manager = new NotificationManager(mockFactory);

        // Act & Assert - WhatsApp
        manager.Send(mockTemplate, NotificationChannel.WhatsApp, "+5511999999999");
        Assert.Equal(NotificationChannel.WhatsApp, mockFactory.LastChannel);

        // Act & Assert - Push
        manager.Send(mockTemplate, NotificationChannel.Push, "device-token");
        Assert.Equal(NotificationChannel.Push, mockFactory.LastChannel);

        // Act & Assert - Sms
        manager.Send(mockTemplate, NotificationChannel.Sms, "+5511888888888");
        Assert.Equal(NotificationChannel.Sms, mockFactory.LastChannel);
    }

    // Mock classes for testing
    private class MockNotificationFactory : INotificationFactory
    {
        public bool CreateWasCalled { get; private set; }
        public NotificationChannel LastChannel { get; private set; }
        public MockNotification LastNotification { get; private set; }

        public INotification Create(NotificationChannel channel)
        {
            CreateWasCalled = true;
            LastChannel = channel;
            LastNotification = new MockNotification();
            return LastNotification;
        }
    }

    private class MockNotificationTemplate : INotificationTemplate
    {
        public bool CreateMessageWasCalled { get; private set; }
        public string LastRecipient { get; private set; } = string.Empty;

        public NotificationMessage CreateMessage(string recipient)
        {
            CreateMessageWasCalled = true;
            LastRecipient = recipient;
            return new NotificationMessage
            {
                Recipient = recipient,
                Title = "Test Title",
                Body = "Test Body"
            };
        }
    }

    private class MockNotification : INotification
    {
        public bool SendWasCalled { get; private set; }
        public NotificationMessage LastMessage { get; private set; }

        public void Send(NotificationMessage message)
        {
            SendWasCalled = true;
            LastMessage = message;
        }
    }
}

