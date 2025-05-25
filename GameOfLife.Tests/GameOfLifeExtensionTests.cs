using NUnit.Framework;

namespace GameOfLife.Tests;

[TestFixture]
public class GameOfLifeExtensionTests
{
    private const string FilePath = "Generations.txt";

    private readonly bool[,] grid =
    {
        { false, false, false, false, false, false, false, false, false, false, false },
        { false, false, false, false, false, false, false, false, false, false, false },
        { false, false, false, false, false, false, false, false, false, false, false },
        { false, false, false, false, false, false, false, false, false, false, false },
        { false, false, false, false, false, false, false, false, false, false, false },
        { false, false, false, false, true, true, true, false, false, false, false },
        { false, false, false, false, true, false, true, false, false, false, false },
        { false, false, false, false, true, true, true, false, false, false, false },
        { false, false, false, false, true, true, true, false, false, false, false },
        { false, false, false, false, true, true, true, false, false, false, false },
        { false, false, false, false, true, true, true, false, false, false, false },
        { false, false, false, false, true, false, true, false, false, false, false },
        { false, false, false, false, true, true, true, false, false, false, false },
        { false, false, false, false, false, false, false, false, false, false, false },
        { false, false, false, false, false, false, false, false, false, false, false },
        { false, false, false, false, false, false, false, false, false, false, false },
        { false, false, false, false, false, false, false, false, false, false, false },
        { false, false, false, false, false, false, false, false, false, false, false },
    };

    [Test]
    public void Simulate_Sequential_InvalidGenerations_ArgumentOutOfRangeException()
    {
        var game = new GameOfLifeSequentialVersion(5, 5);
        _ = Assert.Throws<ArgumentOutOfRangeException>(() => game.Simulate(-1, new StringWriter(), 'O', ' '));
    }

    [Test]
    public void SimulateAsync_Parallel_InvalidGenerations_ArgumentOutOfRangeException()
    {
        var game = new GameOfLifeParallelVersion(5, 5);
        _ = Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => game.SimulateAsync(-1, new StringWriter(), 'O', ' '));
    }

    [Test]
    public void Simulate_Sequential_NullWriter_ArgumentNullException()
    {
        var game = new GameOfLifeSequentialVersion(5, 5);
        _ = Assert.Throws<ArgumentNullException>(() => game.Simulate(3, null, 'O', ' '));
    }

    [Test]
    public void Simulate_Parallel_NullWriter_ArgumentNullException()
    {
        var game = new GameOfLifeParallelVersion(5, 5);
        _ = Assert.ThrowsAsync<ArgumentNullException>(() => game.SimulateAsync(-1, null, 'O', ' '));
    }

    [Test]
    public void Simulate_Sequential_NullGame_ArgumentNullException()
    {
        GameOfLifeSequentialVersion? game = null;
        _ = Assert.Throws<ArgumentNullException>(() => game.Simulate(3, new StringWriter(), '0', ' '));
    }

    [Test]
    public void SimulateAsync_Parallel_NullGame_ArgumentNullException()
    {
        GameOfLifeParallelVersion? game = null;
        _ = Assert.ThrowsAsync<ArgumentNullException>(() => game.SimulateAsync(3, new StringWriter(), '0', ' '));
    }
}
