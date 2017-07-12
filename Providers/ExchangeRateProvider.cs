using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate
{
    //https://msdn.microsoft.com/en-us/library/system.globalization.regioninfo.isocurrencysymbol(v=vs.110).aspx

  


    public interface ExchangeRateProvider
    {
        string getServiceUrl();

        string getName();

        string getDefaultCurrencyISOCode();

        List<string> GetCurrencyList();

        List<KeyValuePair<string, decimal>> GetCurrencyListwithValues();

        

    }
}
