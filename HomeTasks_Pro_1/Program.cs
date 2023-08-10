namespace HomeTasks_Pro_1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			MonthCollection monthCollection = new MonthCollection()
			{
				new Month { CountOfDaysInMonth = 31, NameMonth = "January", NumberOfMonth = 1 },
				new Month { CountOfDaysInMonth = 28, NameMonth = "February", NumberOfMonth = 2 },
				new Month { CountOfDaysInMonth = 31, NameMonth = "March", NumberOfMonth = 3 },
				new Month { CountOfDaysInMonth = 30, NameMonth = "April", NumberOfMonth = 4 },
				new Month { CountOfDaysInMonth = 31, NameMonth = "May", NumberOfMonth = 5 },
				new Month { CountOfDaysInMonth = 30, NameMonth = "June", NumberOfMonth = 6 },
				new Month { CountOfDaysInMonth = 31, NameMonth = "July", NumberOfMonth = 7 },
				new Month { CountOfDaysInMonth = 31, NameMonth = "August", NumberOfMonth = 8 },
				new Month { CountOfDaysInMonth = 30, NameMonth = "September", NumberOfMonth = 9 },
				//new Month { CountOfDaysInMonth = 31, NameMonth = "October", NumberOfMonth = 10 },
				new Month { CountOfDaysInMonth = 30, NameMonth = "November", NumberOfMonth = 11 },
				new Month { CountOfDaysInMonth = 31, NameMonth = "December", NumberOfMonth = 12 }
			};

			monthCollection.Insert(9, new Month { CountOfDaysInMonth = 31, NameMonth = "October", NumberOfMonth = 10 });

			foreach (Month item in monthCollection)
			{
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 25));

            Console.WriteLine(monthCollection.GetMonthByNumber(12));

			Console.WriteLine(new string('-', 25));

			Month[] newMounth = monthCollection.GetMonthsByDays(31);
			foreach (Month item in newMounth)
			{
                Console.WriteLine(item);
            }
		}
	}
}