using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSortSelectionSortQuicksort
{
    class InsertionSortSelectionSortQuicksort
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
            Console.WriteLine("Int operations: ");

            IntOperations();

            Console.WriteLine("\nDouble operations: ");

            DoubleOperations();

            Console.WriteLine("\nString operations: ");

            StringOperations();
        }

        public static void IntOperations()
        {
            int[] a = new int[] { 5, 1, 9, 4, 2, 8, 3, 7, 6 };

            Console.Write("Insertion sort for int: ");
            DisplayExecutionTime(() =>
            {
                InsSort(a);
            });

            Console.Write("Selection sort for int: ");
            DisplayExecutionTime(() =>
            {
                sortArray(a);
            });

            Console.Write("Quicksort for int: ");
            DisplayExecutionTime(() =>
            {
                Quicksort(a, 0, a.Length - 1);
            });
        }

        public static void DoubleOperations()
        {
            double[] a = new double[] { 5.14235, 1.134124, 9.578457, 4.24634, 2.23453452, 8.16666666346, 3.35987634, 7.6246334, 6.64236345 };

            Console.Write("Insertion sort for double: ");
            DisplayExecutionTime(() =>
            {
                InsSort(a);
            });

            Console.Write("Selection sort for double: ");
            DisplayExecutionTime(() =>
            {
                sortArray(a);
            });

            Console.Write("Quicksort for double: ");
            DisplayExecutionTime(() =>
            {
                Quicksort(a, 0, a.Length - 1);
            });
        }

        public static void StringOperations()
        {
            string[] a = new string[] { "ab", "ba", "ac", "cac", "bc", "cba", "dca", "dc", "cd" };

            Console.Write("Insertion sort for string: ");
            DisplayExecutionTime(() =>
            {
                InsSort(a);
            });

            Console.Write("Selection sort for string: ");
            DisplayExecutionTime(() =>
            {
                sortArray(a);
            });

            Console.Write("Quicksort for string: ");
            DisplayExecutionTime(() =>
            {
                Quicksort(a, 0, a.Length - 1);
            });
        }

        static int[] InsSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int value = arr[i];
                int index = i;
                while (index > 0 && arr[index - 1] >= value)
                {
                    arr[index] = arr[index - 1];
                    index--;
                }
                arr[index] = value;
            }
            return arr;
        }

        public static void sortArray(int[] intArray)
        {
            int min, temp;

            for (int i = 0; i < intArray.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < intArray.Length; j++)
                    if (intArray[j] < intArray[min])
                        min = j;

                // swap the values
                temp = intArray[i];
                intArray[i] = intArray[min];
                intArray[min] = temp;
            }
        }

        public static void Quicksort(int[] elements, int left, int right)
        {
            int i = left, j = right;
            int pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    int tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort(elements, left, j);
            }

            if (i < right)
            {
                Quicksort(elements, i, right);
            }
        }

        static double[] InsSort(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                double value = arr[i];
                int index = i;
                while (index > 0 && arr[index - 1] >= value)
                {
                    arr[index] = arr[index - 1];
                    index--;
                }
                arr[index] = value;
            }
            return arr;
        }

        public static void sortArray(double[] intArray)
        {
            int min;
            double temp;

            for (int i = 0; i < intArray.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < intArray.Length; j++)
                    if (intArray[j] < intArray[min])
                        min = j;

                // swap the values
                temp = intArray[i];
                intArray[i] = intArray[min];
                intArray[min] = temp;
            }
        }

        public static void Quicksort(double[] elements, int left, int right)
        {
            int i = left, j = right;
            double pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    double tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort(elements, left, j);
            }

            if (i < right)
            {
                Quicksort(elements, i, right);
            }
        }

        static string[] InsSort(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                string value = arr[i];
                int index = i;
                while (index > 0 && arr[index - 1].CompareTo(value) >= 0)
                {
                    arr[index] = arr[index - 1];
                    index--;
                }
                arr[index] = value;
            }
            return arr;
        }

        public static void sortArray(string[] intArray)
        {
            int min;
            string temp;

            for (int i = 0; i < intArray.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < intArray.Length; j++)
                    if (intArray[j].CompareTo(intArray[min]) == -1)
                        min = j;

                // swap the values
                temp = intArray[i];
                intArray[i] = intArray[min];
                intArray[min] = temp;
            }
        }

        public static void Quicksort(string[] elements, int left, int right)
        {
            int i = left, j = right;
            string pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    string tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort(elements, left, j);
            }

            if (i < right)
            {
                Quicksort(elements, i, right);
            }
        }
    }
}
