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
            default:
                Console.WriteLine("Problem not found.");
                break;
        }
    }
}
