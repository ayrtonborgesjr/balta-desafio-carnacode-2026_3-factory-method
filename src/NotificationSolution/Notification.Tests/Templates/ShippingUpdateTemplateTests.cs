using Notification.Console.Templates;

namespace Notification.Tests.Templates;

public class ShippingUpdateTemplateTests
{
    [Fact]
    public void CreateMessage_ShouldReturnCorrectMessage()
    {
        // Arrange
        var trackingCode = "BR123456789";
        var recipient = "device-token-abc";
        var template = new ShippingUpdateTemplate(trackingCode);

        // Act
        var message = template.CreateMessage(recipient);

        // Assert
        Assert.NotNull(message);
        Assert.Equal(recipient, message.Recipient);
        Assert.Equal("Pedido Enviado", message.Title);
        Assert.Contains("pedido foi enviado", message.Body);
        Assert.Contains(trackingCode, message.Body);
        Assert.Equal(1, message.Badge);
    }

    [Fact]
    public void CreateMessage_WithDifferentTrackingCode_ShouldIncludeTrackingCodeInBody()
    {
        // Arrange
        var trackingCode = "XYZ999888777";
        var template = new ShippingUpdateTemplate(trackingCode);

        // Act
        var message = template.CreateMessage("test-device");

        // Assert
        Assert.Contains("XYZ999888777", message.Body);
    }

    [Fact]
    public void CreateMessage_WithDifferentRecipient_ShouldSetCorrectRecipient()
    {
        // Arrange
        var template = new ShippingUpdateTemplate("BR123456789");
        var recipient = "another-device-token";

        // Act
        var message = template.CreateMessage(recipient);

        // Assert
        Assert.Equal(recipient, message.Recipient);
    }

    [Fact]
    public void CreateMessage_ShouldSetBadgeToOne()
    {
        // Arrange
        var template = new ShippingUpdateTemplate("BR123456789");

        // Act
        var message = template.CreateMessage("device-token");

        // Assert
        Assert.Equal(1, message.Badge);
    }
}

