using static System.Console;

namespace GameOfLife.ConsoleClient;

public static class Program
{
    public static async Task Main()
    {
        bool[,] grid = InitializeGrid();

        int generations = GetGenerationsFromUser();

        await RunParallelSimulationAsync(grid, generations);
        RunSequentialSimulation(grid, generations);

        WriteLine("\nPress any key to exit...");
        _ = ReadKey();
    }

    private static bool[,] InitializeGrid()
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
