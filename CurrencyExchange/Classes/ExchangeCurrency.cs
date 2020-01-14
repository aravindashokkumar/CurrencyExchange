using CurrencyExchange.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace CurrencyExchange.Classes
{
    public class ExchangeCurrency : Currency, ITradingCurrency
    {
        public Currency SourceCurrency { get { return csourceCurrency; } }
        public Currency TargetCurrency { get { return ctargetCurrency; } }

        Currency ctargetCurrency;
        Currency csourceCurrency;
        public double dblExchangeAmount;
        public JArray ExchangeRateInformation;
        public ExchangeCurrency(string pstrSourceCurrency, string pstrTargetCurrency, double pdblExchangeAmount)
        {
            csourceCurrency = new Currency();
            csourceCurrency.Name = pstrSourceCurrency;
            ctargetCurrency = new Currency();
            ctargetCurrency.Name = pstrTargetCurrency;
            dblExchangeAmount = pdblExchangeAmount;
        }
        public double getExchangedAmount(Currency ptargetCurrency)
        {
            double exchangeAmount = 0.00;
            double exchangeRate = getExchangeRate(ptargetCurrency);
            exchangeAmount = dblExchangeAmount * exchangeRate;
            //For rounding down to the closest dollar.
            return Math.Round(exchangeAmount, MidpointRounding.AwayFromZero);
        }

        public double getExchangeRate(Currency ptargetCurrency)
        {
            double exchangeRate = 0.00;
            bool ExchangeFound = false;
            if (ExchangeRateInformation == null)
            {
                ExchangeRateInformation = fnRetrieveExchangeRates();
            }
            foreach (var rates in ExchangeRateInformation.ToList())
            {
                if(rates["base"].ToString() == csourceCurrency.Name)
                {
                    JObject exchangeValues = JObject.Parse(rates["rates"].ToString());
                    foreach(var value in exchangeValues)
                    {
                        if(value.Key == ptargetCurrency.Name)
                        {
                            exchangeRate = Convert.ToDouble(value.Value);
                            ExchangeFound = true;
                            break;
                        }
                    }
                }
                if (ExchangeFound)
                {
                    break;
                }
            }

            return exchangeRate;
        }

        public int getId()
        {
            return ID;
        }


        public void setId(int id)
        {
            ID = id;
        }

        public string getName()
        {
            return Name;
        }

        public void setName(string name)
        {
            Name = name;
        }

        public JArray fnRetrieveExchangeRates()
        {
            JArray ExchangeRates;
            ExchangeRates = IOHelper.fnOpenFile(HostingEnvironment.ApplicationPhysicalPath + AppConstants.strExchangeRateFileInfo);
            return ExchangeRates;
        }
    }
}