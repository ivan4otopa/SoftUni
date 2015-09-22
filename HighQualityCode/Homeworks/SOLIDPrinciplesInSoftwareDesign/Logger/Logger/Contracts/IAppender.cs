namespace Logger.Contracts
{
    using Logger.Enums;

    public interface IAppender
    {
        ILayout Layout
        {
            get;
            set;
        }

        ReportLevel ReportLevel
        {
            get;
            set;
        }

        void Print(string message, string reportLevel);
    }
}
