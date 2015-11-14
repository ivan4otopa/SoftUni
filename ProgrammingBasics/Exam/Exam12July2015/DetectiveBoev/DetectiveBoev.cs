namespace DetectiveBoev
{
    using System;

    class DetectiveBoev
    {
        static void Main()
        {
            string secretWord = Console.ReadLine();
            string encryptedMessage = Console.ReadLine();
            int asciiSum = 0;
            int asciiRepresentation = 0;

            for (int i = 0; i < secretWord.Length; i++)
            {
                asciiRepresentation = (int)secretWord[i];
                asciiSum += asciiRepresentation;
            }

            int mask = 0;
            int digit = 0;

            while (asciiSum != 0)
            {
                digit = asciiSum % 10;
                mask += digit;
                asciiSum /= 10;

                if (asciiSum == 0 && mask > 9)
                {
                    asciiSum = mask;
                    mask = 0;
                }
            }

            asciiSum = mask;

            string message = "";

            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                asciiRepresentation = (int)encryptedMessage[i];
                
                if (asciiRepresentation % mask == 0)
                {
                    message += (char)(asciiRepresentation + mask);
                }
                else
                {
                    message += (char)(asciiRepresentation - mask);
                }
            }

            Console.WriteLine(Reverse(message));
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
