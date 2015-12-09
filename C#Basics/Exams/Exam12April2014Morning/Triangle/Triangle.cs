namespace Triangle
{
    using System;

    class Triangle
    {
        static void Main()
        {
            int aX = int.Parse(Console.ReadLine());
            int aY = int.Parse(Console.ReadLine());
            int bX = int.Parse(Console.ReadLine());
            int bY = int.Parse(Console.ReadLine());
            int cX = int.Parse(Console.ReadLine());
            int cY = int.Parse(Console.ReadLine());
            double distanceAB = Math.Sqrt(Math.Pow(bX - aX, 2) + Math.Pow(bY - aY, 2));
            double distanceBC = Math.Sqrt(Math.Pow(cX - bX, 2) + Math.Pow(cY - bY, 2));
            double distanceCA = Math.Sqrt(Math.Pow(aX - cX, 2) + Math.Pow(aY - cY, 2));

            if (distanceAB + distanceBC > distanceCA &&
                distanceBC + distanceCA > distanceAB &&
                distanceAB + distanceCA > distanceBC)
            {
                double halfPerimeter = (distanceAB + distanceBC + distanceCA) / 2;
                double area = Math.Sqrt(
                    halfPerimeter *
                    (halfPerimeter - distanceAB) *
                    (halfPerimeter - distanceBC) *
                    (halfPerimeter - distanceCA));

                Console.WriteLine("Yes\n{0:0.00}", area);
            }
            else
            {
                Console.WriteLine("No\n{0:0.00}", distanceAB);
            }
        }
    }
}
