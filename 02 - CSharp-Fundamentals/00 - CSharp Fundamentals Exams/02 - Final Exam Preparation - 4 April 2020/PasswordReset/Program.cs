using System;

namespace PasswordReset
{
	class Program
	{
		static void Main(string[] args)
		{
			string password = Console.ReadLine();
			string command = Console.ReadLine();

			while (command != "Done")
			{
				string[] data = command.Split();

				if (data[0] == "TakeOdd")
				{
					string output = "";

					for (int i = 0; i < password.Length; i++)
					{
						bool isPositionOdd = i % 2 != 0;

						if (isPositionOdd)
						{
							char element = password[i];
							output += element;
						}
					}

					password = output;
					Console.WriteLine(password);
				}

				if (data[0] == "Cut")
				{
					int index = int.Parse(data[1]);
					int length = int.Parse(data[2]);
					password = password.Remove(index, length);
					Console.WriteLine(password);
				}

				if (data[0] == "Substitute")
				{
					string substring = data[1];
					string substitute = data[2];

					if (password.Contains(substring))
					{
						password = password.Replace(substring, substitute);
						Console.WriteLine(password);
					}
					else
					{
						Console.WriteLine("Nothing to replace!");
					}
				}

				command = Console.ReadLine();
			}

			Console.WriteLine($"Your password is: {password}");
		}
	}
}
