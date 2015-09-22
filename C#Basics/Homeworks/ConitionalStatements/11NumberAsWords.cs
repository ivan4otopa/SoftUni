using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11NumberAsWords
{
    class NumberAsWords
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number from 0 to 999: ");
            int numbers = int.Parse(Console.ReadLine());
            string s = "";
            string s1 = "";
            string s2 = "";
            string s3 = "";
            if (numbers / 100 != 0)
            {
                int a = numbers / 100;
                switch (a)
                {
                    case 1:
                        s = "A hundred";
                        break;
                    case 2:
                        s = "Two hundred";
                        break;
                    case 3:
                        s = "Three hundred";
                        break;
                    case 4:
                        s = "Four hundred";
                        break;
                    case 5:
                        s = "Five hundred";
                        break;
                    case 6:
                        s = "Six hundred";
                        break;
                    case 7:
                        s = "Seven hundred";
                        break;
                    case 8:
                        s = "Eight hundred";
                        break;
                    case 9:
                        s = "Nine hundred";
                        break;
                }
            }
            if (numbers / 100 != 0 && (numbers / 10 != 0) || (numbers / 100 == 0 && (numbers / 10 != 0)))
            {
                int a = (numbers % 100) / 10;
                int b = (numbers % 100) % 10;
                if (a == 1)
                {
                    switch (b)
                    {
                        case 0:
                            s1 = "Ten";
                            break;
                        case 1:
                            s1 = "Eleven";
                            break;
                        case 2:
                            s1 = "Twelve";
                            break;
                        case 3:
                            s1 = "Thirteen";
                            break;
                        case 4:
                            s1 = "Fourteen";
                            break;
                        case 5:
                            s1 = "Fifteen";
                            break;
                        case 6:
                            s1 = "Sixteen";
                            break;
                        case 7:
                            s1 = "Seventeen";
                            break;
                        case 8:
                            s1 = "Eighteen";
                            break;
                        case 9:
                            s1 = "Nineteen";
                            break;
                    }
                }
                else
                    switch (a)
                    {
                        case 2:
                            s2 = "Twenty";
                            break;
                        case 3:
                            s2 = "Thirty";
                            break;
                        case 4:
                            s2 = "Forty";
                            break;
                        case 5:
                            s2 = "Fifty";
                            break;
                        case 6:
                            s2 = "Sixty";
                            break;
                        case 7:
                            s2 = "Seventy";
                            break;
                        case 8:
                            s2 = "Eighty";
                            break;
                        case 9:
                            s2 = "Ninety";
                            break;
                    }
                }
            if(numbers % 10 > 0)
            {
                int a = numbers % 10;
                switch(a)
                {
                    case 1:
                        s3 = "One";
                        break;
                    case 2:
                        s3 = "Two";
                        break;
                    case 3:
                        s3 = "Three";
                        break;
                    case 4:
                        s3 = "Four";
                        break;
                    case 5:
                        s3 = "Five";
                        break;
                    case 6:
                        s3 = "Six";
                        break;
                    case 7:
                        s3 = "Seven";
                        break;
                    case 8:
                        s3 = "Eight";
                        break;
                    case 9:
                        s3 = "Nine";
                        break;
                }
            }
            if (numbers / 100 != 0 && (numbers % 100) / 10 == 0 && numbers % 10 == 0)
                Console.WriteLine(s);
            if (numbers / 100 != 0 && (numbers % 100) / 10 != 0 && numbers % 10 == 0)
            {
                if ((numbers % 100) / 10 == 1)
                    Console.WriteLine(s + " and " + s1.ToLower());
                else
                    Console.WriteLine(s + " and " + s2);
            }
            if (numbers / 100 != 0 && (numbers % 100) / 10 != 0 && numbers % 10 != 0)
            {
                if ((numbers % 100) / 10 > 1)
                    Console.WriteLine(s + " and " + s2.ToLower() + " " + s3.ToLower());
                else if ((numbers % 100) / 10 == 1)
                    Console.WriteLine(s + " and " + s1.ToLower());
            }
            if (numbers / 100 != 0 && (numbers % 100) / 10 == 0 && numbers % 10 != 0)
                Console.WriteLine(s + " and " + s3.ToLower());
            if (numbers / 100 == 0 && numbers / 10 != 0 && numbers % 10 == 0)
            {
                if (numbers / 10 == 1)
                    Console.WriteLine(s1);
                else
                    Console.WriteLine(s2);
            }
            if (numbers / 100 == 0 && numbers / 10 != 0 && numbers % 10 != 0)
            {
                if (numbers / 10 == 1)
                    Console.WriteLine(s1);
                else if(numbers / 10 > 1)
                    Console.WriteLine(s2 + " " + s3.ToLower());
            }
            if (numbers / 100 == 0 && numbers / 10 == 0 && numbers % 10 != 0)
                Console.WriteLine(s3);
            if (numbers == 0)
                Console.WriteLine("Zero");
        }
    } 
}
