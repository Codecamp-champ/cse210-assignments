using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int input;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            if (int.TryParse(Console.ReadLine(), out input) && input != 0)
            {
                numbers.Add(input);
            }
            else if (input == 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        } while (true);

        if (numbers.Count > 0)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            double average = (double)sum / numbers.Count;

            int max = int.MinValue;
            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {Math.Round(average, 2)}");
            Console.WriteLine($"The largest number is: {max}");

            // Stretch Challenge: Smallest positive number
            int smallestPositive = int.MaxValue;
            bool positiveFound = false;
            foreach (int number in numbers)
            {
                if (number > 0 && number < smallestPositive)
                {
                    smallestPositive = number;
                    positiveFound = true;
                }
            }

            if (positiveFound)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }
            else
            {
                Console.WriteLine("No positive numbers were entered.");
            }

            // Stretch Challenge: Sorted list
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}