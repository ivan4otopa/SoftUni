namespace RopeForEfficientStringEditing
{
    using System;

    using Wintellect.PowerCollections;

    class RopeForEfficientStringEditing
    {
        static BigList<char> stringRope = new BigList<char>();

        static void Main()
        {
            string command = Console.ReadLine();
            string commandName = string.Empty;
            int startIndex = 0;
            string text = string.Empty;
            int count = 0;

            while (command != "PRINT")
            {
                var commandTokens = command.Split(' ');
                
                commandName = commandTokens[0].Trim();

                switch (commandName)
                {
                    case "INSERT":
                        text = commandTokens[1].Trim();
                        Console.WriteLine(InsertString(text));

                        break;
                    case "APPEND":
                        text = commandTokens[1].Trim();
                        Console.WriteLine(AppendString(text));

                        break;
                    case "DELETE":
                        startIndex = int.Parse(commandTokens[1].Trim());
                        count = int.Parse(commandTokens[2].Trim());
                        Console.WriteLine(DeleteString(startIndex, count));

                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join("", stringRope));
        }

        static string InsertString(string text)
        {
            for (int i = text.Length - 1; i >= 0; i--)
            {
                stringRope.AddToFront(text[i]);
            }

            return "OK";
        }

        static string AppendString(string text)
        {
            stringRope.AddRange(text);

            return "OK";
        }

        static string DeleteString(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex > stringRope.Count ||
                startIndex + count > stringRope.Count)
            {
                return "ERROR";
            }

            for (int i = startIndex; i < startIndex + count; i++)
            {
                stringRope.RemoveAt(startIndex);
            }

            return "OK";
        }
    }
}
