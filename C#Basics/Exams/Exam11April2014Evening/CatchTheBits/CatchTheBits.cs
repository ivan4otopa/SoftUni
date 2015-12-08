namespace CatchTheBits
{
    using System;

    class CatchTheBits
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

            string extractResult = string.Empty;

            for (int i = 1; i < result.Length; i += step)
            {
                extractResult += result[i];
            }

            if (extractResult.Length % 8 != 0)
            {
                extractResult = extractResult
                    .PadRight(
                        extractResult.Length + Math.Abs((extractResult.Length % 8) - 8),
                        '0');
            }

            string bits = string.Empty;

            for (int i = 0; i < extractResult.Length; i += 8)
            {
                bits = extractResult.Substring(i, 8);

                Console.WriteLine(Convert.ToByte(bits, 2));
            }
        }
    }
}
