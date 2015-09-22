using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03PrimesInGivenRange
{
    class PrimesInGivenRange
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter start and end numbers: ");
                Console.Write("Start: ");
                int start = int.Parse(Console.ReadLine());
                Console.Write("End: ");
                int end = int.Parse(Console.ReadLine());
                List<int> primes = FindPrimesInRange(start, end);
                string separate = "";
                foreach (var prime in primes)
                    separate += prime + ", ";
                separate = separate.Remove(separate.Length - 2);
                Console.WriteLine(separate);
            }
            catch (Exception)
            {
                Console.WriteLine("(empty list)");
            }
        }
        public static List<int> FindPrimesInRange(int startNum, int endNum)
        {
            List<int> primeNumbers = new List<int>();
            for (int i = startNum; i <= endNum; i++)
            {
                if (IsPrime(i))
                    primeNumbers.Add(i);
            }
            return primeNumbers;
        }
        public static bool IsPrime(int n)
        {
            int count = 0;
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                    count++;
            }
            if (count == 2)
                return true;
            else
                return false;
        }
    }
}
