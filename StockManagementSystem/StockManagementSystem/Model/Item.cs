using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Model
{
    public class Item
    {
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        public string ItemName { get; set; }
        public int ReorderLevel { get; set; }
        public int Id { get; set; }
        public int Quantity { get; set; }

    }
}
