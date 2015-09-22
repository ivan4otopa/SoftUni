using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringDisperser.Classes
{
    class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable<char>
    {
        public StringDisperser(params string[] strings)
        {
            foreach (var str in strings)
            {
                this.TheString += str;
            }
        }

        public string TheString { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            StringDisperser s = (StringDisperser)obj;
            bool isEqual = TheString == s.TheString;

            return isEqual;
        }

        public override string ToString()
        {
            return String.Format("The String: {0};", this.TheString);
        }

        public override int GetHashCode()
        {
            return TheString.GetHashCode();
        }

        public static bool operator ==(StringDisperser sd1, StringDisperser sd2)
        {
            return Equals(sd1, sd2);
        }

        public static bool operator !=(StringDisperser sd1, StringDisperser sd2)
        {
            return !Equals(sd1, sd2);
        }

        public object Clone()
        {
            StringDisperser clone = new StringDisperser(this.TheString);

            return clone;
        }

        public int CompareTo(StringDisperser sd)
        {
            return this.TheString.ToString().CompareTo(sd.TheString.ToString());
        }

        public IEnumerator<char> GetEnumerator()
        {
            for (int i = 0; i < this.TheString.Length; i++)
            {
                yield return this.TheString[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
