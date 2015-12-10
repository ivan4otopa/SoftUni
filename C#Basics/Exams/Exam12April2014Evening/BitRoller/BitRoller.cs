namespace BitRoller
{
    using System;

    class BitRoller
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int freezePosition = int.Parse(Console.ReadLine());
            int rolls = int.Parse(Console.ReadLine());
            string binaryNumber = Convert.ToString(number, 2).PadLeft(19, '0');
            char characterAtPosition = binaryNumber[binaryNumber.Length - freezePosition - 1];
            
            binaryNumber = binaryNumber
                .Remove(binaryNumber.Length - freezePosition - 1, 1)
                .Insert(binaryNumber.Length - freezePosition - 1, string.Empty);

            char[] newBinary = new char[binaryNumber.Length];
            string result = string.Empty;

            if (rolls > 0)
            {
                for (int i = 0; i < rolls; i++)
                {
                    for (int j = 0; j < binaryNumber.Length; j++)
                    {
                        newBinary[(j + 1) % binaryNumber.Length] = binaryNumber[j];
                    }

                    binaryNumber = new string(newBinary);
                }

                result = new string(newBinary);
            }
            else
            {
                result = binaryNumber;
            }

            result = result.Insert(binaryNumber.Length - freezePosition, characterAtPosition.ToString());

            Console.WriteLine(Convert.ToInt32(result, 2));
        }
    }
}
