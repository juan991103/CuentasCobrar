using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasCobrar.Models
{
    public class AccountingRequestDetails
    {   
        public decimal Amount { get; set; }
        public int LegerAccount { get; set; }
        public string MovementType { get; set; }
    }
}
