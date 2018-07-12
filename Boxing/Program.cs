using System;
using System.Collections.Generic;

namespace Boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<object> box2 = new List<object>();
            {
                box2.Add(7);
                box2.Add(28);
                box2.Add(-1);
                box2.Add(true);
                box2.Add("chair");
            }
            int sum = 0;
            foreach (object item in box2)
            {
                System.Console.WriteLine(item);
                if (item is int)
                {
                    sum += (int)item;
                }
            }
            System.Console.WriteLine(sum);
        }
    }
}
