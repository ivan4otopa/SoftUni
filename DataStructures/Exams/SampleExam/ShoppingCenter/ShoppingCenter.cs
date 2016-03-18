namespace ShoppingCenter
{
    using System;
    using System.Globalization;
    using System.Threading;

    class ShoppingCenter
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var center = new ShoppingCenterFast();
            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= commandsCount; i++)
            {
                string command = Console.ReadLine();
                string commandResult = center.ProcessCommand(command);

                Console.WriteLine(commandResult);
            }
        }
    }
}
