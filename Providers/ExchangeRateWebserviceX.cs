using CRMGG.ExchangeRates.CurrencyConvertor;
using ExchangeRate.XmlClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ExchangeRate
{
    class ExchangeRateWebserviceX : ExchangeRateProvider
    {
        public List<KeyValuePair<string, decimal>> ExchangeRates = null;

        public List<string> CurrenciesList = null;


        string getServiceUrl()
        {
            return @"http://www.webservicex.net/currencyconvertor.asmx";
        }

        List<string> ExchangeRateProvider.GetCurrencyList()
        {
            if (CurrenciesList != null)
                return CurrenciesList;
            else
            {

                CurrenciesList = new List<string>();

                foreach (Currency p in Enum.GetValues(typeof(Currency)))
                {
                    string currencyIsoCode = p.ToString();

                    CurrenciesList.Add(currencyIsoCode);


                }
                
                return CurrenciesList;
            }
        }

        List<KeyValuePair<string, decimal>> ExchangeRateProvider.GetCurrencyListwithValues()
        {
            
            Currency curdef = (Currency)Enum.Parse(typeof(Currency), "EUR");

            BasicHttpBinding binding = new BasicHttpBinding();

            //Specify the address to be used for the client.
            EndpointAddress address =    new EndpointAddress(getServiceUrl());

            CRMGG.ExchangeRates.CurrencyConvertor.CurrencyConvertorSoapClient ws = new CurrencyConvertorSoapClient(binding,address);
            

            if (ExchangeRates != null)
                return ExchangeRates;
            else
            {
                ExchangeRates = new List<KeyValuePair<string, decimal>>();
                foreach (Currency cur in Enum.GetValues(typeof(Currency)))
                {
                    decimal dblRate = Convert.ToDecimal( ws.ConversionRate(curdef, cur));

                    ExchangeRates.Add(new KeyValuePair<string, decimal>(cur.ToString(), dblRate));



                }

                
                return ExchangeRates;
            }
        }

        string ExchangeRateProvider.getDefaultCurrencyISOCode()
        {
            return "EUR";
        }

        string ExchangeRateProvider.getName()
        {
            return @"http://www.webservicex.net";
        }

        string ExchangeRateProvider.getServiceUrl()
        {
            return getServiceUrl();
        }
    }
}
