namespace StringEditor
{
    using System;

    using Wintellect.PowerCollections;

    class StringEditor
    {
        static BigList<char> stringRope = new BigList<char>();

        static void Main()
        {
            string command = Console.ReadLine();
            string commandName = string.Empty;
            int startIndex = 0;
            string text = string.Empty;
            int count = 0;
            int position = 0;

            while (command != "END")
            {
                var commandTokens = command.Split(' ');

                commandName = commandTokens[0].Trim();
                text = string.Empty;

                switch (commandName)
                {
                    case "APPEND":
                        if (commandTokens.Length > 2)
                        {
                            for (int i = 1; i < commandTokens.Length; i++)
                            {
                                text += string.Format("{0} ", commandTokens[i]);
                            }
                        }
                        else
                        {
                            text = commandTokens[1].Trim();
                        }

                        if (text[text.Length - 1] == ' ')
                        {
                            text = text.Substring(0, text.Length - 1);
                        }

                        Console.WriteLine(AppendString(text));

                        break;
                    case "INSERT":
                        if (commandTokens.Length > 3)
                        {
                            for (int i = 1; i < commandTokens.Length - 1; i++)
                            {
                                text += string.Format("{0} ", commandTokens[i]);
                            }
                        }
                        else
                        {
                            text = commandTokens[1].Trim();
                        }

                        if (text[text.Length - 1] == ' ')
                        {
                            text = text.Substring(0, text.Length - 1);
                        }

                        position = int.Parse(
                            commandTokens[commandTokens.Length - 1].Trim());

                        Console.WriteLine(InsertString(text, position));

                        break;                    
                    case "DELETE":
                        startIndex = int.Parse(commandTokens[1].Trim());
                        count = int.Parse(commandTokens[2].Trim());

                        Console.WriteLine(DeleteString(startIndex, count));

                        break;
                    case "REPLACE":
                        startIndex = int.Parse(commandTokens[1].Trim());
                        count = int.Parse(commandTokens[2].Trim());

                        if (commandTokens.Length > 4)
                        {
                            for (int i = 3; i < commandTokens.Length; i++)
                            {
                                text += string.Format("{0} ", commandTokens[i]);
                            }
                        }
                        else
                        {
                            text = commandTokens[3].Trim();
                        }

                        if (text[text.Length - 1] == ' ')
                        {
                            text = text.Substring(0, text.Length - 1);
                        }

                        Console.WriteLine(ReplaceString(startIndex, count, text));

                        break;
                    case "PRINT":
                        Console.WriteLine(string.Join("", stringRope));

                        break;
                }

                command = Console.ReadLine();
            }
        }

        static string AppendString(string text)
        {
            stringRope.AddRange(text);

            return "OK";
        }

        static string InsertString(string text, int position)
        {
            if (position < 0 || position >= text.Length)
            {
                return "ERROR";
            }
            
            stringRope.InsertRange(position, text);

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

        static string ReplaceString(int startIndex, int count, string text)
        {
            if (startIndex < 0 || startIndex >= stringRope.Count ||
                startIndex + count > stringRope.Count)
            {
                return "ERROR";
            }

            DeleteString(startIndex, count);
            InsertString(text, startIndex);

            return "OK";
        }
    }
}
