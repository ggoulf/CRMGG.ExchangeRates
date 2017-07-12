using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ExchangeRate.XmlClass;

namespace ExchangeRate
{
    class ExchangeRateRussiaCentralBank : ExchangeRateProvider
    {

        public List<KeyValuePair<string, decimal>> ExchangeRates = null;

        public List<string> CurrenciesList = null;


        string getServiceUrl()
        {
            return @"http://www.cbr.ru/scripts/XML_daily.asp";
        }

        List<string> ExchangeRateProvider.GetCurrencyList()
        {
            if (CurrenciesList != null)
                return CurrenciesList;
            else
            {

                CurrenciesList = new List<string>();

                XmlSerializer xs = new XmlSerializer(typeof(ValCurs));
                XmlReader xr = new XmlTextReader(this.getServiceUrl());
                foreach (ValCursValute valute in ((ValCurs)xs.Deserialize(xr)).ValuteList)
                {
                    CurrenciesList.Add(valute.ValuteStringCode);
                }
                CurrenciesList.Add("RUB");
                return CurrenciesList;
            }
        }



        List<KeyValuePair<string, decimal>> ExchangeRateProvider.GetCurrencyListwithValues()
        {
            if (ExchangeRates != null)
                return ExchangeRates;
            else
            {
                ExchangeRates = new List<KeyValuePair<string, decimal>>();
                XmlSerializer xs = new XmlSerializer(typeof(ValCurs));
                XmlReader xr = new XmlTextReader(this.getServiceUrl());
                foreach (ValCursValute valute in ((ValCurs)xs.Deserialize(xr)).ValuteList)
                {
                    ExchangeRates.Add(new KeyValuePair<string, decimal>(valute.ValuteStringCode, 1 / decimal.Parse(valute.ExchangeRate.Replace(',', '.'), CultureInfo.InvariantCulture)));
                }
                ExchangeRates.Add(new KeyValuePair<string, decimal>("RUB", 1));

                return ExchangeRates;
            }
        }


        string ExchangeRateProvider.getDefaultCurrencyISOCode()
        {
            return "RUB";
        }

        string ExchangeRateProvider.getName()
        {
            return "Russian Central Bank";
        }

        string ExchangeRateProvider.getServiceUrl()
        {
            return getServiceUrl();
        }
    }
}
