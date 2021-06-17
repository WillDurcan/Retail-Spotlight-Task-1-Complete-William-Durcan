using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tasks_for_work
{
    public class Elements
    {
        // Create a class of objects that will be added into the data table. 
        // By doing it this way we can check each field for the different errors. 
        public string site_id { get; set; }
        public string transaction_id { get; set; }
        public string transaction_completed_at { get; set; }
        public string barcode { get; set; }
        public string product_name { get; set; }
        public string quantity { get; set; }
        public string unit_price { get; set; }



    }
}
