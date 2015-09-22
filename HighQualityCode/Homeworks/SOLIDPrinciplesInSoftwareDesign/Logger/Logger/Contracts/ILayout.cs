namespace Logger.Contracts
{
    using System;

    public interface ILayout
    {
        string Format(string message, string reportLevel);
    }
}
