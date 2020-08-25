using Endpoints.Business.Data;
using Endpoints.Business.Entity;
using Endpoints.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Endpoints.Services
{
    public class EndpointService : IEndpointService
    {
        public Endpoint Create(Endpoint endpointEntity)
        {
            Console.WriteLine("Serial number:");
            var serialNumber = Console.ReadLine();

            while (EndpointValidation.SerialNumber(serialNumber, true))
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

            GlobalConfiguration.Endpoints.Add(endpointEntity);

            return endpointEntity;
        }

        public void Delete()
        {
            Console.WriteLine("Enter a Serial number:");
            var serialNumberEdit = Console.ReadLine();

            while (EndpointValidation.SerialNumber(serialNumberEdit))
            {
                Console.WriteLine("Serial can't be empty! Input your Serial once more");
                serialNumberEdit = Console.ReadLine();
            }
            var endpointToEdit = GlobalConfiguration.Endpoints.Where(e => e.SerialNumber == serialNumberEdit)?.FirstOrDefault();

            if (endpointToEdit != null)
            {
                ConsoleKey response;
                do
                {
                    Console.Write("Are you sure you want to delete? [y/n] ");
                    response = Console.ReadKey(false).Key;   
                    if (response != ConsoleKey.Enter)
                        Console.WriteLine();

                } while (response != ConsoleKey.Y && response != ConsoleKey.N);

                if (response == ConsoleKey.Y)
                {
                    GlobalConfiguration.Endpoints.Remove(endpointToEdit);

                    Console.WriteLine("Serial removed!");
                    Console.WriteLine("");
                    Console.WriteLine("Press a key to continue.");
                }
            }
            else
            {
                Console.WriteLine("Serial not found!");
                Console.WriteLine("");
                Console.WriteLine("Press a key to continue.");
                Console.ReadLine();
            }
        }

        public void Edit()
        {
            Console.WriteLine("Enter a Serial number:");
            var serialNumberEdit = Console.ReadLine();

            while (EndpointValidation.SerialNumber(serialNumberEdit))
            {
                Console.WriteLine("Serial can't be empty! Input your Serial once more");
                serialNumberEdit = Console.ReadLine();
            }
            var endpointToEdit = GlobalConfiguration.Endpoints.Where(e => e.SerialNumber == serialNumberEdit)?.FirstOrDefault();

            if (endpointToEdit != null)
            {
                Console.WriteLine("Switch State:");
                var state = Console.ReadLine();

                while (EndpointValidation.State(state))
                {
                    Console.WriteLine("State Version can't be empty and a number (0,1,2) ! Input your State Version once more");
                    state = Console.ReadLine();
                }

                endpointToEdit.State = Convert.ToInt16(state);
            }
            else
            {
                Console.WriteLine("Serial not found!");
                Console.WriteLine("");
                Console.WriteLine("Press a key to continue.");
                Console.ReadLine();
            }
        }

        public void Find()
        {
            Console.WriteLine("Enter a Serial number:");
            var serialNumberEdit = Console.ReadLine();

            while (EndpointValidation.SerialNumber(serialNumberEdit))
            {
                Console.WriteLine("Serial can't be empty! Input your Serial once more");
                serialNumberEdit = Console.ReadLine();
            }
            var endpointFound = GlobalConfiguration.Endpoints.Where(e => e.SerialNumber == serialNumberEdit)?.FirstOrDefault();

            if (endpointFound != null)
            {
                Console.WriteLine("");
                Console.WriteLine("Serial number:" + endpointFound.SerialNumber);
                Console.WriteLine("Model:" + endpointFound.ModelId);
                Console.WriteLine("Firmware Version:" + endpointFound.FirmwareVersion);
                Console.WriteLine("Number:" + endpointFound.Number);
                Console.WriteLine("State:" + endpointFound.State);
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Endpoint not found!");
            }

            Console.WriteLine("");
            Console.WriteLine("Press a key to continue.");
            Console.ReadLine();
        }

        public List<Endpoint> ListAll()
        {
            var endpoints = GlobalConfiguration.Endpoints;

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

            Console.WriteLine($"Endpoints count: [{ endpoints.Count}]");

            Console.WriteLine("");
            Console.WriteLine("Press a key to continue.");
            Console.ReadLine();

            return endpoints;
        }
    }
}
