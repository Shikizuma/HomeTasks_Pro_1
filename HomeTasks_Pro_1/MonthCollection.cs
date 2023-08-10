using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTasks_Pro_1
{
	internal class MonthCollection : IEnumerable, IEnumerator, IList, ICollection
	{
		Month[] months = new Month[12];

		private int position = -1;
		private int count = 0;

		public object? this[int index] 
		{ 
			get => months[index]; 
			set => months[index] = value as Month; 
		}
	
		public bool IsFixedSize => true;

		public bool IsReadOnly => false;

		public int Count => count;

		public bool IsSynchronized => false;

		public object SyncRoot => false;

		public int Add(object? value)
		{
			if (count < 12)
			{
				months[count] = value as Month;
				count++;
				return count - 1;
			}
			else
			{
				Console.WriteLine("Collection is full. Cannot add more elements.");
				return -1;
			}
		}

		public void Clear()
		{
			months = new Month[12];
			count = 0;
		}

		public bool Contains(object? value)
		{
			for (int i = 0; i < Count; i++)
			{
				if (months[i] == value)
					return true;
			}

			return false;
		}

		public void CopyTo(Array array, int index)
		{
			var arr = array as object[];

			if (arr == null)
				throw new ArgumentNullException();

			for (int i = 0; i < arr.Length; i++)
			{
				arr[index] = months[i];
				index++;
			}
		}

		public int IndexOf(object? value)
		{
			for (int i = 0; i < Count; i++)
			{
				if (months[i] == value)
					return i;
			}

			return -1;
		}

		public void Insert(int index, object? value)
		{
			if (index < 0 || index > Count)
			{
				throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
			}

			if (count >= 12)
			{
				Console.WriteLine("Collection is full. Cannot insert more elements.");
				return;
			}

			// Shift elements to the right to make space for the new element
			for (int i = count - 1; i >= index; i--)
			{
				months[i + 1] = months[i];
			}

			months[index] = value as Month;
			count++;
		}

		public void Remove(object? value)
		{
			RemoveAt(IndexOf(value));
		}

		public void RemoveAt(int index)
		{
			if (index >= 0 && index < Count)
			{
				for (int i = index; index < Count - 1; index++)
					months[i] = months[i + 1];

				count--;
			}
		}

		#region Enumerator
		public object Current => months[position];

		public bool MoveNext()
		{
			if (position < Count - 1)
			{
				position++;
				return true;
			}

			Reset();
			return false;
		}

		public void Reset()
		{
			position = -1;
		}
		#endregion

		#region Enumerable
		public IEnumerator GetEnumerator()
		{
			return this;
		}
		#endregion

		#region Own Members
		public Month GetMonthByNumber(int monthNumber)
		{
			return months.First(x => x.NumberOfMonth == monthNumber);
		}

		public Month[] GetMonthsByDays(int days)
		{
			return months.Where(x => x.CountOfDaysInMonth == days).ToArray();
		}

		#endregion
	}
}
