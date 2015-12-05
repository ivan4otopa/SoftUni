namespace BitsInverter
{
    using System;

    class BitsInverter
    {
        static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            int step = int.Parse(Console.ReadLine());
            string combinedBits = string.Empty;
            int number = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                number = int.Parse(Console.ReadLine());
                combinedBits += Convert.ToString(number, 2).PadLeft(8, '0');
            }

            for (int i = 0; i < combinedBits.Length; i += step)
            {
                if (combinedBits[i] == '0')
                {
                    combinedBits = combinedBits.Remove(i, 1).Insert(i, "1");
                }
                else
                {
                    combinedBits = combinedBits.Remove(i, 1).Insert(i, "0");
                }
            }

            string bits = string.Empty;

            for (int i = 0; i < combinedBits.Length; i += 8)
            {
                bits = combinedBits.Substring(i, 8);

                Console.WriteLine(Convert.ToByte(bits, 2));
            }
        }
    }
}
