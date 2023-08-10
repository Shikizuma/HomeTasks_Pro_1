using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	internal class Person
	{
		public string Name { get; set; }
		public int BirthYear { get; set; }
		public List<Person> Children { get; set; } = new List<Person>();
	}
}
