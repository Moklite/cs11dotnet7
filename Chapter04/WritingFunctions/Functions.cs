using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingFunctions
{
	public class Functions
	{
		public static void TimesTable(byte number, byte size = 12)
		{
			WriteLine($"This is the {number} times table with {size} rows:");
			for (int row = 1; row <= size; row++)
			{
				WriteLine($"{row} x {number} = {row * number}");
			}
			WriteLine();
		}

		static string CardinalToOrdinal(int number)
		{
			int lastTwoDigits = number % 100;
			switch (lastTwoDigits)
			{
				case 11: // special cases for 11th to 13th
				case 12:
				case 13:
					return $"{number:N0}th";
				default:
					int lastDigit = number % 10;
					string suffix = lastDigit switch
					{
						1 => "st",
						2 => "nd",
						3 => "rd",
						_ => "th"
					};
					return $"{number:N0}{suffix}";
			}
		}

		static int Factorial(int number)
		{
			if (number < 0)
			{
				throw new ArgumentException(message:
				$"The factorial function is defined for non-negative integersonly.Input: {number}",
			   paramName: nameof(number));
			}
			else if (number == 0)
			{
				return 1;
			}
			else
			{
				return number * Factorial(number - 1);
			}
		}

		static void RunFactorial()
		{
			for (int i = 1; i <= 15; i++)
			{
				WriteLine($"{i}! = {Factorial(i):N0}");
			}
		}

		static int FibImperative(int term)
		{
			if (term == 1)
			{
				return 0;
			}
			else if (term == 2)
			{
				return 1;
			}
			else
			{
				return FibImperative(term - 1) + FibImperative(term - 2);
			}
		}

		static void RunFibImperative()
		{
			for (int i = 1; i <= 30; i++)
			{
				WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.",
				arg0: CardinalToOrdinal(i),
				arg1: FibImperative(term: i));
			}
		}

		static int FibFunctional(int term) =>
			term switch
			{
				1 => 0,
				2 => 1,
				_ => FibFunctional(term - 1) + FibFunctional(term - 2)
			};

		static void RunFibFunctional()
		{
			for (int i = 1; i <= 30; i++)
			{
				WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.",
				arg0: CardinalToOrdinal(i),
				arg1: FibFunctional(term: i));
			}
		}
	}
}
