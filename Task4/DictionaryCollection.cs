using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
	internal class DictionaryCollection : IDictionary<string, TranslationPair>
	{
		private List<string> keys = new List<string>();
		private List<TranslationPair> values = new List<TranslationPair>();

		public TranslationPair this[string key] 
		{
			get
			{
				int index = keys.IndexOf(key);
				if (index >= 0)
				{
					return values[index];
				}
				throw new KeyNotFoundException($"Translation for '{key}' not found.");
			}
			set
			{
				int index = keys.IndexOf(key);
				if (index >= 0)
				{
					values[index] = value;
				}
				else
				{
					keys.Add(key);
					values.Add(value);
				}
			}
		}

		public ICollection<string> Keys => keys;

		public ICollection<TranslationPair> Values => values;

		public int Count => keys.Count;

		public bool IsReadOnly => false;

		public void Add(string key, TranslationPair value)
		{
			keys.Add(key);
			values.Add(value);
		}

		public void Add(KeyValuePair<string, TranslationPair> item)
		{
			keys.Add(item.Key);
			values.Add(item.Value);
		}

		public void Clear()
		{
			keys.Clear(); 
			values.Clear();
		}

		public bool Contains(KeyValuePair<string, TranslationPair> item)
		{
			return keys.Contains(item.Key) && values.Contains(item.Value);
		}

		public bool ContainsKey(string key)
		{
			return keys.Contains(key);
		}

		public void CopyTo(KeyValuePair<string, TranslationPair>[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException(nameof(array));
			}

			if (arrayIndex < 0 || arrayIndex >= array.Length)
			{
				throw new ArgumentOutOfRangeException(nameof(arrayIndex));
			}

			for (int i = 0; i < keys.Count; i++)
			{
				array[arrayIndex + i] = new KeyValuePair<string, TranslationPair>(keys[i], values[i]);
			}
		}

		public IEnumerator<KeyValuePair<string, TranslationPair>> GetEnumerator()
		{
			for (int i = 0; i < keys.Count; i++)
			{
				yield return new KeyValuePair<string, TranslationPair>(keys[i], values[i]);
			}
		}

		public bool Remove(string key)
		{
			int index = keys.IndexOf(key);
			if (index >= 0)
			{
				keys.RemoveAt(index);
				values.RemoveAt(index);
				return true;
			}
			return false;
		}

		public bool Remove(KeyValuePair<string, TranslationPair> item)
		{
			int index = keys.IndexOf(item.Key);
			if (index >= 0 && values[index].Equals(item.Value))
			{
				keys.RemoveAt(index);
				values.RemoveAt(index);
				return true;
			}
			return false;
		}

		public bool TryGetValue(string key, [MaybeNullWhen(false)] out TranslationPair value)
		{
			int index = keys.IndexOf(key);
			if (index >= 0)
			{
				value = values[index];
				return true;
			}
			value = null;
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public string GetPolishTranslation(string ukrainian)
		{
			if (TryGetValue(ukrainian, out TranslationPair? translation))
			{
				return translation.Polish;
			}
			return "Translation not found";
		}

		public string GetEnglishTranslation(string ukrainian)
		{
			if (TryGetValue(ukrainian, out TranslationPair? translation))
			{
				return translation.English;
			}
			return "Translation not found";
		}
	}
}
