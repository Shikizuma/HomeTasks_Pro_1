using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	internal class FamilyTreeCollection
	{
		private List<Person> people = new List<Person>();

		public void AddPerson(string name, int birthYear)
		{
			people.Add(new Person { Name = name, BirthYear = birthYear });
		}

		public void AddChild(string parentName, string childName, int childBirthYear)
		{
			Person parent = people.Find(p => p.Name == parentName);
			if (parent != null)
			{
				parent.Children.Add(new Person { Name = childName, BirthYear = childBirthYear });
			}
		}

		public void RemovePerson(string name)
		{
			Person person = people.Find(p => p.Name == name);
			if (person != null)
			{
				people.Remove(person);
				foreach (Person p in people)
				{
					p.Children.RemoveAll(child => child.Name == name);
				}
			}
		}

		public List<Person> GetDescendants(string name)
		{
			Person person = people.Find(p => p.Name == name);
			if (person != null)
			{
				List<Person> descendants = new List<Person>();
				GetDescendantsRecursive(person, descendants);
				return descendants;
			}
			return null;
		}

		private void GetDescendantsRecursive(Person person, List<Person> descendants)
		{
			foreach (Person child in person.Children)
			{
				descendants.Add(child);
				GetDescendantsRecursive(child, descendants);
			}
		}

		public List<Person> GetRelativesByBirthYear(string name, int birthYear)
		{
			List<Person> relatives = new List<Person>();
			GetRelativesByBirthYearRecursive(people.Find(p => p.Name == name), birthYear, relatives);
			return relatives;
		}

		private void GetRelativesByBirthYearRecursive(Person person, int birthYear, List<Person> relatives)
		{
			if (person.BirthYear == birthYear)
			{
				relatives.Add(person);
			}
			foreach (Person child in person.Children)
			{
				GetRelativesByBirthYearRecursive(child, birthYear, relatives);
			}
		}
	}
}
