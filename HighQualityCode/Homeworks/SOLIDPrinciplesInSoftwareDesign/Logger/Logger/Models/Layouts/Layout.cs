namespace Logger.Models.Layouts
{
    using Logger.Contracts;

    public abstract class Layout : ILayout
    {
        public abstract string Format(string message, string reportLevel);
    }
}
