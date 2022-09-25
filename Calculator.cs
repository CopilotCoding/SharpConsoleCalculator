namespace CalculatorConsole
{
    using System;
    using System.Data;
    using static Program;

    public class Calculator
    {
        public static decimal result;

        public static object ComputeTable;
        public static decimal ConvertTable;

        public static void SmallMath()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Enter the equation: ");
            Console.WriteLine(" ");

            result = CalculateDecimalString(Console.ReadLine());

            if (isError == false)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" ");
                Console.WriteLine("-------------------");
                Console.WriteLine("Result: " + result);
                Console.WriteLine("-------------------");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
            }

            Calculate();
        }

        public static decimal CalculateDecimalString(string input)
        {
            var table = new DataTable();

            if (input.Contains("/") || input.Contains("*") || input.Contains("+") || input.Contains("-"))
            {
                try
                {
                    ComputeTable = table.Compute(input, string.Empty);
                }
                catch
                {
                    Console.WriteLine("Input equation was too large or too small.");
                    Console.WriteLine(" ");
                }
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("Not a computable equation.");
                SmallMath();            
            }

            try
            {
                if (ComputeTable != null)
                {
                    ConvertTable = Convert.ToDecimal(ComputeTable);
                }
            }
            catch
            {
                Console.WriteLine(" ");
                Console.WriteLine("Input equation was too large or too small.");
                Console.WriteLine(" ");

                isError = true;
            }

            return ConvertTable;
        }
    }
}
