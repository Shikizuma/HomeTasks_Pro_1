using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	internal class FamilyTreeCollection
	{
		private Person root;

		public void AddPerson(string name, int birthYear)
		{
			Person newPerson = new Person { Name = name, BirthYear = birthYear };

			if (root == null)
			{
				root = newPerson;
			}
			else
			{
				AddToTree(root, newPerson);
			}
		}

		private void AddToTree(Person currentPerson, Person newPerson)
		{
			if (newPerson.BirthYear > currentPerson.BirthYear)
			{
				if (currentPerson.Children.Count == 0)
				{
					currentPerson.Children.Add(newPerson);
					newPerson.Parent = currentPerson;
				}
				else
				{
					foreach (var child in currentPerson.Children)
					{
						AddToTree(child, newPerson);
					}
				}
			}
		}

		public void RemovePerson(string name)
		{
			Person personToRemove = FindPerson(root, name);
			if (personToRemove != null)
			{		
				if (personToRemove.Parent != null)
				{
					personToRemove.Parent.Children.Remove(personToRemove);
				}

				foreach (var child in personToRemove.Children)
				{
					child.Parent = personToRemove.Parent;
				}
			}
		}

		public List<Person> GetDescendants(string name)
		{
			List<Person> descendants = new List<Person>();
			Person person = FindPerson(root, name);
			if (person != null)
			{
				GetDescendantsRecursive(person, descendants);
			}
			return descendants;
		}

		private Person FindPerson(Person currentPerson, string name)
		{
			if (currentPerson.Name == name)
			{
				return currentPerson;
			}
			foreach (var child in currentPerson.Children)
			{
				var foundPerson = FindPerson(child, name);
				if (foundPerson != null)
				{
					return foundPerson;
				}
			}
			return null;
		}

		private void GetDescendantsRecursive(Person currentPerson, List<Person> descendants)
		{
			descendants.Add(currentPerson);
			foreach (var child in currentPerson.Children)
			{
				GetDescendantsRecursive(child, descendants);
			}
		}

		public List<Person> GetRelativesByBirthYear(int birthYear)
		{
			List<Person> relatives = new List<Person>();
			GetRelativesByBirthYearRecursive(root, birthYear, relatives);
			return relatives;
		}

		private void GetRelativesByBirthYearRecursive(Person currentPerson, int birthYear, List<Person> relatives)
		{
			if (currentPerson.BirthYear == birthYear)
			{
				relatives.Add(currentPerson);
			}
			foreach (var child in currentPerson.Children)
			{
				GetRelativesByBirthYearRecursive(child, birthYear, relatives);
			}
		}
	}
}
