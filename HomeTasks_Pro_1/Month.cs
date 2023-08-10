using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTasks_Pro_1
{
	internal class Month
	{
		private int numberOfMonth;
		private int countOfDaysInMonth;
		private string nameMonth;

		public int NumberOfMonth
		{
			get { return numberOfMonth; }
			set { numberOfMonth = value; }
		}

		public int CountOfDaysInMonth
		{
			get { return countOfDaysInMonth; }
			set { countOfDaysInMonth = value; }
		}

		public string NameMonth
		{
			get { return nameMonth; }
			set { nameMonth = value; }
		}

		public override string ToString()
		{
			return $"{NameMonth} - {NumberOfMonth} - {CountOfDaysInMonth}";
		}
	}
}
