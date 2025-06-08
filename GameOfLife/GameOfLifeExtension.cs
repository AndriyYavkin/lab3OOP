using System.Diagnostics;

namespace GameOfLife;

/// <summary>
/// Provides extension methods for simulating Conway's Game of Life on different versions.
/// </summary>
public static class GameOfLifeExtension
{
    /// <summary>
    /// Simulates the evolution of Conway's Game of Life for a specified number of generations using the sequential version.
    /// The result is written to the provided <see cref="TextWriter"/> using the specified characters for alive and dead cells.
    /// </summary>
    /// <param name="game">The sequential version of the Game of Life.</param>
    /// <param name="generations">The number of generations to simulate.</param>
    /// <param name="writer">The <see cref="TextWriter"/> used to output the simulation result.</param>
    /// <param name="aliveCell">The character representing an alive cell.</param>
    /// <param name="deadCell">The character representing a dead cell.</param>
    /// <exception cref="ArgumentNullException">Thrown when <param name="game"/> parameters is null.</exception>
    /// <exception cref="ArgumentNullException">Thrown when <param name="writer"/> parameters is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <param name="generations"/> is less than or equal to 0.</exception>
    public static TimeSpan Simulate(this GameOfLifeSequentialVersion? game, int generations, TextWriter? writer, char aliveCell, char deadCell)
    {
        ArgumentNullException.ThrowIfNull(game);
        ArgumentNullException.ThrowIfNull(writer);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(generations);

        var sw = Stopwatch.StartNew();
        for (int i = 0; i < generations; i++)
        {
            game.NextGeneration();
            //WriteGenerationWithTime(game.CurrentGeneration, writer, aliveCell, deadCell, i + 1, sw.Elapsed);
        }

        sw.Stop();
        return sw.Elapsed;
    }

    /// <summary>
    /// Asynchronously simulates the evolution of Conway's Game of Life for a specified number of generations using the parallel version.
    /// The result is written to the provided TextWriter using the specified characters for alive and dead cells.
    /// </summary>
    /// <param name="game">The parallel version of the Game of Life.</param>
    /// <param name="generations">The number of generations to simulate.</param>
    /// <param name="writer">The <see cref="TextWriter"/> used to output the simulation result.</param>
    /// <param name="aliveCell">The character representing an alive cell.</param>
    /// <param name="deadCell">The character representing a dead cell.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <param name="game"/> parameters is null.</exception>
    /// <exception cref="ArgumentNullException">Thrown when <param name="writer"/> parameters is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <param name="generations"/> is less than or equal to 0.</exception>
    public static async Task<TimeSpan> SimulateAsync(this GameOfLifeParallelVersion? game, int generations, TextWriter? writer, char aliveCell, char deadCell)
    {
        CheckForExceptions(game, generations, writer);
        var sw = Stopwatch.StartNew();

        for (int i = 0; i < generations; i++)
        {
            game.NextGeneration();
            //await WriteGenerationWithTimeAsync(game.CurrentGeneration, writer, aliveCell, deadCell, i + 1, sw.Elapsed);
        }

        sw.Stop();
        return sw.Elapsed;
    }

    private static void CheckForExceptions(this GameOfLifeParallelVersion? game, int generations, TextWriter? writer)
    {
        ArgumentNullException.ThrowIfNull(game);
        ArgumentNullException.ThrowIfNull(writer);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(generations);
    }

    private static void WriteGenerationWithTime(bool[,] grid, TextWriter writer, char aliveCell, char deadCell, int generation, TimeSpan elapsed)
    {
        writer.WriteLine($"Generation {generation} [Elapsed: {elapsed.TotalMilliseconds:F2} ms]");
        WriteGrid(grid, writer, aliveCell, deadCell);
        writer.WriteLine();
    }

    private static async Task WriteGenerationWithTimeAsync(bool[,] grid, TextWriter writer, char aliveCell, char deadCell, int generation, TimeSpan elapsed)
    {
        await writer.WriteLineAsync($"Generation {generation} [Elapsed: {elapsed.TotalMilliseconds:F2} ms]");
        await WriteGridAsync(grid, writer, aliveCell, deadCell);
        await writer.WriteLineAsync();
    }

    private static void WriteGrid(bool[,] grid, TextWriter writer, char aliveCell, char deadCell)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                writer.Write(grid[i, j] ? aliveCell : deadCell);
            }

            writer.WriteLine();
        }

        writer.WriteLine();
    }

    private static async Task WriteGridAsync(bool[,] grid, TextWriter writer, char aliveCell, char deadCell)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                await writer.WriteAsync(grid[i, j] ? aliveCell : deadCell);
            }

            await writer.WriteLineAsync();
        }

        await writer.WriteLineAsync();
    }
}
