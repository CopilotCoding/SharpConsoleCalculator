# CalculatorConsole
A simple C# calculator made with a .NET framework console project template which can calculate addition, subtraction, multiplication, division, and PI.

# Building
Create a new .NET framework console project and add this code to it.

# Usage
If you enter 1 in the console, you can do simple math on regular sized numbers of any amount of operators.
No support for complex math.

If you enter 2 in the console, you can do simple math on infinite sized numbers with one operator.
No support for multiple operators or complex math.

If you enter 3 in the console, you can calculate PI to the entered digits.
This may be very slow if you go over 100,000 digits of PI.

# All credits to the author of this pi algorithm https://github.com/latkin found here:

https://latkin.org/blog/2012/03/20/how-to-calculate-1-million-digits-of-pi/

# Known problems
No support for brackets, exponents, multiple operators with arbitrary sized numbers, other complex math, and whitespace.

There is also a problem with System.Numerics not being used even with a using statement of it. Not sure why but its easy to fix.

# Created using github copilot while it was free
