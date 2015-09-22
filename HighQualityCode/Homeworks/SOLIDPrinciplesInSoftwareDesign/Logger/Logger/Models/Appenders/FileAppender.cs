namespace Logger.Models.Appenders
{
    using System.IO;

    using Logger.Contracts;

    public class FileAppender : Appender
    {
        private string file;

        public FileAppender(ILayout layout)
            : base(layout)
        {
        }

        public string File
        {
            get
            {
                return this.file;
            }
            set
            {
                this.file = value;
            }
        }
        
        public override void Print(string message, string reportLevel)
        {
            StreamWriter sw = new StreamWriter(@"C:\Users\lenovo\Desktop\" + this.file, true);
            sw.WriteLine(this.Layout.Format(message, reportLevel));
            sw.Close();
        }
    }
}
