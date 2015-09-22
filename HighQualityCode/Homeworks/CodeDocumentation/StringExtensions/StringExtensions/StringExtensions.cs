using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// String extension methods
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Converts string to a MD5 hash value
    /// </summary>
    /// <param name="input">The passed string to convert</param>
    /// <returns>Hashed string</returns>
    public static string ToMd5Hash(this string input)
    {
        var md5Hash = MD5.Create();
        var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        var builder = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            // Adds string in format with precision 2 numbers to our builder
            builder.Append(data[i].ToString("x2"));
        }

        return builder.ToString();
    }

    /// <summary>
    /// Checks if the passed string equals true or false
    /// </summary>
    /// <param name="input">The passed string to check</param>
    /// <returns>Boolean variable</returns>
    public static bool ToBoolean(this string input)
    {
        var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
        return stringTrueValues.Contains(input.ToLower());
    }

    /// <summary>
    /// Converts passed string to a short variable if possible
    /// </summary>
    /// <param name="input">The string to convert</param>
    /// <returns>Short variable</returns>
    public static short ToShort(this string input)
    {
        short shortValue;
        short.TryParse(input, out shortValue);
        return shortValue;
    }

    /// <summary>
    /// Converts passed string to an integer variable if possible
    /// </summary>
    /// <param name="input">The string to convert</param>
    /// <returns>Integer variable</returns>
    public static int ToInteger(this string input)
    {
        int integerValue;
        int.TryParse(input, out integerValue);
        return integerValue;
    }

    /// <summary>
    /// Converts passed string to a long variable if possible
    /// </summary>
    /// <param name="input">The string to convet</param>
    /// <returns>Long variable</returns>
    public static long ToLong(this string input)
    {
        long longValue;
        long.TryParse(input, out longValue);
        return longValue;
    }

    /// <summary>
    /// Converts passed string to a datetime variableif possible
    /// </summary>
    /// <param name="input">The passed string to convert</param>
    /// <returns>DateTime object</returns>
    public static DateTime ToDateTime(this string input)
    {
        DateTime dateTimeValue;
        DateTime.TryParse(input, out dateTimeValue);
        return dateTimeValue;
    }

    /// <summary>
    /// Capitalpizes first letter of string
    /// </summary>
    /// <param name="input">The string to capitalize the first letter of</param>
    /// <returns>The string with a capitalized first letter</returns>
    public static string CapitalizeFirstLetter(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return
            input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) +
            input.Substring(1, input.Length - 1);
    }

    /// <summary>
    /// Gets a string which the passed string should contain
    /// </summary>
    /// <param name="input">The passed string</param>
    /// <param name="startString">The string which holds the position where the search will start</param>
    /// <param name="endString">The string which holds the position where the search will end</param>
    /// <param name="startFrom">The starting position of each string</param>
    /// <returns>The string that the passed string should contain</returns>
    public static string GetStringBetween(
        this string input, string startString, string endString, int startFrom = 0)
    {
        input = input.Substring(startFrom);
        startFrom = 0;
        if (!input.Contains(startString) || !input.Contains(endString))
        {
            return string.Empty;
        }

        var startPosition =
            input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
        if (startPosition == -1)
        {
            return string.Empty;
        }

        var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
        if (endPosition == -1)
        {
            return string.Empty;
        }

        return input.Substring(startPosition, endPosition - startPosition);
    }

    /// <summary>
    /// Converts cyrillic letters to latin letters
    /// </summary>
    /// <param name="input">The string to convert</param>
    /// <returns>Latin letter string</returns>
    public static string ConvertCyrillicToLatinLetters(this string input)
    {
        var bulgarianLetters = new[]
        {
            "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о",
            "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
        };
        var latinRepresentationsOfBulgarianLetters = new[]
        {
            "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
            "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
            "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
        };
        for (var i = 0; i < bulgarianLetters.Length; i++)
        {
            input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
            input = input.Replace(bulgarianLetters[i].ToUpper(),
                latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
        }

        return input;
    }

    /// <summary>
    /// Convert latin letters to cyrillic letters
    /// </summary>
    /// <param name="input">The string to convert</param>
    /// <returns>Cyrillic letter string</returns>
    public static string ConvertLatinToCyrillicKeyboard(this string input)
    {
        var latinLetters = new[]
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
            "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
        };

        var bulgarianRepresentationOfLatinKeyboard = new[]
        {
            "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
            "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
            "в", "ь", "ъ", "з"
        };

        for (int i = 0; i < latinLetters.Length; i++)
        {
            input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
            input = input.Replace(latinLetters[i].ToUpper(),
                bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
        }

        return input;
    }


    /// <summary>
    /// Convert cyrillic letters to latin letters and removes anything that is not letter, number, underscore or dot for input string to make
    /// it a valid username
    /// </summary>
    /// <param name="input">The string to operate on</param>
    /// <returns>Fresh new clean string</returns>
    public static string ToValidUsername(this string input)
    {
        input = input.ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
    }

    /// <summary>
    /// Checks if file name has unwanted whitespce, converts cyrillic letters to latin letters and removes anything that is not letter, 
    /// number, underscore, dot or dash to makw it a valid file name
    /// </summary>
    /// <param name="input">The string to operate on</param>
    /// <returns>Fresh new clean string</returns>
    public static string ToValidLatinFileName(this string input)
    {
        input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
    }

    /// <summary>
    /// Gets first n characters of string
    /// </summary>
    /// <param name="input">The string to get the characters from</param>
    /// <param name="charsCount">The number of characters to extract</param>
    /// <returns>New string</returns>
    public static string GetFirstCharacters(this string input, int charsCount)
    {
        return input.Substring(0, Math.Min(input.Length, charsCount));
    }

    /// <summary>
    /// Gets the file extension if possible
    /// </summary>
    /// <param name="fileName">The string to operate on</param>
    /// <returns>String holding the file extension</returns>
    public static string GetFileExtension(this string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return string.Empty;
        }

        string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
        // if count is 1 there is no more than 1 word in our array thus no .(dot) found and no extension
        if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
        {
            return string.Empty;
        }

        return fileParts.Last().Trim().ToLower();
    }

    /// <summary>
    /// Gets the content of a file name
    /// </summary>
    /// <param name="fileExtension">The string to operate on</param>
    /// <returns>The content of a file extension</returns>
    public static string ToContentType(this string fileExtension)
    {
        var fileExtensionToContentType = new Dictionary<string, string>
        {
            { "jpg", "image/jpeg" },
            { "jpeg", "image/jpeg" },
            { "png", "image/x-png" },
            { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { "doc", "application/msword" },
            { "pdf", "application/pdf" },
            { "txt", "text/plain" },
            { "rtf", "application/rtf" }
        };
        if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
        {
            return fileExtensionToContentType[fileExtension.Trim()];
        }

        return "application/octet-stream";
    }

    /// <summary>
    /// Converts string to a byte array
    /// </summary>
    /// <param name="input">The string to convert</param>
    /// <returns>Byte array</returns>
    public static byte[] ToByteArray(this string input)
    {
        var bytesArray = new byte[input.Length * sizeof(char)];
        Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
        return bytesArray;
    }
}
