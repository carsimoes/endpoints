using Endpoints.Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Endpoints.Business.Entity
{
    public static class EndpointValidation
    {
        public static bool SerialNumber(string serialNumber, bool create = false)
        {
            if (string.IsNullOrEmpty(serialNumber))
            {
                return true;
            }
            else
            {
                if (create)
                {
                    var endpointFound = GlobalConfiguration.Endpoints.Where(e => e.SerialNumber == serialNumber)?.FirstOrDefault();

                    if (endpointFound != null)
                    {
                        Console.WriteLine("Endpoint already exists!");
                        return true;
                    }
                }

                return false;
            }
        }

        public static bool ModelId(string modelId)
        {
            if (string.IsNullOrEmpty(modelId))
            {
                return true;
            }

            int value;
            if (int.TryParse(modelId, out value))
            {
                if (value >= 16 && value <= 19)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public static bool Number(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return true;
            }

            int value;
            if (int.TryParse(number, out value))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool FirmwareVersion(string firmwareVersion)
        {
            if (string.IsNullOrEmpty(firmwareVersion))
            {
                return true;
            }
            else
            {
               return false;
            }
        }

        public static bool State(string state)
        {
            if (string.IsNullOrEmpty(state))
            {
                return true;
            }

            int value;
            if (int.TryParse(state, out value))
            {
                if (value >= 0 && value <= 2)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
