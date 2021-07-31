using System;

namespace ActivationKeys
{
	class Program
	{
		static void Main(string[] args)
		{
			var activationKey = Console.ReadLine();

			var command = Console.ReadLine();
			while (command != "Generate")
			{
				var data = command.Split(">>>");
				var cmd = data[0];

				if (cmd == "Contains")
				{
					var substring = data[1];

					if (activationKey.Contains(substring))
					{
						Console.WriteLine($"{activationKey} contains {substring}");
					} 
					else
					{
						Console.WriteLine("Substring not found!");
					}
				}

				if (cmd == "Flip")
				{
					var subCmd = data[1];
					var startIndex = int.Parse(data[2]);
					var endIndex = int.Parse(data[3]);

					var firstPart = activationKey.Substring(0, startIndex);
					var secondPart = activationKey.Substring(startIndex, endIndex - startIndex);
					var thirdPart = activationKey.Substring(endIndex);

					if (subCmd == "Upper")
					{
						secondPart = secondPart.ToUpper();
					}
					else if (subCmd == "Lower")
					{
						secondPart = secondPart.ToLower();
					}

					activationKey = firstPart + secondPart + thirdPart;
					Console.WriteLine(activationKey);
				}

				if (cmd == "Slice")
				{
					var startIndex = int.Parse(data[1]);
					var endIndex = int.Parse(data[2]);
					activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
					Console.WriteLine(activationKey);
				}

				command = Console.ReadLine();
			}

			Console.WriteLine($"Your activation key is: {activationKey}");
		}
	}
}
