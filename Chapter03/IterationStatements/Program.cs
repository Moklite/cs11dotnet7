namespace IterationStatements
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//int x = 0;
			//while (x < 10)
			//{
			//	if (x%2 != 0)
			//	{
			//		Console.WriteLine(x);
			//	}
			//	x++;
			//}
			//string? password;
			//do
			//{
			//	Console.WriteLine("input your password: ");
			//	password = Console.ReadLine();

			//} while (password != "john");
			//Console.WriteLine("correct");

			//for(int x = 0; x < 10; x++)
			//{
			//	Console.WriteLine(x);
			//}
			int[,] matrix = {
			{1, 2, 3},
			{4, 5, 6},
			{7, 8, 9}
		};

			// Get the number of rows and columns
			int rows = matrix.GetLength(0);
			int cols = matrix.GetLength(1);

			// Loop through the array using nested loops
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					// Access each element in the array
					int value = matrix[i, j];

					// Do something with the element (print in this case)
					Console.Write(value + " ");
				}
				// Move to the next row
				Console.WriteLine();
			}

		}
	}
}