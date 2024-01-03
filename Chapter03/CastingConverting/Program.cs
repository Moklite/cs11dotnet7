namespace CastingConverting
{
	using static System.Console;

	internal class Program
	{
		static void Main(string[] args)
		{
			WriteLine("How may eggs are there? ");
			string? input = Console.ReadLine();

			if (int.TryParse(input, out int count))
			{
				WriteLine($"There are {count} eggs");
			}
			else
			{
				WriteLine("cannot parse input");
			}
		}
	}
}