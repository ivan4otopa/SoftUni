namespace BitSifting
{
    using System;

    class BitSifting
    {
        static void Main()
        {
            ulong number = ulong.Parse(Console.ReadLine());
            int numberOfSieves = int.Parse(Console.ReadLine());
            string binaryNumber = Convert.ToString((long)number, 2).PadLeft(64, '0');
            ulong sieve = 0;
            string binarySieve = string.Empty;
            string result = string.Empty;

            for (int i = 0; i < numberOfSieves; i++)
            {
                sieve = ulong.Parse(Console.ReadLine());
                binarySieve = Convert.ToString((long)sieve, 2).PadLeft(64, '0');

                for (int j = 0; j < 64; j++)
                {
                    if (binaryNumber[j] == '1' && binarySieve[j] == '0')
                    {
                        result += '1';
                    }
                    else
                    {
                        result += '0';
                    }
                }

                binaryNumber = result;
                result = string.Empty;
            }

            int onesCount = 0;

            for (int i = 0; i < 64; i++)
            {
                if (binaryNumber[i] == '1')
                {
                    onesCount++;
                }
            }

            Console.WriteLine(onesCount);
        }
    }
}
