using static System.Console;

namespace GameOfLife.ConsoleClient;

public static class Program
{
    public static async Task Main()
    {
        WarmUpPC();
        bool[,] grid = InitializeGrid();

        int generations = GetGenerationsFromUser();

        await RunParallelSimulationAsync(grid, generations);
        RunSequentialSimulation(grid, generations);

        WriteLine("\nPress any key to exit...");
        _ = ReadKey();
    }

    private static void WarmUpPC()
    {
        // Small grid for warm-up
        bool[,] warmUpGrid = new bool[10, 10];
        Random rnd = new Random();

        // Initialize random values
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                warmUpGrid[i, j] = rnd.Next(2) == 0;
            }
        }

        // Warm up sequential version
        var sequentialGame = new GameOfLifeSequentialVersion(warmUpGrid);
        sequentialGame.NextGeneration();

        // Warm up parallel version
        var parallelGame = new GameOfLifeParallelVersion(warmUpGrid);
        parallelGame.NextGeneration();
    }

    private static bool[,] InitializeGrid()
    {
        WriteLine("Choose grid initialization method:");
        WriteLine("1. Predefined pattern (default)");
        WriteLine("2. Random grid");
        Write("Enter your choice (1 or 2): ");

        string choice = ReadLine()?.Trim() ?? "1";
        return choice == "2" ? CreateRandomGrid() : GetPredefinedGrid();
    }

    private static bool[,] GetPredefinedGrid()
    {
        bool[,] grid =
        {
            { false, false, false, false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false, false, false, false },
            { false, false, false, false, true, true, true, false, false, false, false },
            { false, false, false, true, false, false, false, true, false, false, false },
            { false, false, false, true, false, false, false, true, false, false, false },
            { false, false, false, false, true, true, true, false, false, false, false },
            { false, false, false, false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false, false, false, false },
            { false, false, false, false, true, true, true, false, false, false, false },
            { false, false, false, true, false, false, false, true, false, false, false },
            { false, false, false, true, false, false, false, true, false, false, false },
            { false, false, false, false, true, true, true, false, false, false, false },
            { false, false, false, false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false, false, false, false },
        };

        return grid;
    }

    private static bool[,] CreateRandomGrid()
    {
        int rows, cols;

        do
        {
            Write("Enter number of rows (positive integer): ");
        }
        while (!int.TryParse(ReadLine(), out rows) || rows <= 0);

        do
        {
            Write("Enter number of columns (positive integer): ");
        }
        while (!int.TryParse(ReadLine(), out cols) || cols <= 0);

        bool[,] grid = new bool[rows, cols];
        Random rnd = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                grid[i, j] = rnd.Next(2) == 0;
            }
        }

        return grid;
    }

    private static int GetGenerationsFromUser()
    {
        int generations;
        do
        {
            Write("Enter the number of generations to simulate (positive integer): ");
        }
        while (!int.TryParse(ReadLine(), out generations) || generations <= 0);

        return generations;
    }

    private static void RunSequentialSimulation(bool[,] grid, int generations)
    {
        using var syncWriter = new StreamWriter(File.Create("sync_simulation.txt"));
        var game = new GameOfLifeSequentialVersion(grid);

        WriteLine("\nStarting sequential simulation...");
        var syncTime = game.Simulate(generations, syncWriter, '■', '·');
        syncWriter.WriteLine($"\nTotal sequential execution time: {syncTime.TotalMilliseconds:F2} ms");

        WriteLine($"Sequential completed. Results saved to sync_simulation.txt. Time spend: {syncTime}");
    }

    private static async Task RunParallelSimulationAsync(bool[,] grid, int generations)
    {
        await using var asyncWriter = new StreamWriter(File.Create("async_simulation.txt"));
        var game = new GameOfLifeParallelVersion(grid);

        WriteLine("\nStarting parallel simulation...");
        var asyncTime = await game.SimulateAsync(generations, asyncWriter, '●', '○');
        await asyncWriter.WriteLineAsync($"\nTotal parallel execution time: {asyncTime.TotalMilliseconds:F2} ms");

        WriteLine($"Parallel completed. Results saved to async_simulation.txt. Time spend: {asyncTime}");
    }
}
