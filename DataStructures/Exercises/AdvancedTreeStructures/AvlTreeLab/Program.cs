using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTreeLab
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new AvlTree<int>();
            var random = new Random();

            for (int i = 0; i < 20; i++)
            {
                var num = random.Next(0, 1000);

                tree.Add(num);
            }

            tree.ForeachDfs((depth, num) =>
            {
                Console.WriteLine(num);
            });
        }
    }
}
