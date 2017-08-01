using System;
using System.Collections.Generic;
using System.Linq;

namespace basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======================Print 1-255========================");
            for (int i = 0; i < 256; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("======================Print Odds 1-255========================");
            for (int i = 1; i < 256; i += 2)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("======================Print sum 0-255========================");
            int sum = 0;
            for (int i = 0; i < 256; i++)
            {
                Console.WriteLine($"New number: {i} Sum: {sum}");
                sum += i;
            }

            Console.WriteLine("======================Iterate Through Array========================");
            int[] x = { 1, 3, 5, 7, 9, 13 };
            foreach (int item in x)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("======================Get Max Val========================");
            Console.WriteLine(GetMax(x));
            int[] y = { -3, -5, -7 };
            Console.WriteLine(GetMax(y));

            Console.WriteLine("======================Get Average Val========================");
            Console.WriteLine(GetAverage(x));
            Console.WriteLine(GetAverage(y));
            int[] z = new int[] { 2, 10, 3 };
            Console.WriteLine(GetAverage(z));

            Console.WriteLine("======================'Array' of Odds 1-255========================");
            List<int> odds = new List<int>();
            for (int i = 1; i < 256; i += 2)
            {
                odds.Add(i);
            }
            Console.WriteLine(string.Join(", ", odds));
            
            Console.WriteLine("======================Count Greater Than========================");
            int[] gt = new int[] { 1, 3, 5, 7 };
            int val = 2;
            Console.WriteLine(gt.Where(g => g > val).Count());

            Console.WriteLine("======================Square the array========================");
            x = x.Select(i => i * i).ToArray();
            Console.WriteLine(string.Join(", ", x));


            Console.WriteLine("======================Eliminate Negative in the array========================");
            int[] noNeg = { 1, -3, 4, -9, 2, 4 };
            noNeg = Array.FindAll(noNeg, p => p >= 0);
            Console.WriteLine(string.Join(", ", noNeg));

            Console.WriteLine("======================Negative to Dojo in the array========================");
            object[] noNeg2 = { 1, -3, 4, -9, 2, 4 };
            noNeg2 = noNeg2.Select(i => (int)i < 0 ? "dojo" : i).ToArray();        
            Console.WriteLine(string.Join(", ", noNeg2));
        }

        static object[] ArrMap(object[] arr, Func<object, object[]> cb)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = cb(arr[i]);
            }
            return arr;
        }
        static int GetMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                }
            }
            return max;
        }

        static int GetSum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        static float GetAverage(int[] arr)
        {
            return GetSum(arr) / ((float)arr.Length);
        }
    }
}
