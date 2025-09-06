using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        List<int> numbers = new List<int>();
        int number = -1;
        
        // Get numbers from user until they enter 0
        while (number != 0)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine() ?? "";
            
            if (int.TryParse(input, out number))
            {
                if (number != 0)
                {
                    numbers.Add(number);
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
        
        // Core Requirements
        
        // 1. Compute the sum
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        Console.WriteLine($"The sum is: {sum}");
        
        // 2. Compute the average
        if (numbers.Count > 0)
        {
            double average = (double)sum / numbers.Count;
            Console.WriteLine($"The average is: {average}");
        }
        else
        {
            Console.WriteLine("The average is: 0");
        }
        
        // 3. Find the maximum
        if (numbers.Count > 0)
        {
            int max = numbers[0];
            foreach (int num in numbers)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            Console.WriteLine($"The largest number is: {max}");
        }
        else
        {
            Console.WriteLine("The largest number is: 0");
        }
        
        // Stretch Challenges
        
        // 4. Find the smallest positive number
        int smallestPositive = int.MaxValue;
        bool foundPositive = false;
        
        foreach (int num in numbers)
        {
            if (num > 0 && num < smallestPositive)
            {
                smallestPositive = num;
                foundPositive = true;
            }
        }
        
        if (foundPositive)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("No positive numbers found.");
        }
        
        // 5. Sort the numbers and display
        if (numbers.Count > 0)
        {
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
        else
        {
            Console.WriteLine("The sorted list is: (empty)");
        }
    }
}
