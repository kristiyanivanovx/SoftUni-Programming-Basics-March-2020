using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
	class Program
	{
		static void Main(string[] args)
		{
			List<string> output = new List<string>();

			string input = Console.ReadLine();
			string pattern = @"(\=|\/)[A-Z]{1}[A-Za-z]{2,}\1";
			MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.Multiline);

			int score = 0;
			foreach (Match m in matches)
			{
				string destination = m.Value.Substring(1, m.Value.Length - 2);
				output.Add(destination);
				score += destination.Length;
			}

			Console.WriteLine("Destinations: " + string.Join(", ", output));
			Console.WriteLine("Travel Points: " + score);
		}
	}
}
