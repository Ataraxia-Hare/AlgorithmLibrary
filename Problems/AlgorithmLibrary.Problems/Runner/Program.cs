namespace AlgorithmLibrary.Problems;

internal static class Program
{
    private static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please specify a problem ID.");
            return;
        }

        switch (args[0])
        {
            case "ALP-BFS-0001":
                new ALP_BFS_0001_SlidingPuzzle().Run();
                break;
            default:
                Console.WriteLine($"Problem not found: {args[0]}");
                break;
        }
    }
}
