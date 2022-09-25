namespace CalculatorConsole
{
    using System;
    using System.Numerics;
    using static Program;
    
    class BiCalculator
    {
        public static BigInteger results;

        public static BigInteger resultsInput;

        public static void BigMath()
        {

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Enter the equation: ");
            Console.WriteLine(" ");

            var inputString = Console.ReadLine();

            results = CalculateStringWIP(inputString);

            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("-------------------");
            Console.WriteLine("Result: " + results);
            Console.WriteLine("-------------------");

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            Calculate();
        }

        // The purpose of this function is to take the input string and convert it into an equation that can be solved.
        public static BigInteger CalculateStringWIP(string input)
        {
            // list of numbers
            // string[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            // list of functions
            // string[] functions = { "sqrt", "pow", "log", "sin", "cos", "tan" };

            // list of variables get capitalized and lowercase
            // string[] variablesUpperCase = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            // string[] variablesLowerCase = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            // list of parentheses
            // string[] brackets = { "(", ")" };

            // list of exponents
            // string[] exponents = { "^" };

            // list of operators
            string[] operators = { "/", "*", "+", "-" };

            if (input.Contains("/") || input.Contains("*") || input.Contains("+") || input.Contains("-"))
            {
                // take the input string and get all the operators, and put them into an array
                string[] operatorsArray = input.Split(operators, StringSplitOptions.RemoveEmptyEntries);

                // get the operator
                string operatorString = input.Substring(operatorsArray[0].Length, 1);

                // get the left side of the expression
                string left = operatorsArray[0];

                // get the right side of the expression
                string right = operatorsArray[1];

                // convert the left side of the expression to a biginteger
                BigInteger leftBigInteger = BigInteger.Parse(left);

                // convert the right side of the expression to a biginteger
                BigInteger rightBigInteger = BigInteger.Parse(right);

                switch (operatorString)
                {
                    case "+":
                        resultsInput = leftBigInteger + rightBigInteger;
                        break;
                    case "-":
                        resultsInput = leftBigInteger - rightBigInteger;
                        break;
                    case "*":
                        resultsInput = leftBigInteger * rightBigInteger;
                        break;
                    case "/":
                        if (leftBigInteger == 0 || rightBigInteger == 0)
                        {
                            resultsInput = 0;
                        }
                        else if (leftBigInteger != 0 && rightBigInteger != 0)
                        {
                            resultsInput = leftBigInteger / rightBigInteger;
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("Not a compatible equation.");
                BigMath();
            }
            return resultsInput;
        }
    }
}
