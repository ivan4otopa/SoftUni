using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringBuilderExtenions.Extrensions
{
    static class Extensions
    {
        public static string Substring(this StringBuilder stringBuilder, int startIndex, int length)
        {
            string newString = "";
            if (stringBuilder.Length >= startIndex + length)
            {
                newString = stringBuilder.ToString().Substring(startIndex, length);
            }
            else
            {
                throw new ArgumentOutOfRangeException("The length of the word you are trying to extract from the string builder exceeds " +
                    "its` length.");
            }
            return newString;
        }

        public static void RemoveText(this StringBuilder stringBuilder, string text)
        {
            int textLength = text.Length;
            text = text.ToLower();
            for (int nextChar = 0; nextChar < stringBuilder.Length - textLength + 1; nextChar++)
            {
                if (stringBuilder.Substring(nextChar, textLength).ToLower() == text)
                {
                    stringBuilder = stringBuilder.Remove(nextChar, textLength);
                }
            }
        }

        public static void AppendAll<T>(this StringBuilder stringBuilder, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                stringBuilder.Append(item.ToString());
            }
        }
    }
}
