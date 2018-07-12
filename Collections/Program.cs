using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Create an array to hold integer values 0 through 9
            int[] numArray1 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine(numArray1[1]);
            // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            string[] arr2 ={
                "Tim",
                "Martin",
                "Nikki",
                "Sara"
            };
            Console.WriteLine(arr2[0]);
            // Create an array of length 10 that alternates between true and false values, starting with true
            bool[] arr3 = new bool[10];
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    arr3[i] = true;
                }
                else
                {
                    arr3[i] = false;
                }
                Console.WriteLine(arr3[i]);
            }
            // Multiplication table
            int [,] ArrayMult = new int[10,10];
            for(int i=0; i<10; i++){
                for(int j=0; j<10; j++){
                    ArrayMult[i,j] = (i+1)*(j+1);
                    // Console.Write(ArrayMult[i,j]);
                    Console.Write(string.Format("{0} ", ArrayMult[i,j]));
                }
                 Console.WriteLine(Environment.NewLine);
            }
            // Create a list of Ice Cream flavors that holds at least 5 different flavors (feel free to add more than 5!)
            List<string> IceCreamFlavors = new List<string>();
            IceCreamFlavors.Add("Vanilla");
            IceCreamFlavors.Add("Chocolate");
            IceCreamFlavors.Add("Stawberry");
            IceCreamFlavors.Add("Peanut Butter");
            IceCreamFlavors.Add("Banana");
            IceCreamFlavors.Add("Mango");                                                            
            // Output the length of this list after building it
            Console.WriteLine("We currently know of {0} Ice cream flavors.", IceCreamFlavors.Count);
            // Output the third flavor in the list, then remove this value.
            Console.WriteLine(IceCreamFlavors[2]);
            IceCreamFlavors.RemoveAt(2);
            // Output the new length of the list (Note it should just be one less~)
            Console.WriteLine("We currently know of {0} Ice cream flavors.", IceCreamFlavors.Count);
            
            // Create a Dictionary that will store both string keys as well as string values
            Dictionary<string,string> profile = new Dictionary<string,string>();
            // For each name in the array of names you made previously, add it as a new key in this dictionary with value null
            foreach (string entry in arr2){
                profile.Add(entry, null);
                Console.WriteLine(entry);
            }
            // For each name key, select a random flavor from the flavor list above and store it as the value
            Random rand = new Random();
            List<string> keys = new List<string>(profile.Keys);
            for (int i = 0; i < keys.Count; i++){
                profile[keys[i]] = IceCreamFlavors[rand.Next(0,4)];
                Console.WriteLine(keys[i] + "-" + IceCreamFlavors[i]);
            }
            // Loop through the Dictionary and print out each user's name and their associated ice cream flavor.
            foreach (var entry in profile){
                Console.WriteLine(entry.Key + " - " + entry.Value);}                     
            
            // int[] numArray = new int[10];
            // for (int i = 0; i < 10; ++i){
            //                 numArray[i] = i;
            // Declaring an array with pre-populated values
            // For Arrays initialized this way, the length is determined by the size of the given data
            // int[] numArray2 = {1,2,3,4,6};
            // Console.WriteLine(i);
            // }
        }
    }
}
