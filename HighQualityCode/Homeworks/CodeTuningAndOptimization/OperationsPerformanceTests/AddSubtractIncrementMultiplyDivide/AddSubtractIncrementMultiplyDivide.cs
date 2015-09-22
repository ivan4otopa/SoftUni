using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddSubtractIncrementMultiplyDivide
{
    class AddSubtractIncrementMultiplyDivide
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
            Console.WriteLine("Int operations:");

            IntOperations();

            Console.WriteLine("\nLong operations:");

            LongOperations();

            Console.WriteLine("\nFloat operations:");

            FloatOperations();

            Console.WriteLine("\nDouble operations:");

            DoubleOperations();

            Console.WriteLine("\nDecimal operations:");

            DecimalOperations();
        }

        public static void IntOperations()
        {
            int a = 534567;
            int b = 107895;
            int c;

            Console.Write("Adding ints: ");
            DisplayExecutionTime(() =>
            {
                c = a + b;
            });

            Console.Write("Subtracting ints: ");
            DisplayExecutionTime(() =>
            {
                c = a - b;
            });

            Console.Write("Incrementing ints: ");
            DisplayExecutionTime(() =>
            {
                a++;
            });

            Console.Write("Multiplying ints: ");
            DisplayExecutionTime(() =>
            {
                c = a * b;
            });

            Console.Write("Dividing ints: ");
            DisplayExecutionTime(() =>
            {
                c = a / b;
            });
        }

        public static void LongOperations()
        {
            long a = 12345678;
            long b = 10345768;
            long c;

            Console.Write("Adding longs: ");
            DisplayExecutionTime(() =>
            {
                c = a + b;
            });

            Console.Write("Subtracting longs: ");
            DisplayExecutionTime(() =>
            {
                c = a - b;
            });

            Console.Write("Incrementing longs: ");
            DisplayExecutionTime(() =>
            {
                a++;
            });

            Console.Write("Multiplying longs: ");
            DisplayExecutionTime(() =>
            {
                c = a * b;
            });

            Console.Write("Dividing longs: ");
            DisplayExecutionTime(() =>
            {
                c = a / b;
            });
        }

        public static void FloatOperations()
        {
            float a = 5.5f;
            float b = 10.10f;
            float c;

            Console.Write("Adding floats: ");
            DisplayExecutionTime(() =>
            {
                c = a + b;
            });

            Console.Write("Subtracting floats: ");
            DisplayExecutionTime(() =>
            {
                c = a - b;
            });

            Console.Write("Incrementing floats: ");
            DisplayExecutionTime(() =>
            {
                a++;
            });

            Console.Write("Multiplying floats: ");
            DisplayExecutionTime(() =>
            {
                c = a * b;
            });

            Console.Write("Dividing floats: ");
            DisplayExecutionTime(() =>
            {
                c = a / b;
            });
        }

        public static void DoubleOperations()
        {
            double a = 5.54534567235;
            double b = 10.10345984751;
            double c;

            Console.Write("Adding doubles: ");
            DisplayExecutionTime(() =>
            {
                c = a + b;
            });

            Console.Write("Subtracting doubles: ");
            DisplayExecutionTime(() =>
            {
                c = a - b;
            });

            Console.Write("Incrementing doubles: ");
            DisplayExecutionTime(() =>
            {
                a++;
            });

            Console.Write("Multiplying doubles: ");
            DisplayExecutionTime(() =>
            {
                c = a * b;
            });

            Console.Write("Dividing doubles: ");
            DisplayExecutionTime(() =>
            {
                c = a / b;
            });
        }

        public static void DecimalOperations()
        {
            decimal a = 5.2222233333334444421231223m;
            decimal b = 10.78951142313413423485785875m;
            decimal c;

            Console.Write("Adding decimals: ");
            DisplayExecutionTime(() =>
            {
                c = a + b;
            });

            Console.Write("Subtracting decimals: ");
            DisplayExecutionTime(() =>
            {
                c = a - b;
            });

            Console.Write("Incrementing decimals: ");
            DisplayExecutionTime(() =>
            {
                a++;
            });

            Console.Write("Multiplying decimals: ");
            DisplayExecutionTime(() =>
            {
                c = a * b;
            });

            Console.Write("Dividing decimals: ");
            DisplayExecutionTime(() =>
            {
                c = a / b;
            });
        }
    }
}
