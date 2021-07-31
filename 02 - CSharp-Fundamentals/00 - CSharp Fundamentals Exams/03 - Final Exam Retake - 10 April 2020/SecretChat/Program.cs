using System;

namespace SecretChat
{
	class Program
	{
		static void Main(string[] args)
		{
			string message = Console.ReadLine();
			string command = Console.ReadLine();

			while (command != "Reveal")
			{
				var data = command.Split(":|:");
				var cmd = data[0];

				if (cmd == "InsertSpace")
				{
					int index = int.Parse(data[1]);
					message = message.Insert(index, " ");
					Console.WriteLine(message);
				}
				else if (cmd == "Reverse")
				{
					string substring = data[1];
					int index = message.IndexOf(substring);

					if (message.Contains(substring))
					{
						message = message.Remove(index, substring.Length);
						char[] charArray = substring.ToCharArray();
						Array.Reverse(charArray);
						var reversed = new string(charArray);
						message += reversed;
						Console.WriteLine(message);
					}
					else
					{
						Console.WriteLine("error");
					}
				}
				else if (cmd == "ChangeAll")
				{
					var substring = data[1];
					var replacement = data[2];
					message = message.Replace(substring, replacement);
					Console.WriteLine(message);
				}

				command = Console.ReadLine();
			}

			Console.WriteLine($"You have a new text message: {message}");
		}
	}
}
