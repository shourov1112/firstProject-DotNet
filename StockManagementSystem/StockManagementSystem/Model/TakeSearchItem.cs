using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Model
{
    public class TakeSearchItem
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CompanyName { get; set; }
        public int ReorderLevel { get; set; }
        public int Quantity { get; set; }
        public int Sno { get; set; }
        public string ItemName { get; set; }

    }
}
