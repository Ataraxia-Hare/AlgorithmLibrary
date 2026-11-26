namespace AlgorithmLibrary.Problems.Tests;

[Collection("Console")]
public class ALP_BFS_0001_Test
{
    [Theory]
    [InlineData("123450", 0)]
    [InlineData("123405", 1)]
    [InlineData("023145", 3)]
    [InlineData("412503", 5)]
    [InlineData("150324", 13)]
    [InlineData("450123", 21)]
    public void Run_SolvableState_PrintsMinimumDistance(string state, int expected)
    {
        var output = RunWithInput(state);

        Assert.Equal([$"Distance: {expected}"], output);
    }

    [Theory]
    [InlineData("123540")]
    [InlineData("213450")]
    [InlineData("543120")]
    public void Run_UnsolvableState_PrintsNegativeOne(string state)
    {
        var output = RunWithInput(state);

        Assert.Equal(["Distance: -1"], output);
    }

    [Theory]
    [InlineData("")]
    [InlineData("12345")]
    [InlineData("1234500")]
    [InlineData("123456")]
    [InlineData("112345")]
    [InlineData("12345a")]
    [InlineData(" 12345")]
    public void Run_InvalidState_PrintsInvalidMessage(string state)
    {
        var output = RunWithInput(state);

        Assert.Equal([$"Invalid state: {state}"], output);
    }

    [Fact]
    public void Run_MultipleLines_ProcessesEachLineInOrder()
    {
        var output = RunWithInput("123450", "abc", "412503", "123540");

        Assert.Equal(
            ["Distance: 0", "Invalid state: abc", "Distance: 5", "Distance: -1"],
            output);
    }

    [Fact]
    public void Run_EmptyInput_PrintsNothing()
    {
        var output = RunWithInput();

        Assert.Empty(output);
    }

    private static List<string> RunWithInput(params string[] lines)
    {
        var originalIn = Console.In;
        var originalOut = Console.Out;
        using var input = new StringReader(string.Concat(lines.Select(line => line + "\n")));
        using var output = new StringWriter();

        try
        {
            Console.SetIn(input);
            Console.SetOut(output);
            new ALP_BFS_0001_SlidingPuzzle().Run();
        }
        finally
        {
            Console.SetIn(originalIn);
            Console.SetOut(originalOut);
        }

        var result = new List<string>();
        using var reader = new StringReader(output.ToString());
        while (reader.ReadLine() is { } line)
        {
            result.Add(line);
        }

        return result;
    }
}
