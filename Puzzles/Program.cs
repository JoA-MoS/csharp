using System;
using System.Linq;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] randArr;
            randArr = RandomArray(25);
            Console.WriteLine(string.Join(", ", randArr));
            Console.WriteLine(randArr.Min());
            Console.WriteLine(randArr.Max());
            Console.WriteLine(randArr.Sum());

            Console.WriteLine("==================Coin Tossing=================");
            Console.WriteLine(TossMultipleCoins(50));


             Console.WriteLine("==================Names=================");
             string[] names = Names();
             Console.WriteLine(string.Join(", ", names));
             names = ShuffleArray(names);
             Console.WriteLine(string.Join(", ", names));
             Console.WriteLine(string.Join(", ", names.Where(x=>x.Length>5)));
        }

        static int[] RandomArray(int length)
        {
            Random rand = new Random();
            int[] arr = new int[length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(5, 26);
            }
            return arr;
        }

        static int TossCoin(Random rand)
        {

            Console.WriteLine("Tossing a Coin!");
            string[] toss = { "Tails", "Heads" };
            int result = rand.Next(2);
            Console.WriteLine(toss[result]);
            return result;
        }

        static double TossMultipleCoins(int num)
        {
            Random rand = new Random();
            int[] results = new int[2];
            for (int i = 0; i < num; i++)
            {
                results[TossCoin(rand)]++;
            }
            return results[1] / (double)results.Sum();
        }

        static string[] Names()
        {
            return new string[] {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};

        }

        static string[] ShuffleArray(string[] arr)
        {
            Random rand = new Random();
            return arr.OrderBy(x=>rand.Next()).ToArray();

        }
    }
}
