using System;

namespace cinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalTickets = 0;
            int studentTickets = 0;
            int standardTickets = 0;
            int kidsTickets = 0;

            while (true)
            {
                string movie = Console.ReadLine();

                if (movie == "Finish")
                {
                    break;
                }
                
                int capacity = int.Parse(Console.ReadLine());
                int movieTickets = 0;

                while (true)
                {
                    string ticketType = Console.ReadLine();
                    if (ticketType == "End")
                    {
                        break;
                    }

                    switch (ticketType)
                    {
                        case "student":
                            studentTickets++;
                            break;

                        case "standard":
                            standardTickets++;
                            break;

                        case "kid":
                            kidsTickets++;
                            break;

                    }

                    movieTickets++;

                    if (movieTickets >= capacity)
                    {
                        break;
                    }

                }

                Console.WriteLine($"{movie} - {100.0 * movieTickets / capacity:f2}% full.");
                totalTickets += movieTickets;
            }
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{100.0 * studentTickets / totalTickets:f2}% student tickets.");
            Console.WriteLine($"{100.0 * standardTickets / totalTickets:f2}% standard tickets.");
            Console.WriteLine($"{100.0 * kidsTickets / totalTickets:f2}% kids tickets.");
        }
    }
}
