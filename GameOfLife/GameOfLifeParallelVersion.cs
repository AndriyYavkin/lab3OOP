using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace GameOfLife;

/// <summary>
/// Represents Conway's Game of Life in a parallel version.
/// The class provides methods to simulate the game's evolution based on simple rules.
/// </summary>
public sealed class GameOfLifeParallelVersion
{
    private readonly bool[,] initialState;
    private bool[,] grid;

    /// <summary>
    /// Initializes a new instance of the <see cref="GameOfLifeParallelVersion"/> class with the specified number of rows and columns of the grid. The initial state of the grid is randomly set with alive or dead cells.
    /// </summary>
    /// <param name="rows">The number of rows in the grid.</param>
    /// <param name="columns">The number of columns in the grid.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the number of rows or columns is less than or equal to 0.</exception>
    public GameOfLifeParallelVersion(int rows, int columns)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(rows);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(columns);

        this.grid = new bool[rows, columns];
        this.initialState = new bool[rows, columns];
        Random random = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                bool isAlive = random.Next(2) == 0;
                this.grid[i, j] = this.initialState[i, j] = isAlive;
            }
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GameOfLifeParallelVersion"/> class with the given grid.
    /// </summary>
    /// <param name="grid">The 2D array representing the initial state of the grid.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <param name="grid"/> is null.</exception>
    public GameOfLifeParallelVersion(bool[,] grid)
    {
        ArgumentNullException.ThrowIfNull(grid);

        this.grid = (bool[,])grid.Clone();
        this.initialState = (bool[,])grid.Clone();
    }

    /// <summary>
    /// Gets the current generation grid as a separate copy.
    /// </summary>
    public bool[,] CurrentGeneration
    {
        get
        {
            return this.grid;
        }
    }

    /// <summary>
    /// Gets the current generation number.
    /// </summary>
    public int Generation { get; private set; }

    /// <summary>
    /// Restarts the game by resetting the current grid to the initial state.
    /// </summary>
    public void Restart()
    {
        this.Generation = 0;
        this.grid = (bool[,])this.initialState.Clone();
    }

    /// <summary>
    /// Advances the game to the next generation based on the rules of Conway's Game of Life.
    /// </summary>
    public void NextGeneration()
    {
        int rows = this.grid.GetLength(0);
        int cols = this.grid.GetLength(1);
        bool[,] newGrid = new bool[rows, cols];

        var partitioner = Partitioner.Create(0, rows, GetChunkSize(rows));
        _ = Parallel.ForEach(partitioner, range =>
        {
            for (int i = range.Item1; i < range.Item2; i++)
            {
                this.ProcessRow(i, cols, newGrid);
            }
        });

        this.grid = newGrid;
        this.Generation++;
    }

    private static int GetChunkSize(int totalRows)
    {
        // Dynamic chunk size calculation based on processor count
        const int MIN_CHUNK_SIZE = 16;
        int chunkSize = totalRows / (Environment.ProcessorCount * 4);
        return Math.Max(chunkSize, MIN_CHUNK_SIZE);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ProcessRow(int row, int cols, bool[,] newGrid)
    {
        // Optimized row processing with reduced bounds checks
        int rowStart = Math.Max(row - 1, 0);
        int rowEnd = Math.Min(row + 1, this.grid.GetLength(0) - 1);

        for (int col = 0; col < cols; col++)
        {
            int aliveNeighbors = 0;
            int colStart = Math.Max(col - 1, 0);
            int colEnd = Math.Min(col + 1, cols - 1);

            for (int i = rowStart; i <= rowEnd; i++)
            {
                for (int j = colStart; j <= colEnd; j++)
                {
                    if (this.grid[i, j] && !(i == row && j == col))
                    {
                        aliveNeighbors++;
                    }
                }
            }

            newGrid[row, col] = this.grid[row, col]
                ? aliveNeighbors == 2 || aliveNeighbors == 3
                : aliveNeighbors == 3;
        }
    }
}
