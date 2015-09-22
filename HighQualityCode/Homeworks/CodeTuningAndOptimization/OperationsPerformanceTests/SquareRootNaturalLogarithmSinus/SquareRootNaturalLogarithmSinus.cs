using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRootNaturalLogarithmSinus
{
    class SquareRootNaturalLogarithmSinus
    {
        static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Float operations: ");

            FloatOperations();

            Console.WriteLine("\nDouble operations: ");

            DoubleOperations();

            Console.WriteLine("\nDecimal operations: ");

            DecimalOperations();
        }

        public static void FloatOperations()
        {
            float a = 15.5f;

            Console.Write("Square root of float: ");
            DisplayExecutionTime(() =>
            {
                Math.Sqrt(a);
            });

            Console.Write("Natural logarithm of float: ");
            DisplayExecutionTime(() =>
            {
                Math.Log(a);
            });

            Console.Write("Sinus of float: ");
            DisplayExecutionTime(() =>
            {
                Math.Sin(a);
            });
        }

        public static void DoubleOperations()
        {
            double a = 15.5242335132523;

            Console.Write("Square root of double: ");
            DisplayExecutionTime(() =>
            {
                Math.Sqrt(a);
            });

            Console.Write("Natural logarithm of double: ");
            DisplayExecutionTime(() =>
            {
                Math.Log(a);
            });

            Console.Write("Sinus of double: ");
            DisplayExecutionTime(() =>
            {
                Math.Sin(a);
            });
        }

        public static void DecimalOperations()
        {
            decimal a = 15.52423351325232372385m;
            decimal b;

            Console.Write("Square root of decimal: ");
            DisplayExecutionTime(() =>
            {
               b = (decimal)Math.Sqrt((double)a);
            });

            Console.Write("Natural logarithm of decimal: ");
            DisplayExecutionTime(() =>
            {
                b = (decimal)Math.Log((double)a);
            });

            Console.Write("Sinus of decimal: ");
            DisplayExecutionTime(() =>
            {
                b = (decimal)Math.Sin((double)a);
            });
        }
    }
}
