﻿using System;

namespace Lab01NumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my game! Let's do some math!");

            try
            {
                StartSequence();
            }
            catch (Exception ge)
            {
                Console.WriteLine("It looks like you have run into an issue: " + ge.Message);
            }
            finally
            {
                Console.WriteLine("Program is complete.");
                Console.ReadKey();
            }
        }

        static void StartSequence()
        {
            Console.WriteLine("Enter a number greater than zero");
            string givenString = Console.ReadLine();
            int givenNumber = Convert.ToInt32(givenString);

            int[] userArray = new int[givenNumber];

            try
            {
                int[] array = Populate(userArray);
                int sum = GetSum(userArray);
                int product = GetProduct(userArray, sum);
                decimal quotient = GetQuotient(product);

                Console.WriteLine($"Your array is size: {givenNumber}");
                Console.WriteLine($"The numbers in the array are {String.Join(", ", array)}");
                Console.WriteLine($"The sum of the array is {sum}");
                Console.WriteLine($"{sum} * {product/sum} = {product}");
                Console.WriteLine($"{product} / {product/quotient} = {quotient}");

            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
        }

        static int[] Populate(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Please enter a number: {i + 1} of {array.Length}");
                string popString = Console.ReadLine();
                int popNumber = Convert.ToInt32(popString);
                array[i] = popNumber;
            }

            return array;
        }

        static int GetSum(int[] array)
        {
            int sum = 0;

            foreach (int number in array)
            {
                sum += number;
            }

            if (sum < 20)
            {
                throw (new Exception($"Value of {sum} is too low."));
            }

            return sum;
        }

        static int GetProduct(int[] array, int sum)
        {
            Console.WriteLine($"Please select a random number between 1 and {array.Length}");
            string indexString = Console.ReadLine();
            int indexNumber = Convert.ToInt32(indexString);

            try
            {
                int product = sum * array[indexNumber - 1];
                return product;
            }
            catch(IndexOutOfRangeException ie)
            {
                Console.WriteLine(ie.Message);
                throw;
            }
        }

        static decimal GetQuotient(int product)
        {
            Console.WriteLine($"Please enter a number to divide your product {product} by");
            string divString = Console.ReadLine();
            int divNumber = Convert.ToInt32(divString);

            try
            {
                decimal quotient = decimal.Divide(product, divNumber);
                int result = Convert.ToInt32(quotient);
                return quotient;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("You cannot divide by zero");
                return 0;
            }
            
        }
    }
}
