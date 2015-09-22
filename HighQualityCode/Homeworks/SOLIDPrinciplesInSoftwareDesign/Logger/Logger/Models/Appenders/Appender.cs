namespace Logger.Models.Appenders
{
    using Logger.Contracts;
    using Logger.Enums;

    public abstract class Appender : IAppender
    {
        private ILayout layout;
        private ReportLevel reportLevel;

        public Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout
        {
            get
            {
                return this.layout;
            }
            set
            {
                this.layout = value;
            }
        }

        public ReportLevel ReportLevel
        {
            get
            {
                return this.reportLevel;
            }
            set
            {
                this.reportLevel = value;
            }
        }

        public abstract void Print(string message, string reportLevel);
    }
}
