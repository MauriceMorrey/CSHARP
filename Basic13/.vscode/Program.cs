using System;
using System.Collections.Generic;

namespace Basic13
{
    class Program
    {
        // Write a program (sets of instructions) that would print all the numbers from 1 to 255.
        public static void Print1To255()
        {
            for (int i = 1; i <= 255; i++)
            {
                System.Console.WriteLine(i);
            }
        }
        // Write a program (sets of instructions) that would print all the odd numbers from 1 to 255.
        public static void PrintOddTo255()
        {
            for (int i = 1; i <= 255; i += 2)
            {
                System.Console.WriteLine(i);
            }
        }
        // Write a program that would print the numbers from 0 to 255 but this time, it would also print the sum of the numbers that have been printed so far
        public static void PrintSum()
        {
            int sum = 0;
            for (int i = 0; i <= 255; i++)
            {
                System.Console.WriteLine("New number: {0} Sum: {1}", i, sum);
                sum += i;
            }
            // Given an array X, say [1,3,5,7,9,13], write a program that would iterate through each member of the array and print each value on the screen. Being able to loop through each member of the array is extremely important.
        }
        public static void ArrayIterate()
        {
            int[] arrayX;
            arrayX = new int[] { 1, 3, 5, 7, 9, 13 };
            for (int i = 0; i < arrayX.Length; i++)
            {
                System.Console.WriteLine(arrayX[i]);
            }
        }
        // Write a program (sets of instructions) that takes any array and prints the maximum value in the array. Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]), or even a mix of positive numbers, negative numbers and zero.
        public static void FindMax()
        {
            int[] arrayZ = { 2, -3, 0, 8, -1 };
            int max = arrayZ[0];
            for (int i = 1; i < arrayZ.Length; i++)
            {
                if (arrayZ[i] > max)
                {
                    max = arrayZ[i];
                }
            }
            System.Console.WriteLine("Max is: {0}", max);
        }
        // Write a program that takes an array, and prints the AVERAGE of the values in the array.
        public static void getAverage()
        {
            int[] arrayW = { 2, 10, 3 };
            int avg = arrayW[0];
            for (int i = 1; i < arrayW.Length; i++)
            {
                avg += arrayW[i];
            }
            System.Console.WriteLine("Average is " + avg / arrayW.Length);
        }
        // Write a program that creates an array 'y' that contains all the odd numbers between 1 to 255.
        public static void OddArray()
        {
            List<int> OddArrayList = new List<int>();
            for (int i = 1; i <= 255; i += 2)
            {
                OddArrayList.Add(i);
            }
            int[] y = new int[OddArrayList.Count];
            // int[] y = OddArrayList.ToArray();            
            foreach (var item in OddArrayList)
            {
                Console.WriteLine(item);
            }
        }
        // Given any array x, say [1, 5, 10, -2], create an algorithm (sets of instructions) that multiplies each value in the array by itself. 
        public static void SquareValues()
        {
            int[] arrayS = { 1, 5, 10, -2 };
            List<int> arraySList = new List<int>();
            for (int i = 0; i < arrayS.Length; i++)
            {
                int temp = arrayS[i] * arrayS[i];
                arraySList.Add(temp);
            }
            int[] x = new int[arraySList.Count];
            foreach (var item in arraySList)
            {
                Console.WriteLine(item);
            }

        }
        //    Given any array x, say [1, 5, 10, -2], create an algorithm that replaces any negative number with the value of 0. 
        public static void EliminateNegativeNumbers()
        {
            int[] arrayT = { 1, 5, 10, -2 };
            List<int> arrayTList = new List<int>();
            for (int i = 0; i < arrayT.Length; i++)
            {
                if (arrayT[i] > 0)
                {
                    arrayTList.Add(arrayT[i]);
                }

            }
            int[] x = new int[arrayTList.Count];
            foreach (var item in arrayTList)
            {
                Console.WriteLine(item);
            }
        }
        // Given any array x, say [1, 5, 10, -2], create an algorithm that prints the maximum number in the array, the minimum value in the array, and the average of the values in the array.
        public static void FindMinMaxAverage()
        {
            int[] arrayQ = { 1, 5, 10, -2 };
            int min = arrayQ[0];
            int max = arrayQ[0];
            int sum = arrayQ[0];
            for (int i = 1; i < arrayQ.Length; i++)
            {
                if (arrayQ[i] < min)
                {
                    min = arrayQ[i];
                }
                if (arrayQ[i] > max)
                {
                    max = arrayQ[i];
                }
                sum += arrayQ[i];
            }
            Console.WriteLine("Min: "+min+"  Max: "+max+"  and Avg: "+sum/arrayQ.Length);
        }
// Given any array x, say [1, 5, 10, 7, -2], create an algorithm that shifts each number by one to the front and adds '0' to the end. For example, when the program is done,  if the array [1, 5, 10, 7, -2] is passed to the function, it should become [5, 10, 7, -2, 0].
        public static void ShiftArray()
        {
            int [] arrayP = {1,5,10,7,-2};
            List<int> arrayPList = new List<int>();            
            for(int i = 0; i < arrayP.Length-1; i++)
            {
                int temp = arrayP[i+1];
                arrayPList.Add(temp);
            }
            arrayPList.Add(0);
            foreach (var item in arrayPList)
            {
                Console.WriteLine(item);
            }
        }
        //Write a program that takes an array of numbers and replaces any negative number with the string 'Dojo'.  
        public static void NumberToString(int[] arr)
        {
            List<string> arrList = new List<string>();
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] < 0)
                {
                    arrList.Add("Dojo");
                }
                else {
                    arrList.Add((arr[i]).ToString());
                }
            }
            int[] x = new int[arrList.Count];
            foreach (var item in arrList)
            {
                Console.WriteLine(item);
            }                          
        }
        //Write a program that takes an array and returns the number of values in that array whose value is greater than a given value y. For example, if array = [1, 3, 5, 7] and y = 3. After your program is run it will print 2 (since there are two values in the array that are greater than 3). 
        public static void GreaterThanY(int[] arr, int y)
        {
            int num = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] > y)
                {
                    num++;
                }
            }
            System.Console.WriteLine("Number of values greater than y is {0}", num);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Print1To255();
            PrintOddTo255();
            PrintSum();
            ArrayIterate();
            FindMax();
            getAverage();
            OddArray();
            SquareValues();
            EliminateNegativeNumbers();
            FindMinMaxAverage();
            ShiftArray();
            int[] arrayO = {-1, -3, 2};
            NumberToString(arrayO);
            int[] arrayN = {1, 3, 5, 7};
            int y = 3;            
            GreaterThanY(arrayN, y);
        }
    }
}
