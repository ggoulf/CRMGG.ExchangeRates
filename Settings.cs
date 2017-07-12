using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMGG.ExchangeRates
{
    public class Settings
    {
       // public string Var1 { get; set; }
      //  public bool Var2 { get; set; }

        public List<AssociateProvider> ProviderSettings { get; set; }
    }

    public class AssociateProvider
    {
        public string CurrencyID { get; set; }
        public int ProviderID{ get; set; }
}
}
