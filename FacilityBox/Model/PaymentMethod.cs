using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityBox.Model
{
    public class PaymentMethod
    {
        public int PaymentID { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
    }
}
