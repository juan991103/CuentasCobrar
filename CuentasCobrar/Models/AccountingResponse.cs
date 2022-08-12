using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasCobrar.Models
{
    public class AccountingResponse
    {
        public List<AccountingResponseDetail> responseList { get; set; }
    }

    public class AccountingResponseDetail
    {
        public int id { get; set; }
    }
}
