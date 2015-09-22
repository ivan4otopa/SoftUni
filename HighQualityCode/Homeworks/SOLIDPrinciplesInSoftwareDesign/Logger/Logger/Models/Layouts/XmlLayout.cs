namespace Logger.Models.Layouts
{
    using System;
    using System.Text;

    public class XmlLayout : Layout
    {
        public override string Format(string message, string reportLevel)
        {
            StringBuilder xmlLayout = new StringBuilder();
            xmlLayout.AppendLine("<log>");
            xmlLayout.AppendFormat("    <date>{0}</date>", DateTime.Now).AppendLine();
            xmlLayout.AppendFormat("    <level>{0}</level>", reportLevel).AppendLine();
            xmlLayout.AppendFormat("    <message>{0}</message", message).AppendLine();
            xmlLayout.Append("</log>");

            return xmlLayout.ToString();
        }
    }
}
