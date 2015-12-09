namespace BitKiller
{
    using System;

    class BitKiller
    {
        static void Main()
        {
            int numberOfBytes = int.Parse(Console.ReadLine());
            int step = int.Parse(Console.ReadLine());
            string result = string.Empty;
            int number = 0;

            for (int i = 0; i < numberOfBytes; i++)
            {
                number = int.Parse(Console.ReadLine());
                result += Convert.ToString(number, 2).PadLeft(8, '0');
            }

            for (int i = 1; i < result.Length; i += step)
            {
                result = result.Remove(i, 1).Insert(i, "!");             
            }

            result = result.Replace("!", string.Empty);

            if (result.Length % 8 != 0)
            {
                result = result
                    .PadRight(result.Length + Math.Abs((result.Length % 8) - 8), '0');
            }

            string bits = string.Empty;

            for (int i = 0; i < result.Length; i += 8)
            {
                bits = result.Substring(i, 8);

                Console.WriteLine(Convert.ToByte(bits, 2));
            }
        }
    }
}
