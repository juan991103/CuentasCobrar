using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasCobrar.Models
{
    public class AccountingRequest
    {
        public string Period { get; set; }
        public string Currency { get; set; }
        public IEnumerable<AccountingRequestDetails> Detail { get; set; }
    }
}
