namespace SumOfElements
{
    using System;

    class SumOfElements
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            long sum = 0;
            bool hasEqual = false;
            long minDifference = long.MaxValue;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (j != i)
                    {
                        sum += int.Parse(input[j]);
                    }
                }

                if (sum == int.Parse(input[i]))
                {
                    hasEqual = true;

                    break;
                }
                else
                {
                    if (Math.Abs(sum - int.Parse(input[i])) < minDifference)
                    {
                        minDifference = Math.Abs(sum - int.Parse(input[i]));
                    }
                }

                sum = 0;
            }

            if (hasEqual)
            {
                Console.WriteLine("Yes, sum={0}", sum);
            }
            else
            {
                Console.WriteLine("No, diff={0}", minDifference);
            }
        }
    }
}
