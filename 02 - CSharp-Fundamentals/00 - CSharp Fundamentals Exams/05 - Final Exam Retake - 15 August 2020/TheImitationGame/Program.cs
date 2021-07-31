using System;

namespace TheImitationGame
{
	class Program
	{
		static void Main(string[] args)
		{
			string message = Console.ReadLine();

			string command = Console.ReadLine();
			while (!command.Contains("Decode"))
			{
				string[] data = command.Split("|");
				string type = data[0];
				if (type == "Move")
				{
					int numberOfLetters = int.Parse(data[1]);
					string copy = message.Substring(0, numberOfLetters);
					message = message.Remove(0, numberOfLetters);
					message += copy;
				}
				else if (type == "Insert")
				{
					int index = int.Parse(data[1]);
					string value = data[2];
					message = message.Insert(index, value);
				}
				else if (type == "ChangeAll")
				{
					string substring = data[1];
					string replacement = data[2];
					message = message.Replace(substring, replacement);
				}

				command = Console.ReadLine();
			}

			Console.WriteLine($"The decrypted message is: {message}");
		}
	}
}
