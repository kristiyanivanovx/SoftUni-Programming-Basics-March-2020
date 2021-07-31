using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MirrorWords
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, string> pairs = new Dictionary<string, string>();
			string input = Console.ReadLine();
			string pattern = @"(@{1}|#{1})[A-Za-z]{3,}(\1\1)[A-Za-z]{3,}(\1)";
			int count = 0;

			RegexOptions options = RegexOptions.Multiline;

			foreach (Match m in Regex.Matches(input, pattern, options))
			{
				count++;

				StringSplitOptions splitOptions = StringSplitOptions.RemoveEmptyEntries;
				string[] splitted = m.Value.Split(new string[] { "##", "@@" }, splitOptions).ToArray();
				string firstElement = splitted[0].Substring(1);
				string secondElement = splitted[1].Substring(0, splitted[1].Length - 1);

				char[] charArray = secondElement.ToCharArray();
				Array.Reverse(charArray);
				string secondElementReversed = new string(charArray);

				if (firstElement.Equals(secondElementReversed, StringComparison.Ordinal))
				{
					pairs.Add(firstElement, secondElement);
				}
			}

			string output = count == 0 ? "No" : count.ToString();
			Console.WriteLine($"{output} word pairs found!");

			if (pairs.Any())
			{
				Console.WriteLine("The mirror words are:");

				string result = "";
				pairs.ToList().ForEach(x => result += x.Key + " <=> " + x.Value + ", ");
				result = result.Substring(0, result.Length - 2);
				Console.WriteLine(result);
			}
			else
			{
				Console.WriteLine("No mirror words!");
			}
		}
	}
}
