using System;
using System.Collections.Generic;

namespace CollectionPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArr = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine(arrayToString<int>(intArr));
            string[] strArr = new string[] { "Tim", "Martin", "Nikki", "Sara" };
            Console.WriteLine(arrayToString<string>(strArr));
            bool[] blnArr = new bool[10];
            for (int i = 1; i <= 10; i++)
            {
                blnArr[i-1]= (i%2)!=0;
            }
            Console.WriteLine(arrayToString<bool>(blnArr));
            int[][] multiArr = new int[10][];
            for (int i = 1; i <= 10; i++)
            {
                multiArr[i-1] = new int[10];
                for (int j = 1; j <= 10; j++)
                {
                    multiArr[i-1][j-1] = i*j;
                }
                Console.WriteLine(arrayToString<int>(multiArr[i-1]));
            }

            List<string> flavors = new List<string>();
            flavors.Add("Chocolate");
            flavors.Add("Vanila");
            flavors.Add("Strawberry");
            flavors.Add("Rocky Road");
            flavors.Add("Mint Chip");
            Console.WriteLine(flavors.Count);
            Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);
            Console.WriteLine(flavors.Count);

            Dictionary<string,string> userDict = new Dictionary<string, string>();
            // I know you can do this in linq but would have to look it up
            foreach (string item in strArr)
            {
                userDict.Add(item,null);
            }

            Random rand = new Random();

            foreach (string item in strArr)
            {
                userDict[item]=flavors[rand.Next(0,5)];
            }

            foreach (KeyValuePair<string, string> item in userDict)
            {
               Console.WriteLine("{0}: {1}",item.Key,item.Value);
            }


        }

        static string arrayToString<T>(T[] arr)
        {
            return "[" + string.Join(", ", arr) + "]";
        }
    }


}
