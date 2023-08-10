namespace Task6
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

			foreach (var square in GetSquareOfOddNumbers(numbers))
			{
				Console.WriteLine(square);
			}
		}
		static IEnumerable<int> GetSquareOfOddNumbers(int[] numbers)
		{
			foreach (var number in numbers)
			{
				if (number % 2 != 0)
				{
					yield return number * number; 
				}
			}
		}
	}
}