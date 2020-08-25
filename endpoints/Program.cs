using Endpoints.Data;
using Endpoints.Entity;
using Endpoints.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace endpoints
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IEndpointService, EndpointService>()
                .BuildServiceProvider();

            var endpointService = serviceProvider.GetService<IEndpointService>();

            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Insert a new endpoint");
            Console.WriteLine("2) Edit an existing endpoint");
            Console.WriteLine("3) Delete an existing endpoint");
            Console.WriteLine("4) List all endpoints");
            Console.WriteLine("5) Find an endpoint by serial number");
            Console.WriteLine("6) Exit");

            Console.Write("\r\nSelect an option: ");


            switch (Console.ReadLine())
            {
                case "1":

                    CreateEndpoint(endpointService);

                    return true;

                case "2":

                    EditEndpoint(endpointService);

                    return true;

                case "3":

                    DeleteEndpoint(endpointService);

                    return true;

                case "4":

                    ListAllEndpoints(endpointService);

                    return true;

                case "5":

                    FindAnEndpoint(endpointService);

                    return true;

                case "6":

                    return Exit(); 

                default:
                    return true;
            }
        }

        private static bool Exit()
        {
            ConsoleKey response;
            do
            {
                Console.Write("Are you sure you want to exit? [y/n] ");
                response = Console.ReadKey(false).Key;   
                if (response != ConsoleKey.Enter)
                    Console.WriteLine();

            } while (response != ConsoleKey.Y && response != ConsoleKey.N);

            if (response == ConsoleKey.Y)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private static void FindAnEndpoint(IEndpointService endpointService)
        {
            endpointService.Find();
        }

        private static void ListAllEndpoints(IEndpointService endpointService)
        {
            endpointService.ListAll();
        }

        private static void DeleteEndpoint(IEndpointService endpointService)
        {
            endpointService.Delete();
        }

        private static void EditEndpoint(IEndpointService endpointService)
        {
            endpointService.Edit();
        }

        private static void CreateEndpoint(IEndpointService endpointService)
        {
            endpointService.Create(new Endpoint());
        }
    }
}
