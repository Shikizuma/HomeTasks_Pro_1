namespace Task3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			FamilyTreeCollection familyTree = new FamilyTreeCollection();

			familyTree.AddPerson("John", 1980);
			familyTree.AddPerson("Jane", 1985);
			familyTree.AddPerson("Alice", 2000);
			familyTree.AddPerson("Bob", 2005);

			List<Person> descendants = familyTree.GetDescendants("John");
			Console.WriteLine("Descendants of John:");
			foreach (var descendant in descendants)
			{
				Console.WriteLine($"{descendant.Name} ({descendant.BirthYear})");
			}

			List<Person> relatives = familyTree.GetRelativesByBirthYear(2000);
			Console.WriteLine("Relatives born in 2000:");
			foreach (var relative in relatives)
			{
				Console.WriteLine($"{relative.Name} ({relative.BirthYear})");
			}
		}
	}
}