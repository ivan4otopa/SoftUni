using System;
using System.Linq;

class Needles
{
    static void Main()
    {
        var tokens = Console.ReadLine().Split(' ');
        int c = int.Parse(tokens[0]);
        int n = int.Parse(tokens[1]);
        var receivingGroup = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        var insertingGroup = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        var result = new int[insertingGroup.Length];        
         
        for (int i = 0; i < insertingGroup.Length; i++)
        {
            for (int j = 0; j < receivingGroup.Length; j++)
            {
                if (j == receivingGroup.Length - 1 &&
                    insertingGroup[i] > receivingGroup[j])
                {
                    result[i] = j + 1;

                    break;
                }

                int nextNum = GetNextNum(receivingGroup, j);

                if (insertingGroup[i] <= nextNum)
                {
                    result[i] = j;

                    break;
                }
            }
        }

        Console.WriteLine(string.Join(" ", result));
    }

    private static int GetNextNum(int[] array, int start)
    {
        for (int i = start; i < array.Length; i++)
        {
            if (array[i] != 0)
            {
                return array[i];
            }
        }

        return -1;
    }
}
