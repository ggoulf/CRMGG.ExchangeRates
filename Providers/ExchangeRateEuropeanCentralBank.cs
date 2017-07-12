using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRate;
using System.Xml;
using System.Globalization;

namespace ExchangeRate
{
    class ExchangeRateEuropeanCentralBank : ExchangeRateProvider
    {
        public List<KeyValuePair<string, decimal>> ExchangeRates = null;

        public List<string> CurrenciesList = null;

        string getServiceUrl()
        {
            return @"https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
        }

        List<string> ExchangeRateProvider.GetCurrencyList()
        {
            if (CurrenciesList != null)
                return CurrenciesList;
            else
            {
                CurrenciesList = new List<string>();
                string date = string.Empty;
                string url = this.getServiceUrl();
                using (XmlReader xmlr = XmlReader.Create(url))
                {
                    xmlr.ReadToFollowing("Cube");
                    while (xmlr.Read())
                    {
                        if (xmlr.NodeType != XmlNodeType.Element) continue;
                        if (xmlr.GetAttribute("time") != null)
                        {
                            date = xmlr.GetAttribute("time");
                        }
                        else CurrenciesList.Add(xmlr.GetAttribute("currency"));
                    }

                }
                CurrenciesList.Add("EUR");
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
                string date = string.Empty;
                string url = this.getServiceUrl();
                using (XmlReader xmlr = XmlReader.Create(url))
                {
                    xmlr.ReadToFollowing("Cube");
                    while (xmlr.Read())
                    {
                        if (xmlr.NodeType != XmlNodeType.Element) continue;
                        if (xmlr.GetAttribute("time") != null)
                        {
                            date = xmlr.GetAttribute("time");
                        }
                        else ExchangeRates.Add(new KeyValuePair<string, decimal>(xmlr.GetAttribute("currency"), decimal.Parse(xmlr.GetAttribute("rate"), CultureInfo.InvariantCulture)));
                    }

                }
                ExchangeRates.Add(new KeyValuePair<string, decimal>("EUR", 1));
                return ExchangeRates;
            }
        }


        string ExchangeRateProvider.getDefaultCurrencyISOCode()
        {
            return "EUR";
        }

        string ExchangeRateProvider.getName()
        {
            return "European Central Bank";
        }

        string ExchangeRateProvider.getServiceUrl()
        {
            return getServiceUrl();
        }
    }
}
