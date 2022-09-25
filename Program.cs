namespace CalculatorConsole
{
    using System;
    using System.Threading;
    using static Calculator;
    using static BiCalculator;
    using static PiCalculator;

    internal class Program
    {
        public static bool isError = false;
        public static int output;

        public const string one = "1", two = "2", three = "3";

        private static void Main()
        {
            var mainThread = Thread.CurrentThread;
            mainThread.IsBackground = false;
            mainThread.Priority = ThreadPriority.Highest;
            Calculate();
        }

        public static void Calculate()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Choose calculation type: ");
            Console.WriteLine(" ");

            Console.WriteLine(one + ": Decimal math, its accurate, but you can't use BigInteger size numbers.");
            Console.WriteLine(" ");

            Console.WriteLine(two + ": BigInteger math, unfortunately, only one operator at a time is supported.");
            Console.WriteLine(" ");

            Console.WriteLine(three + ": Calculates pi to given number of digits.");
            Console.WriteLine("Way better and faster algo with a decimal point too. Perfectly accurate, 100K digits in 20 seconds");
            Console.WriteLine(" ");

            Console.WriteLine("Press enter to exit the console.");
            Console.WriteLine(" ");

            SwitchMathType();
        }

        public static void SwitchMathType()
        {
            var inputString = Console.ReadLine();
            var digits = int.TryParse(inputString, out output);
            if (digits || inputString == "")
            {
                switch (inputString)
                {
                    case one:
                        SmallMath();
                        break;
                    case two:
                        BigMath();
                        break;
                    case three:
                        CalculatePi();
                        break;
                    case "":
                        Exit();
                        break;
                }
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Calculate();
            }
        }

        public static void Exit()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(" ");
            Console.WriteLine("Are you sure you want to exit? y/n");
            Console.WriteLine(" ");

            var yes = "y";
            var no = "n";
            var answer = Console.ReadLine();

            if (answer == yes)
            {
                Environment.Exit(0);
            }
            else if (answer == no)
            {
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Calculate();
            }
            else
            {
                Exit();
            }
        }
    }
}
