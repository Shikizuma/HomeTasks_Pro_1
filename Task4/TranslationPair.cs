using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
	internal class TranslationPair
	{
		public string Polish { get; set; }
		public string English { get; set; }

		public TranslationPair(string polish, string english)
		{
			Polish = polish;
			English = english;
		}
	}
}
