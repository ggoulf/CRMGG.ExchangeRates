using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate
{
    class ExchangeRateCalculation
    {

        public static decimal getRate(ExchangeRateProvider provider, string fromCurrencyIsoCode , string toCurrencyIsoCode )
        {
            decimal result = -1;
            string providerDefaultCurrencyIsoCode = provider.getDefaultCurrencyISOCode();
            List<KeyValuePair<string, decimal>> exchangeratelist = provider.GetCurrencyListwithValues();

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
                        return 1/excR.Value;
                    }
                }
            }

            if (providerDefaultCurrencyIsoCode.ToLower() != toCurrencyIsoCode.ToLower() && providerDefaultCurrencyIsoCode.ToLower() != fromCurrencyIsoCode.ToLower())
            {
                //le calcul n'est pas fait par rapport à la devise par defaut du provider, il faut donc faire un calcul

                decimal fromexcR = -1 ;
                decimal toexcR = - 1;
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
                    return  toexcR/ fromexcR;
                }
            }


                return result;
        }
    }

}