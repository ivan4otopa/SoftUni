namespace ShuffleBits
{
    using System;
    using System.Numerics;

    class ShuffleBits
    {
        static void Main()
        {
            uint firstNumber = uint.Parse(Console.ReadLine());
            uint secondNumber = uint.Parse(Console.ReadLine());
            string firstNumberBinary = Convert.ToString(firstNumber, 2).PadLeft(32, '0');
            string secondNumberBinary = Convert.ToString(secondNumber, 2).PadLeft(32, '0');
            string newBinaryNumber = string.Empty;
            
            if (firstNumber >= secondNumber)
            {
                for (int i = 0; i < 32; i++)
                {
                    newBinaryNumber += firstNumberBinary[i];
                    newBinaryNumber += secondNumberBinary[i];
                }
            }
            else
            {
                for (int i = 0; i < 31; i += 2)
                {
                    newBinaryNumber += firstNumberBinary[i];
                    newBinaryNumber += firstNumberBinary[i + 1];
                    newBinaryNumber += secondNumberBinary[i];
                    newBinaryNumber += secondNumberBinary[i + 1];
                }
            }

            Console.WriteLine(Convert.ToUInt64(newBinaryNumber, 2));
        }
    }
}
