namespace WiggleWiggle
{
    using System;

    class WiggleWiggle
    {
        static void Main()
        {
            string[] numbers = Console.ReadLine().Split(' ');
            long firstNumber = 0;
            long secondNumber = 0;
            string firstNumberBinary = "";
            string secondNumberBinary = "";
            string temporaryFistNumberBinary = "";

            for (int i = 0; i < numbers.Length; i += 2)
            {
                firstNumber = long.Parse(numbers[i]);
                secondNumber = long.Parse(numbers[i + 1]);
                firstNumberBinary = Convert.ToString(firstNumber, 2).PadLeft(63, '0');
                temporaryFistNumberBinary = firstNumberBinary;
                secondNumberBinary = Convert.ToString(secondNumber, 2).PadLeft(63, '0');

                for (int j = 0; j < 64; j++)
                {
                    if (j % 2 == 0)
                    {
                        if (firstNumberBinary[j] != secondNumberBinary[j])
                        {
                            if (firstNumberBinary[j] == '1')
                            {
                                firstNumberBinary = firstNumberBinary.Remove(j, 1).Insert(j, "0");
                            }
                            else
                            {
                                firstNumberBinary = firstNumberBinary.Remove(j, 1).Insert(j, "1");
                            }
                        }
                    }
                }

                for (int j = 0; j < 64; j++)
                {
                    if (j % 2 == 0)
                    {
                        if (secondNumberBinary[j] != temporaryFistNumberBinary[j])
                        {
                            if (secondNumberBinary[j] == '1')
                            {
                                secondNumberBinary = secondNumberBinary.Remove(j, 1).Insert(j, "0");
                            }
                            else
                            {
                                secondNumberBinary = secondNumberBinary.Remove(j, 1).Insert(j, "1");
                            }
                        }
                    }
                }

                for (int j = 0; j < 63; j++)
                {
                    if (firstNumberBinary[j] == '1')
                    {
                        firstNumberBinary = firstNumberBinary.Remove(j, 1).Insert(j, "0");
                    }
                    else
                    {
                        firstNumberBinary = firstNumberBinary.Remove(j, 1).Insert(j, "1");
                    }

                    if (secondNumberBinary[j] == '1')
                    {
                        secondNumberBinary = secondNumberBinary.Remove(j, 1).Insert(j, "0");
                    }
                    else
                    {
                        secondNumberBinary = secondNumberBinary.Remove(j, 1).Insert(j, "1");
                    }
                }

                Console.WriteLine(
                    "{0} {1}\n{2} {3}",
                    Convert.ToUInt64(firstNumberBinary, 2),
                    firstNumberBinary,
                    Convert.ToUInt64(secondNumberBinary, 2),
                    secondNumberBinary
                );
            }
        }
    }
}
