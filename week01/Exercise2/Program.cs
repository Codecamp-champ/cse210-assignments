using System;

    class Program
    {
        static void Main(string[] args)
        {
            // Core Requirements
            Console.Write("Enter your grade percentage: ");
            if (double.TryParse(Console.ReadLine(), out double gradePercentage))
            {
                string letter;

                if (gradePercentage >= 90)
                {
                    letter = "A";
                }
                else if (gradePercentage >= 80)
                {
                    letter = "B";
                }
                else if (gradePercentage >= 70)
                {
                    letter = "C";
                }
                else if (gradePercentage >= 60)
                {
                    letter = "D";
                }
                else
                {
                    letter = "F";
                }

                Console.WriteLine($"Your letter grade is: {letter}");

                if (gradePercentage >= 70)
                {
                    Console.WriteLine("Congratulations! You passed the course.");
                }
                else
                {
                    Console.WriteLine("Keep trying! You'll get it next time.");
                }

                // Stretch Challenge
                string sign = "";

                if (gradePercentage >= 60)
                {
                    int lastDigit = (int)gradePercentage % 10;

                    if (lastDigit >= 7 && gradePercentage < 100)
                    {
                        sign = "+";
                    }
                    else if (lastDigit < 3 && gradePercentage >= 60)
                    {
                        sign = "-";
                    }
                }

                // Handle A+ and F+ or F-
                if (letter == "A")
                {
                   if(gradePercentage >= 97 && gradePercentage <= 100)
                   {
                       sign = "+";
                   }
                   else if (gradePercentage < 93)
                   {
                       if(sign == "+")
                       {
                           sign = "";
                       }
                   }
                }

                if (letter == "F")
                {
                    sign = "";
                }

                Console.WriteLine($"Your final grade is: {letter}{sign}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }