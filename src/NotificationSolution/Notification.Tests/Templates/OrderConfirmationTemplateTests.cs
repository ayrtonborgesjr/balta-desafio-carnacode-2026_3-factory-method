using Notification.Console.Templates;

namespace Notification.Tests.Templates;

public class OrderConfirmationTemplateTests
{
    [Fact]
    public void CreateMessage_ShouldReturnCorrectMessage()
    {
        // Arrange
        var orderNumber = "12345";
        var recipient = "customer@email.com";
        var template = new OrderConfirmationTemplate(orderNumber);

        // Act
        var message = template.CreateMessage(recipient);

        // Assert
        Assert.NotNull(message);
        Assert.Equal(recipient, message.Recipient);
        Assert.Equal("Pedido Confirmado", message.Title);
        Assert.Contains(orderNumber, message.Body);
        Assert.Contains("confirmado com sucesso", message.Body);
        Assert.True(message.IsHtml);
        Assert.Equal(1, message.Badge);
    }

    [Fact]
    public void CreateMessage_WithDifferentOrderNumber_ShouldIncludeOrderNumberInBody()
    {
        // Arrange
        var orderNumber = "ABC-9999";
        var template = new OrderConfirmationTemplate(orderNumber);

        // Act
        var message = template.CreateMessage("test@test.com");

        // Assert
        Assert.Contains("ABC-9999", message.Body);
    }

    [Fact]
    public void CreateMessage_WithDifferentRecipient_ShouldSetCorrectRecipient()
    {
        // Arrange
        var template = new OrderConfirmationTemplate("12345");
        var recipient = "another@email.com";

        // Act
        var message = template.CreateMessage(recipient);

        // Assert
        Assert.Equal(recipient, message.Recipient);
    }
}

