using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Model
{
    public class UserStatus
    {
        public int UserId { get; set; }
        public DateTime ExecuteTime { get; set; }
        public string ChangeType { get; set; }

    }
}
