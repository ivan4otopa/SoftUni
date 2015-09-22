namespace Logger.Models.Layouts
{
    using System;

    public class SimpleLayout : Layout
    {
        public override string Format(string message, string reportLevel)
        {
            string format = DateTime.Now + " - " + reportLevel + " - " + message;

            return format;
        }
    }
}
