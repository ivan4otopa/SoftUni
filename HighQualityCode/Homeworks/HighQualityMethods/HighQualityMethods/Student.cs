using System;
using System.Globalization;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate;

            if (!DateTime.TryParseExact(this.OtherInfo.Substring(this.OtherInfo.Length - 10), "dd.mm.yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out firstDate))
            {
                throw new FormatException("Invalid date.");
            }

            DateTime secondDate;

            if (!DateTime.TryParseExact(other.OtherInfo.Substring(other.OtherInfo.Length - 10), "dd.mm.yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out secondDate))
            {
                throw new FormatException("Invalid date.");
            }

            return firstDate > secondDate;
        }
    }
}
