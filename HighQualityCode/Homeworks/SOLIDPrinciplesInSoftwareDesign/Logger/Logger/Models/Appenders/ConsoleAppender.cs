namespace Logger.Models.Appenders
{
    using System;

    using Logger.Contracts;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Print(string message, string reportLevel)
        {
            Console.WriteLine(this.Layout.Format(message, reportLevel));
        }
    }
}
