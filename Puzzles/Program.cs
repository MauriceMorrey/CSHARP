using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        public static void RandomArray()
        {
            // List<int> RandomArrayList = new List<int>();
            // Random rand = new Random();
            // for(int i = 0; i < 10; i++)
            // {
            //     RandomArrayList.Add(rand.Next(5,26));
            // }
            // // int[] y = new int[RandomArrayList.Count];            
            // foreach(int item in RandomArrayList){
            //     Console.WriteLine(item);
            // }
            // Create a function called RandomArray() that returns an integer array
            // Place 10 random integer values between 5-25 into the array
            int[] ArrayR = new int[10];
            Random rand = new Random();
            for (int i = 0; i < ArrayR.Length; i++)
            {
                ArrayR[i] = rand.Next(5, 26);
            }
            foreach (int item in ArrayR)
            {
                System.Console.WriteLine(item);
            }
            // Print the min and max values of the array
            // Print the sum of all the values
            int min = ArrayR[0];
            int max = ArrayR[0];
            int sum = ArrayR[0];
            for (int i = 1; i < ArrayR.Length; i++)
            {
                if (ArrayR[i] < min)
                {
                    min = ArrayR[i];
                }
                if (ArrayR[i] > max)
                {
                    max = ArrayR[i];
                }
                sum += ArrayR[i];
            }
            Console.WriteLine("Min: {0}  Max: {1}  and Sum: {2}", min, max, sum);
        }
        // Create a function called TossCoin() that returns a string
        // Have the function print "Tossing a Coin!"
        // Randomize a coin toss with a result signaling either side of the coin 
        // Have the function print either "Heads" or "Tails"
        // Finally, return the result
        public static string TossCoin()
        {
            System.Console.WriteLine("Tossing a Coin");
            Random rand = new Random();
            string result = "heads";
            if(rand.Next(0,2) == 1)
            {
                result = "tails";
            }
            System.Console.WriteLine("Coin toss result is: {0} ", result);
            return result;
        }
            // Create another function called TossMultipleCoins(int num) that returns a Double
            // Have the function call the tossCoin function multiple times based on num value
            // Have the function return a Double that reflects the ratio of head toss to total toss
        public static void TossMultipleCoins(int num)
        {
            System.Console.WriteLine("Tossing");
            Random rand = new Random();
            double headcount = 0;
            double tailcount = 0;
            double ratiocount = 0;
            for(int i = 0; i < num; i++)
            {
                int randomCount = rand.Next(1,1001);
                if(rand.Next(0,3) == 1)
                {
                    tailcount++;
                }
                else{
                    headcount++;
                }
                ratiocount = Math.Round((headcount/tailcount)*100,2);
                System.Console.WriteLine("Coin toss result is: {0} tails and {1} heads",tailcount,headcount);                
                System.Console.WriteLine("Number of tosses is: {0} ratio of heads to tails is: {1} ",num,ratiocount);
                // return TossMultipleCoins;
            }
        }
            // Build a function Names that returns an array of strings
            // Create an array with the values: Todd, Tiffany, Charlie, Geneva, Sydney
            // Shuffle the array and print the values in the new order
            // Return an array that only includes names longer than 5 characters
        public static void Names()
        {
            string[] names = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            Random rand = new Random();
            string NewString; //NewString = null, NewString = System.String.Empty  ...creating an empty string
            for (int i = 0; i < names.Length; ++i)
            {
                int RandomNames = rand.Next(i,names.Length);
                NewString = names[i];
                names[i] = names[RandomNames];
                names[RandomNames] = NewString;
                Console.WriteLine("Index {0} has {1}", i, names[i]);
            }
            int[] NamesArray = new int[names.Length];
            for(int i=0; i>names.Length; i++)
            {
                if(names[i].Length>5)
                {
                    NamesArray[i] = System.Convert.ToInt32(names[i]);
                }
            }
            foreach(var item in NamesArray)
            {
                System.Console.WriteLine(item);
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RandomArray();
            TossCoin();
            int y = 8;
            TossMultipleCoins(y);
            Names();
        }
    }
}
