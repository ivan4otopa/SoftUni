using Logger.Contracts;
using Logger.Enums;

namespace Logger.Models.Loggers
{
    class Logger : ILogger
    {
        private const ReportLevel ReportLevelInfo = ReportLevel.Info;
        private const ReportLevel ReportLevelWarning = ReportLevel.Warning;
        private const ReportLevel ReportLevelError = ReportLevel.Error;
        private const ReportLevel ReportLevelCritical = ReportLevel.Critical;
        private const ReportLevel ReportLevelFatal = ReportLevel.Fatal;

        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public IAppender[] Appenders
        {
            get
            {
                return this.appenders;
            }
            set
            {
                this.appenders = value;
            }
        }


        public void Info(string message)
        {
            for (int i = 0; i < this.appenders.Length; i++)
            {
                if (this.appenders[i].ReportLevel < ReportLevel.Warning)
                {
                    this.appenders[i].Print(message, ReportLevelInfo.ToString());
                }
            }
        }

        public void Warn(string message)
        {
            for (int i = 0; i < this.appenders.Length; i++)
            {
                if (this.appenders[i].ReportLevel < ReportLevel.Error)
                {
                    this.appenders[i].Print(message, ReportLevelWarning.ToString());
                }
            }
        }

        public void Error(string message)
        {
            for (int i = 0; i < this.appenders.Length; i++)
            {
                if (this.appenders[i].ReportLevel < ReportLevel.Critical)
                {
                    this.appenders[i].Print(message, ReportLevelError.ToString());
                }
            }
        }

        public void Critical(string message)
        {
            for (int i = 0; i < this.appenders.Length; i++)
            {
                if (this.appenders[i].ReportLevel < ReportLevel.Fatal)
                {
                    this.appenders[i].Print(message, ReportLevelCritical.ToString());
                }
            }
        }

        public void Fatal(string message)
        {
            for (int i = 0; i < this.appenders.Length; i++)
            {
                this.appenders[i].Print(message, ReportLevelFatal.ToString());
            }
        }
    }
}
