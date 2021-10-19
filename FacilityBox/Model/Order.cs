using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityBox.Model
{
    public class Order
    {
        public int OrderId { get; set; }

        public string ClientName { get; set; }

        public int PlatformID { get; set; }
        public int PaymentID { get; set; }
        public decimal TotalValue { get; set; }
    }
}
