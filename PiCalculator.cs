namespace CalculatorConsole
{
    using System;
    using System.Diagnostics;
    using System.Numerics;
    using System.Text;
    using static Program;

    class PiCalculator
    {
        public static int output;
        public static HighPrecision piResults;

        public static void CalculatePi()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Enter the amount of pi digits to calculate: ");
            Console.WriteLine(" ");

            var inputString = Console.ReadLine();

            if (!string.IsNullOrEmpty(inputString))
            {
                var digits = int.TryParse(inputString, out output);

                if (digits)
                {
                    var input = int.Parse(inputString);
                    StopwatchUsingMethod();
                    void StopwatchUsingMethod()
                    {
                        var timer = new Stopwatch();
                        timer.Start();
                        piResults = HighPrecision.GetPi(input);
                        timer.Stop();
                        var timeTaken = timer.Elapsed;
                        var writeTime = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
                        Console.WriteLine(writeTime);
                    }
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Not a number.");
                    CalculatePi();
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ");
            Console.WriteLine("-------------------");
            Console.WriteLine("Result: " + piResults);
            Console.WriteLine("-------------------");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Calculate();
        }
    }

    /// <summary>
    /// All credits to the author https://github.com/latkin of this pi algorithm found here: https://latkin.org/blog/2012/03/20/how-to-calculate-1-million-digits-of-pi/
    /// This person is a saint and this algorithm is amazing.
    /// This calculated 100,000 digits of pi in 30 seconds on my potato hardware in a regular single thread.
    /// </summary>
    public class HighPrecision
    {
        public static HighPrecision GetPi(int digits)
        {
            HighPrecision.Precision = digits;
            HighPrecision first = 4 * Atan(5);
            HighPrecision second = Atan(239);
            return 4 * (first - second);
        }

        public static HighPrecision Atan(int denominator)
        {
            HighPrecision result = new HighPrecision(1, denominator);
            int xSquared = denominator * denominator;

            int divisor = 1;
            HighPrecision term = result;

            while (!term.IsZero)
            {
                divisor += 2;
                term /= xSquared;
                result -= term / divisor;

                divisor += 2;
                term /= xSquared;
                result += term / divisor;
            }

            return result;
        }

        private static BigInteger denom;
        private static int precision;
        private static int slop = 4;
        private BigInteger num;

        public HighPrecision(BigInteger numerator, BigInteger denominator)
        {
            // public constructor rescales numerator as needed
            num = (HighPrecision.denom * numerator) / denominator;
        }

        private HighPrecision(BigInteger numerator)
        {
            // private constructor for when we already know the scaling
            num = numerator;
        }

        public static int Precision
        {
            get { return precision; }
            set
            {
                HighPrecision.precision = value;
                denom = BigInteger.Pow(10, HighPrecision.precision + slop);  // leave some buffer
            }
        }

        public bool IsZero
        {
            get { return num.IsZero; }
        }

        public BigInteger Numerator
        {
            get { return num; }
        }

        public BigInteger Denominator
        {
            get { return HighPrecision.denom; }
        }

        public static HighPrecision operator *(int left, HighPrecision right)
        {
            // no need to resale when multiplying by an int
            return new HighPrecision(right.num * left);
        }

        public static HighPrecision operator *(HighPrecision left, HighPrecision right)
        {
            // a/D * b/D = ab/D^2 = (ab/D)/D
            return new HighPrecision((left.num * right.num) / HighPrecision.denom);
        }

        public static HighPrecision operator /(HighPrecision left, int right)
        {
            // no need to rescale when dividing by an int
            return new HighPrecision(left.num / right);
        }

        public static HighPrecision operator +(HighPrecision left, HighPrecision right)
        {
            // when we know the denominators are the same, can just add the numerators
            return new HighPrecision(left.num + right.num);
        }

        public static HighPrecision operator -(HighPrecision left, HighPrecision right)
        {
            // when we know the denominators are the same, can just subtract the numerators
            return new HighPrecision(left.num - right.num);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            // pull out the integer part
            BigInteger remain;
            BigInteger quotient = BigInteger.DivRem(num, HighPrecision.denom, out remain);
            int integerDigits = quotient.IsZero ? 1 : (int)BigInteger.Log10(quotient) + 1;
            sb.Append(quotient.ToString());

            int i = 0;
            BigInteger smallDenom = HighPrecision.denom / 10;
            BigInteger tempRemain;

            // pull out all of the 0s after the decimal point
            while (i++ < HighPrecision.Precision && (quotient = BigInteger.DivRem(remain, smallDenom, out tempRemain)).IsZero)
            {
                smallDenom /= 10;
                remain = tempRemain;
                sb.Append('0');
            }

            // append the rest of the remainder
            sb.Append(remain.ToString());

            // truncate and insert the decimal point
            return sb.ToString().Remove(integerDigits + HighPrecision.Precision).Insert(integerDigits, ".");
        }
    }
}
