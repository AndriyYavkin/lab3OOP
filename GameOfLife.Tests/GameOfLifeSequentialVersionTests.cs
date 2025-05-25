using NUnit.Framework;

namespace GameOfLife.Tests;

[TestFixture]
public class GameOfLifeSequentialVersionTests
{
    private const int GridRows = 5;
    private const int GridColumns = 5;

    [Test]
    public void Constructor_WithInvalidRows_ThrowsArgumentOutOfRangeException()
    {
        _ = Assert.Throws<ArgumentOutOfRangeException>(() => new GameOfLifeSequentialVersion(0, -4));
    }

    [Test]
    public void Constructor_WithInvalidColumns_ThrowsArgumentOutOfRangeException()
    {
        _ = Assert.Throws<ArgumentOutOfRangeException>(() => new GameOfLifeSequentialVersion(-3, 0));
    }

    [Test]
    public void Restart_ResetsCurrentGenerationToInitialGrid()
    {
        var game = new GameOfLifeSequentialVersion(GridRows, GridColumns);
        var initialGrid = game.CurrentGeneration;
        game.NextGeneration();
        game.NextGeneration();
        game.Restart();
        var currentGenerationAfterRestart = game.CurrentGeneration;
        Assert.That(initialGrid, Is.EqualTo(currentGenerationAfterRestart));
    }

    [TestCaseSource(typeof(TestCases), nameof(TestCases.TestsForGenerations))]
    public bool[,] NextGeneration_AdvancesToNextGenerationBasedOnRules_SequentialVersion(int generations, bool[,] grid)
    {
        var game = new GameOfLifeSequentialVersion(grid);
        for (int i = 1; i <= generations; i++)
        {
            game.NextGeneration();
        }

        return game.CurrentGeneration;
    }
}
