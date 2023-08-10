namespace Task3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			FamilyTreeCollection familyTree = new FamilyTreeCollection();

			familyTree.AddPerson("John", 1980);
			familyTree.AddChild("John", "Alice", 2005);
			familyTree.AddChild("John", "Bob", 2010);
			familyTree.AddChild("Alice", "Eva", 2022);

			List<Person> descendants = familyTree.GetDescendants("John");
			Console.WriteLine("Descendants of John:");
			foreach (Person person in descendants)
			{
				Console.WriteLine($"{person.Name} - {person.BirthYear}");
			}

			List<Person> relatives = familyTree.GetRelativesByBirthYear("John", 2005);
			Console.WriteLine("Relatives of John born in 2005:");
			foreach (Person person in relatives)
			{
				Console.WriteLine($"{person.Name} - {person.BirthYear}");
			}
		}
	}
}