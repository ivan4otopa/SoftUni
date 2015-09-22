using System;

namespace Methods
{
    class Methods
    {
        static double CalculateTriangleArea(double sideOne, double sideTwo, double sideThree)
        {
            if (sideOne <= 0 || sideTwo <= 0 || sideThree <= 0)
            {
                throw new ArgumentOutOfRangeException("Triangle sides cannot be negative or 0.");
            }

            double halfPerimeter = (sideOne + sideTwo + sideThree) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - sideOne) * (halfPerimeter - sideTwo) * (halfPerimeter - sideThree));

            return area;
        }

        static string NumberToDigit(int number)
        {
            if (number < 0 || number > 10)
            {
                throw new ArgumentOutOfRangeException("Number must be in the range [0...10).");
            }

            switch (number)
            {
                case 0: 
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
            }

            return "Invalid number.";
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("No parameters passed.");
            }

            int maxElement = int.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        static void PrintNumberInFormat(object number, string format)
        {
            if (format != "f" && format != "%" && format != "r")
            {
                throw new ArgumentException("Invalid format.");
            }

            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }

            if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }

            if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
        }


        static double CalculateDistance(double x1, double y1, double x2, double y2, out bool isHorizontal, out bool isVertical)
        {
            if (x1 != x2 && y1 != y2)
            {
                isHorizontal = false;
                isVertical = false;
            }

            else
            {
                isHorizontal = (y1 == y2);
                isVertical = (x1 == x2);
            }

            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigit(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintNumberInFormat(1.3, "f");
            PrintNumberInFormat(0.75, "%");
            PrintNumberInFormat(2.30, "r");

            bool horizontal, vertical;
            Console.WriteLine(CalculateDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
