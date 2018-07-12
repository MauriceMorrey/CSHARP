using System;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        // {
        //     Console.WriteLine("Hello World!");
        // }
        {
            // int i = 1;
            // while (i < 256)
            // {
            //     Console.WriteLine(i);
            //     i++;
            // }
            for (int j = 1; j <= 100; ++j)
            {
                if (j % 3 == 0 ^ j % 5 == 0)
                {
                    Console.Write(j.ToString() + "\n");
                }
            }
            for (int i = 1; i <= 100; ++i)
            {
                if (i % 3 == 0 && i % 5 != 0)
                {
                    Console.Write(i.ToString() + " Fizz\n");
                }
                if (i % 3 != 0 && i % 5 == 0)
                {
                    Console.Write(i.ToString() + " Buzz\n");
                }
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.Write(i.ToString() + " FizzBuzz\n");
                }
            }
            Random rand = new Random();
            for (int i = 0; i < 10; ++i)
            {
                Console.Write(rand.Next() + " " + rand.Next() + "\n");
            }
        }
    }
}
