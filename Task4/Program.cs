namespace Task4
{
	internal class Program
	{
		static void Main(string[] args)
		{
			DictionaryCollection dictionary = new DictionaryCollection();

			// Додаємо переклади
			dictionary.Add("яблуко", new TranslationPair("jabłko", "apple"));
			dictionary.Add("автомобіль", new TranslationPair("samochód", "car"));
			dictionary.Add("книга", new TranslationPair("książka", "book"));

			Console.WriteLine("Polish translation of 'яблуко': " + dictionary.GetPolishTranslation("яблуко"));
			Console.WriteLine("English translation of 'автомобіль': " + dictionary.GetEnglishTranslation("автомобіль"));
			Console.WriteLine("Polish translation of 'книга': " + dictionary.GetPolishTranslation("книга"));

		}
	}
}