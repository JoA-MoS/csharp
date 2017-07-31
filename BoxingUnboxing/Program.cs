using System;
using System.Collections.Generic;

namespace BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> objList = new List<object>();
            objList.Add(7);
            objList.Add(28);
            objList.Add(-1);
            objList.Add(true);
            objList.Add("chair");

            int sum=0;
            foreach (object item in objList)
            {
                if(item is int){
                    sum+=(int)item;
                }
                Console.WriteLine(item);
                
            }
            Console.WriteLine(sum);


        }
    }
}
