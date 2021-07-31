using System;
using DI.Models;
using DI.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    class Program
    {
        static void Main(string[] args)
        {
            WithoutContainer();
            Separator();
            WithContainer();
        }

        private static void Separator()
        {
            Console.WriteLine("-----------------");
        }

        private static void WithContainer()
        {
            IServiceProvider service = new ServiceCollection()
                .AddScoped<IReader, Reader>()
                .AddScoped<IWriter, Writer>()
                .AddScoped<Copy, Copy>()
                .BuildServiceProvider();

            Copy copy = service.GetService<Copy>();
            copy.CopyAllText();
        }

        private static void WithoutContainer()
        {
            Copy copy = new Copy(new Reader(), new Writer());
            copy.CopyAllText();
        }
    }
}
