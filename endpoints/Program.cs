using Endpoints.Data;
using Endpoints.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

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
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddDbContext<EndpointsContext>(opt => opt.UseInMemoryDatabase("EndpointsDb"))
                .AddSingleton<IEndpointRepository, EndpointRepository>()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<EndpointsContext>()
                       .UseInMemoryDatabase(databaseName: "EndpointsDb")
                       .Options;
            var context = serviceProvider.GetService<EndpointsContext>();
            var repository = serviceProvider.GetService<IEndpointRepository>();

            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Insert a new endpoint");
            Console.WriteLine("2) Edit an existing endpoint");
            Console.WriteLine("3) Delete an existing endpoint");
            Console.WriteLine("4) List all endpoint");
            Console.WriteLine("5) Find an endpoint by serial number");
            Console.WriteLine("6) Exit");

            Console.Write("\r\nSelect an option: ");


            switch (Console.ReadLine())
            {
                case "1":

                    var endpointEntity = new Endpoint();


                    Console.WriteLine("Serial number:");
                    var serialNumber = Console.ReadLine();

                    while (EndpointValidation.SerialNumber(serialNumber))
                    {
                        Console.WriteLine("Serial can't be empty! Input your Serial once more");
                        serialNumber = Console.ReadLine();
                    }
                    endpointEntity.SerialNumber = serialNumber;


                    Console.WriteLine("Model Id:");
                    var modelId = Console.ReadLine();

                    while (EndpointValidation.ModelId(modelId))
                    {
                        Console.WriteLine("Model can't be empty and a number (16,17,18,19)! Input your Model once more");
                        modelId = Console.ReadLine();
                    }

                    endpointEntity.ModelId = Convert.ToInt16(modelId);


                    Console.WriteLine("Number:");
                    var number = Console.ReadLine();

                    while (EndpointValidation.Number(number))
                    {
                        Console.WriteLine("Number can't be empty and a number! Input your number once more");
                        number = Console.ReadLine();
                    }

                    endpointEntity.Number = Convert.ToInt16(number);


                    Console.WriteLine("Firmware Version:");
                    var firmwareVersion = Console.ReadLine();

                    while (EndpointValidation.FirmwareVersion(firmwareVersion))
                    {
                        Console.WriteLine("Firmware Version can't be empty! Input your Firmware Version once more");
                        firmwareVersion = Console.ReadLine();
                    }

                    endpointEntity.FirmwareVersion = firmwareVersion;


                    Console.WriteLine("State:");
                    var state = Console.ReadLine();

                    while (EndpointValidation.State(state))
                    {
                        Console.WriteLine("State Version can't be empty and a number (0,1,2) ! Input your State Version once more");
                        state = Console.ReadLine();
                    }

                    endpointEntity.State = Convert.ToInt16(state);



                    //repository.Insert(endpointEntity);

                    GlobalConfiguration.Endpoints.Add(endpointEntity);

                    return true;

                case "2":

                    return true;

                case "3":
                    return false;

                case "4":
                    var endpoints = GlobalConfiguration.Endpoints;//repository.GetAll();

                    Console.Clear();

                    foreach (var item in endpoints)
                    {
                        Console.WriteLine("Serial number:" + item.SerialNumber);
                        Console.WriteLine("Model:" + item.ModelId);
                        Console.WriteLine("Firmware Version:" + item.FirmwareVersion);
                        Console.WriteLine("Number:" + item.Number);
                        Console.WriteLine("State:" + item.State);
                        Console.WriteLine("");
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Press a key to continue.");
                    Console.ReadLine();

                    return true;

                case "5":
                    return false;

                case "6":

                    return false;

                default:
                    return true;
            }
        }
    }
}
