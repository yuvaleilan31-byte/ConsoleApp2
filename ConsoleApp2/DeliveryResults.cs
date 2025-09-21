using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class DeliveryResults
    {
        public bool success { get; set; }
        public string id { get; set; }
        public string massage { get; set; }

        public DeliveryResults(bool success, string id, string massage)
        {
            this.success = success;
            this.id = id;
            this.massage = massage;
        }

        
    }
}
