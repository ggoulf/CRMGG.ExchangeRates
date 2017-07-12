using CRMGG.ExchangeRates.CurrencyConvertor;
using ExchangeRate;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Providers
{
    public enum CurrencyProvider
    {
        EuropeanCentralBank = 436920000,
        SloveniaCentralBank = 436920001,
        RussiaCentralBank = 436920002,
        webservicex = 1000000

    }

    public class Provider
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }

    public class CurrencyHelper
    {
        private  ExchangeRateProvider CurrentProvider = null;
        private  Entity BaseCurrency = null;


        private  ExchangeRateProvider getProvider(int provider)
        {

            switch (provider)
            {
                case (int)CurrencyProvider.EuropeanCentralBank:
                    return new ExchangeRateEuropeanCentralBank();

                case (int)CurrencyProvider.SloveniaCentralBank:
                    return new ExchangeRateSloveniaCentralBank();

                case (int)CurrencyProvider.RussiaCentralBank:
                    return new ExchangeRateRussiaCentralBank();
                case (int)CurrencyProvider.webservicex:
                    return new ExchangeRateWebserviceX();
                default:
                    return null;
            }
        }

        public CurrencyHelper()
        {

        }
        public  void setProvider(int provider)
        {
            CurrentProvider = getProvider(provider);
        }

        public Boolean isCurrencyAvailable(string CurrencyIsoCode)
        {
            if (CurrentProvider == null)
                throw new Exception("Please Setup the Provider before try to get the availables currencies");
            string providerDefaultCurrencyIsoCode = CurrentProvider.getDefaultCurrencyISOCode();
            if (providerDefaultCurrencyIsoCode == CurrencyIsoCode)
                return true;
            List<string> currenciesList = CurrentProvider.GetCurrencyList();
            foreach(string s in currenciesList)
            {
                if (s == CurrencyIsoCode)
                    return true;
            }

            return false;
        }
        public  decimal getRate(string fromCurrencyIsoCode, string toCurrencyIsoCode)
        {
            if (CurrentProvider == null)
                throw new Exception("Please Setup the Provider before try to get the Exchange Rate");
            if (CurrentProvider.GetType() == typeof(ExchangeRateWebserviceX))
            {
                BasicHttpBinding binding = new BasicHttpBinding();

                //Specify the address to be used for the client.
                EndpointAddress address = new EndpointAddress(CurrentProvider.getServiceUrl());

                CurrencyConvertorSoapClient ws = new CurrencyConvertorSoapClient(binding, address);
                Currency curdef = (Currency)Enum.Parse(typeof(Currency), fromCurrencyIsoCode);
                Currency cur = (Currency)Enum.Parse(typeof(Currency), toCurrencyIsoCode);
                decimal dblRate = Convert.ToDecimal(ws.ConversionRate(curdef, cur));
                return dblRate;

               

            }

            decimal result = -1;
            string providerDefaultCurrencyIsoCode = CurrentProvider.getDefaultCurrencyISOCode();
            List<KeyValuePair<string, decimal>> exchangeratelist = CurrentProvider.GetCurrencyListwithValues();

            if (fromCurrencyIsoCode.ToLower() == toCurrencyIsoCode.ToLower())
            {
                //c'est la meme devise donc on retourne 1
                return 1;
            }

            if (providerDefaultCurrencyIsoCode.ToLower() == fromCurrencyIsoCode.ToLower())
            {
                //c'est la devise par defaut du provider donc pas de calcul on retourne le taux de change fourni
                foreach (var excR in exchangeratelist)
                {
                    if (excR.Key.ToLower() == toCurrencyIsoCode.ToLower())
                    {
                        return excR.Value;
                    }
                }
            }

            if (providerDefaultCurrencyIsoCode.ToLower() == toCurrencyIsoCode.ToLower())
            {
                //le to est la devise par defaut du provider il faut donc retourner 1 par le taux de change
                foreach (var excR in exchangeratelist)
                {
                    if (excR.Key.ToLower() == fromCurrencyIsoCode.ToLower())
                    {
                        return 1 / excR.Value;
                    }
                }
            }

            if (providerDefaultCurrencyIsoCode.ToLower() != toCurrencyIsoCode.ToLower() && providerDefaultCurrencyIsoCode.ToLower() != fromCurrencyIsoCode.ToLower())
            {
                //le calcul n'est pas fait par rapport à la devise par defaut du provider, il faut donc faire un calcul

                decimal fromexcR = -1;
                decimal toexcR = -1;
                foreach (var excR in exchangeratelist)
                {
                    if (excR.Key.ToLower() == fromCurrencyIsoCode.ToLower())
                    {
                        fromexcR = excR.Value;
                    }

                    if (excR.Key.ToLower() == toCurrencyIsoCode.ToLower())
                    {
                        toexcR = excR.Value;
                    }


                }

                if (fromexcR != -1 && toexcR != -1)
                {
                    return toexcR / fromexcR;
                }
            }


            return result;
        }

        public  string getStrProvider(int provider)
        {
            

            switch (provider)
            {
                case (int)CurrencyProvider.EuropeanCentralBank:
                    return "European Central Bank";
             
                case (int)CurrencyProvider.SloveniaCentralBank:
                    return "Slovenia Central Bank";
                 
                case (int)CurrencyProvider.RussiaCentralBank:
                    return "Russia Central Bank";
                case (int)CurrencyProvider.webservicex:
                    return @"http://www.webservicex.net";
                default:
                    return "Error with the Exchange Rate Provider";
            }

        }

      

        public  string GetBaseCurrencyIsoCode(IOrganizationService service, Guid OrganizationId)
        {
            

            return GetBaseCurrency( service, OrganizationId).Attributes["isocurrencycode"].ToString();
        }

        public  Entity GetBaseCurrency(IOrganizationService service, Guid OrganizationId)
        {
            if (BaseCurrency != null)
                return BaseCurrency;
            else
            {
                EntityReference refOrg = new EntityReference("organization", OrganizationId);
                RetrieveRequest rrOrg = new RetrieveRequest();
                rrOrg.ColumnSet = new ColumnSet(true);
                rrOrg.Target = refOrg;
                RetrieveResponse rResp = (RetrieveResponse)service.Execute(rrOrg);
                Entity org = (Entity)rResp.Entity;

                BaseCurrency = (Entity)service.Retrieve("transactioncurrency", ((EntityReference)org.Attributes["basecurrencyid"]).Id, new ColumnSet(true));

                return BaseCurrency;
            }
        }
    }
}
