namespace BattleSimulation.Tests;

using System.IO;
using System.Threading.Tasks;
using BattleSimulation.Contracts;
using Moq;
using NUnit.Framework;
using Xunit;

public class TransformerBattleTests
{
    [Fact]
    public async Task MainMenu_ValidOption1_CallsAddTransformer()
    {
        // Arrange
        var mockBattle = new Mock<Battle>();
        var stringReader = new StringReader("1\n");
        Console.SetIn(stringReader);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        await mockBattle.Object.MainMenu();

        // Assert
        mockBattle.Verify(b => b.AddTransformer(), Times.Once);
    }

    [Fact]
    public async Task MainMenu_ValidOption2_CallsRemoveTransformer()
    {
        // Arrange
        var mockBattle = new Mock<Battle>();
        var stringReader = new StringReader("2\n");
        Console.SetIn(stringReader);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        await mockBattle.Object.MainMenu();

        // Assert
        mockBattle.Verify(b => b.RemoveTransformer(), Times.Once);
    }

    [Fact]
    public async Task MainMenu_ValidOption3_CallsBattleTransformers()
    {
        // Arrange
        var mockBattle = new Mock<Battle>();
        var stringReader = new StringReader("3\n");
        Console.SetIn(stringReader);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        await mockBattle.Object.MainMenu();

        // Assert
        mockBattle.Verify(b => b.BattleTransformers(), Times.Once);
    }

    [Fact]
    public async Task MainMenu_ValidOption4_CallsGetWinLossRate()
    {
        // Arrange
        var mockBattle = new Mock<Battle>();
        var stringReader = new StringReader("4\n");
        Console.SetIn(stringReader);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        await mockBattle.Object.MainMenu();

        // Assert
        mockBattle.Verify(b => b.GetWinLossRate(), Times.Once);
    }

    [Fact]
    public async Task MainMenu_ValidOption5_CallsDisplayTransformers()
    {
        // Arrange
        var mockBattle = new Mock<Battle>();
        var stringReader = new StringReader("5\n");
        Console.SetIn(stringReader);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        await mockBattle.Object.MainMenu();

        // Assert
        mockBattle.Verify(b => b.DisplayTransformers(), Times.Once);
    }

    [Fact]
    public async Task MainMenu_InvalidOption_ShowsErrorMessage()
    {
        // Arrange
        var mockBattle = new Mock<Battle>();
        var stringReader = new StringReader("invalid\n");
        Console.SetIn(stringReader);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        await mockBattle.Object.MainMenu();

        // Assert
        var output = stringWriter.ToString();
        Assert.Equals("Invalid option. Please try again.", output);
    }

    [Fact]
    public async Task BattleTransformers_ValidTransformers_ReturnsWinner()
    {
        // Arrange
        var mockManager = new Mock<IRepository>();
        mockManager.Setup(m => m.GetAllTransformers()).ReturnsAsync(new[] { "Chun Lee", "Akira" });
        mockManager.Setup(m => m.TransformersBattleResult(It.IsAny<Transformer>(), It.IsAny<Transformer>()))
                   .ReturnsAsync(new BattleResult { Winner = new Transformer { Name = "Chun Lee" }, Loser = new Transformer { Name = "Akira" }, IsTie = false });

        var battle = new Battle(mockManager.Object);

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        await battle.BattleTransformers();

        // Assert
        var output = stringWriter.ToString();
        Assert.IsTrue(output.Contains("Chun Lee wins! Akira loses."));

    }

    [Fact]
    public async Task BattleTransformers_OneTransformerNotFound_ReturnsErrorMessage()
    {
        // Arrange
        var mockManager = new Mock<IRepository>();
        mockManager.Setup(m => m.GetAllTransformers()).ReturnsAsync(new[] { "Chun Lee" });

        var battle = new Battle(mockManager.Object);

        // Act
        await battle.BattleTransformers();

        // Assert
        // finish assert 
    }
}
