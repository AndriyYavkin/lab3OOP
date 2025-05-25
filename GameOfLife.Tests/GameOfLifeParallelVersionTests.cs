using NUnit.Framework;

namespace GameOfLife.Tests;

[TestFixture]
public class GameOfLifeParallelVersionTests
{
    private const int GridRows = 5;
    private const int GridColumns = 5;

    [Test]
    public void ConstructorGameOfLifeParallelVersion_WithInvalidRows_ThrowsArgumentOutOfRangeException()
    {
        _ = Assert.Throws<ArgumentOutOfRangeException>(() => new GameOfLifeParallelVersion(0, -4));
    }

    [Test]
    public void ConstructorGameOfLifeParallelVersion_WithInvalidColumns_ThrowsArgumentOutOfRangeException()
    {
        _ = Assert.Throws<ArgumentOutOfRangeException>(() => new GameOfLifeParallelVersion(-3, 0));
    }

    [Test]
    public void Restart_ResetsCurrentGenerationToInitialGrid()
    {
        var game = new GameOfLifeParallelVersion(GridRows, GridColumns);
        var initialGrid = game.CurrentGeneration;
        game.NextGeneration();
        game.NextGeneration();
        game.Restart();
        var currentGenerationAfterRestart = game.CurrentGeneration;
        Assert.That(initialGrid, Is.EqualTo(currentGenerationAfterRestart));
    }

    [TestCaseSource(typeof(TestCases), nameof(TestCases.TestsForGenerations))]
    public bool[,] NextGeneration_AdvancesToNextGenerationBasedOnRules_ParallelVersion(int generations, bool[,] grid)
    {
        var game = new GameOfLifeParallelVersion(grid);
        for (int i = 1; i <= generations; i++)
        {
            game.NextGeneration();
        }

        return game.CurrentGeneration;
    }
}
