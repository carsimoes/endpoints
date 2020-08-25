using System;
using System.Collections.Generic;
using System.Text;

namespace Endpoints.Entity
{
    public class Endpoint
    {
        public string SerialNumber { get; set; }
        public int ModelId { get; set; }
        public int Number { get; set; }
        public string FirmwareVersion { get; set; }
        public int State { get; set; }

        public string ModelIdCode()
        {
            switch (this.ModelId)
            {
                case 16:
                    return "NSX1P2W";

                case 17:
                    return "NSX1P3W";

                case 18:
                    return "NSX2P3W";

                case 19:
                    return "NSX3P4W";

                default:
                    break;
            }

            return "0";
        }

        public string StateCode()
        {
            switch (this.State)
            {
                case 0:
                    return "Disconected";

                case 1:
                    return "Connected";

                case 2:
                    return "Armed";

                default:
                    break;
            }

            return "0";
        }
    }
}
