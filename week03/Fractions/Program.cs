using System;

    class Program
    {
        static void Main(string[] args)
        {
            // Test the constructors
            Fraction fraction1 = new Fraction();
            Console.WriteLine(fraction1.GetFractionString());
            Console.WriteLine(fraction1.GetDecimalValue());

            Fraction fraction2 = new Fraction(5);
            Console.WriteLine(fraction2.GetFractionString());
            Console.WriteLine(fraction2.GetDecimalValue());

            Fraction fraction3 = new Fraction(3, 4);
            Console.WriteLine(fraction3.GetFractionString());
            Console.WriteLine(fraction3.GetDecimalValue());

            Fraction fraction4 = new Fraction(1, 3);
            Console.WriteLine(fraction4.GetFractionString());
            Console.WriteLine(fraction4.GetDecimalValue());

            // Test the getters and setters
            Fraction fraction5 = new Fraction();
            fraction5.Top = 6;
            fraction5.Bottom = 7;
            Console.WriteLine(fraction5.GetFractionString());
            Console.WriteLine(fraction5.GetDecimalValue());
        }
    }