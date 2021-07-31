using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
	class Program
	{
		static void Main(string[] args)
		{
			string numberPattern = @"\d";
			string emojiPattern = @"(:{2}|\*{2})[A-Z][a-z]{2,}\1";
			
			Regex numReg = new Regex(numberPattern);
			Regex emojiReg = new Regex(emojiPattern);

			string input = Console.ReadLine();

			long coolnessTreshold = 1;
			numReg.Matches(input)
				.Select(x => x.Value)
				.Select(x => int.Parse(x))
				.ToList()
				.ForEach(x => coolnessTreshold *= x);

			List<string> coolEmojis = new List<string>();
			var emojiMatches = emojiReg.Matches(input);
			int totalEmojis = emojiMatches.Count;

			foreach (Match item in emojiMatches)
			{
				long coolIndex = item.Value
					.Substring(2, item.Value.Length - 4)
					.ToCharArray()
					.Sum(x => (int)x);

				if (coolIndex > coolnessTreshold)
				{
					coolEmojis.Add(item.Value);
				}
			}

			Console.WriteLine($"Cool threshold: {coolnessTreshold}");
			Console.WriteLine($"{totalEmojis} emojis found in the text. The cool ones are:");
			coolEmojis.ForEach(e => Console.WriteLine(e));
		}
	}
}

