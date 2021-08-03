using System;

namespace countriesAndLanguages
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string language = "";

            switch (country)
            {
                case "Bulgaria":
                    language = "Bulgarian";
                    break;

                case "USA":
                case "UK":
                case "United Kingdom":
                case "United States":
                    language = "English";
                    break;

                case "Spain":
                    language = "Spanish";
                    break;

                default:
                    language = "Unknown";
                    break;

            }
            Console.WriteLine(language);
        }
    }
}
