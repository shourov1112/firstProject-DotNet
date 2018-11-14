using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Model
{
    public class StockOutItem
    {
        public int Sno { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ItemName { get; set; }
        public int ItemId { get; set; }
        public int TotalQuantity { get; set; }
        public DateTime SellDate { get; set; }
        public string SellType { get; set; }
    }
}
