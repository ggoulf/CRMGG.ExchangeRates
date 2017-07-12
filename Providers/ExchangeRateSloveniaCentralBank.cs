using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExchangeRate
{
    class ExchangeRateSloveniaCentralBank : ExchangeRateProvider
    {
        public List<KeyValuePair<string, decimal>> ExchangeRates = null;

        public List<string> CurrenciesList = null;


        string getServiceUrl()
        {
            return @"http://www.bsi.si/_data/tecajnice/EksotTecBS.xml";
        }

        List<string> ExchangeRateProvider.GetCurrencyList()
        {
            if (CurrenciesList != null)
                return CurrenciesList;
            else
            {
                CurrenciesList = new List<string>();
                string date = string.Empty;
                using (XmlReader xmlr = XmlReader.Create(this.getServiceUrl()))
                {
                    xmlr.ReadToFollowing("tecajnica");
                    while (xmlr.Read())
                    {
                        if (xmlr.NodeType != XmlNodeType.Element) continue;
                        if (xmlr.GetAttribute("veljavnost") != null)
                        {
                            date = xmlr.GetAttribute("veljavnost");
                        }
                        else CurrenciesList.Add(xmlr.GetAttribute("oznaka"));
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
                using (XmlReader xmlr = XmlReader.Create(this.getServiceUrl()))
                {
                    xmlr.ReadToFollowing("tecajnica");
                    while (xmlr.Read())
                    {
                        if (xmlr.NodeType != XmlNodeType.Element) continue;
                        if (xmlr.GetAttribute("veljavnost") != null)
                        {
                            date = xmlr.GetAttribute("veljavnost");
                        }
                        else
                        {

                            ExchangeRates.Add(new KeyValuePair<string, decimal>(xmlr.GetAttribute("oznaka"), decimal.Parse(xmlr.ReadInnerXml(), CultureInfo.InvariantCulture)));
                        }
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
            return "Slovenia Central Bank";
        }

        string ExchangeRateProvider.getServiceUrl()
        {
            return getServiceUrl();
        }
    }
}
