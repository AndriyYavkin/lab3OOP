namespace GameOfLife;

/// <summary>
/// Represents Conway's Game of Life in a sequential version.
/// The class provides methods to simulate the game's evolution based on simple rules.
/// </summary>
public sealed class GameOfLifeSequentialVersion
{
    private readonly bool[,] initialState;
    private bool[,] grid;

    /// <summary>
    /// Initializes a new instance of the <see cref="GameOfLifeSequentialVersion"/> class with the specified number of rows and columns. The initial state of the grid is randomly set with alive or dead cells.
    /// </summary>
    /// <param name="rows">The number of rows in the grid.</param>
    /// <param name="columns">The number of columns in the grid.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the number of rows or columns is less than or equal to 0.</exception>
    public GameOfLifeSequentialVersion(int rows, int columns)
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
    /// Initializes a new instance of the <see cref="GameOfLifeSequentialVersion"/> class with the given grid.
    /// </summary>
    /// <param name="grid">The 2D array representing the initial state of the grid.</param>
    /// <exception cref="ArgumentNullException">Thrown when the input grid is null.</exception>
    public GameOfLifeSequentialVersion(bool[,] grid)
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
        int columns = this.grid.GetLength(1);
        bool[,] newGrid = new bool[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                int aliveNeighbors = this.CountAliveNeighbors(i, j);

                newGrid[i, j] = this.grid[i, j]
                    ? aliveNeighbors == 2 || aliveNeighbors == 3
                    : aliveNeighbors == 3;
            }
        }

        this.grid = newGrid;
        this.Generation++;
    }

    /// <summary>
    /// Counts the number of alive neighbors for a given cell in the grid.
    /// </summary>
    /// <param name="row">The row index of the cell.</param>
    /// <param name="column">The column index of the cell.</param>
    /// <returns>The number of alive neighbors for the specified cell.</returns>
    private int CountAliveNeighbors(int row, int column)
    {
        int aliveCount = 0;
        int rows = this.grid.GetLength(0);
        int columns = this.grid.GetLength(1);

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                {
                    continue;
                }

                int neighborRow = row + i;
                int neighborCol = column + j;

                if (neighborRow >= 0 && neighborRow < rows && neighborCol >= 0 && neighborCol < columns && this.grid[neighborRow, neighborCol])
                {
                    aliveCount++;
                }
            }
        }

        return aliveCount;
    }
}
