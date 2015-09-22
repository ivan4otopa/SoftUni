using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04PrintADeckOf52Cards
{
    class PrintDeckOf52Cards
    {
        static void Main()
        {
            int a = 3;
            int b = 4;
            int c = 5;
            int d = 6;
            for (int i = 2; i < 15; i++)
            {
                if (i > 1 && i < 11)
                {
                    Console.WriteLine(" " + ((char)c) + i + " " + ((char)b) + i + " " + ((char)a) + i + " " + ((char)d) + i);
                }
                else
                {
                    for (int j = i; j < i + 1; j++)
                        switch (i)
                        {
                            case 11:
                                Console.WriteLine((char)c + "J " + (char)b + "J " + (char)a + "J " + (char)d + "J ");
                                break;
                            case 12: 
                                Console.WriteLine((char)c + "Q " + (char)b + "Q " + (char)a + "Q " + (char)d + "Q ");
                                break;
                            case 13: 
                                Console.WriteLine((char)c + "K " + (char)b + "K " + (char)a + "K " + (char)d + "K ");
                                break;
                            case 14:
                                Console.WriteLine((char)c + "A " + (char)b + "A " + (char)a + "A " + (char)d + "A ");
                                break;
                        }
                }
            }
        }
    }
}