using EasySpan;

namespace AlgorithmLibrary.Problems;

public class ALP_BFS_0001_SlidingPuzzle : IProblem
{
    private static readonly int[][] Neighbors =
    [
        [1, 3],
        [0, 2, 4],
        [1, 5],
        [0, 4],
        [1, 3, 5],
        [2, 4]
    ];

    public void Run()
    {
        while (Console.ReadLine() is { } line)
        {
            if (!TryParseState(line, out var state))
            {
                Console.WriteLine($"Invalid state: {line}");
                continue;
            }

            var distance = FindDistance(state);
            Console.WriteLine($"Distance: {distance}");
        }
    }

    private static bool TryParseState(string line, out string state)
    {
        state = string.Empty;
        if (line.Length != 6)
        {
            return false;
        }

        Span<char> digitsSpan = stackalloc char[6];
        var digits = new SpanList<char>(digitsSpan);
        Span<bool> seen = stackalloc bool[6];

        foreach (var ch in line)
        {
            if (ch is < '0' or > '5')
            {
                return false;
            }

            var value = ch - '0';
            if (seen[value])
            {
                return false;
            }

            seen[value] = true;
            digits.Add(ch);
        }

        state = new string(digits);
        return true;
    }

    private static int FindDistance(string state)
    {
        const string target = "123450";

        if (state == target)
        {
            return 0;
        }

        var dic = new Dictionary<string, int>();
        var queue = new Queue<string>();

        dic.Add(state, 0);
        queue.Enqueue(state);

        do
        {
            var current = queue.Dequeue();
            var zeroIndex = current.IndexOf('0');
            var currentDistance = dic[current] + 1;

            var neighbor = Neighbors[zeroIndex];
            foreach (var nextIndex in neighbor)
            {
                var nextState = Swap(current, zeroIndex, nextIndex);
                if (!dic.TryAdd(nextState, currentDistance))
                {
                    continue;
                }

                if (nextState == target)
                {
                    return currentDistance;
                }

                queue.Enqueue(nextState);
            }
        } while (queue.Count > 0);

        return -1;
    }

    private static string Swap(string state, int i, int j)
    {
        Span<char> digitsSpan = stackalloc char[6];
        for (var index = 0; index < state.Length; index++)
        {
            if (index == i)
            {
                digitsSpan[index] = state[j];
            }
            else if (index == j)
            {
                digitsSpan[index] = state[i];
            }
            else
            {
                digitsSpan[index] = state[index];
            }
        }

        return new string(digitsSpan);
    }
}
