using CurrencyExchange.Classes;
using CurrencyExchange.Models;
using CurrencyExchange.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CurrencyExchange.Controllers
{
    public class CurrencyExchangerController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage get()
        {
            bool blnParametersSupplied = false;
            string strSourceCurrency = string.Empty,
                strTargetCurrency = string.Empty;
            double dblExchangeAmount = 0.0;
            ExchangeCurrency currencyExchanger;
            CurrencyExchangeOutput outputResponse = new CurrencyExchangeOutput();
            outputResponse.exchange_rate = 0.00;
            outputResponse.exchange_amount = 0.00;
            try
            {
                NameValueCollection vObjRequestQueryString = HttpContext.Current.Request.QueryString;
                if (!string.IsNullOrEmpty(vObjRequestQueryString[AppConstants.strSourceCurrency]))
                {
                    strSourceCurrency = vObjRequestQueryString[AppConstants.strSourceCurrency].ToUpper().ToString();
                }
                if (!string.IsNullOrEmpty(vObjRequestQueryString[AppConstants.strTargetCurrency]))
                {
                    strTargetCurrency = vObjRequestQueryString[AppConstants.strTargetCurrency].ToUpper().ToString();
                }
                if (!string.IsNullOrEmpty(vObjRequestQueryString[AppConstants.strExchangeAmount]))
                {
                    dblExchangeAmount = Convert.ToDouble(vObjRequestQueryString[AppConstants.strExchangeAmount]);
                }

                if(!(string.IsNullOrEmpty(strSourceCurrency)|| string.IsNullOrEmpty(strTargetCurrency)))
                {
                    blnParametersSupplied = true;
                }
                if (blnParametersSupplied)
                {
                    currencyExchanger = new ExchangeCurrency(strSourceCurrency, strTargetCurrency, dblExchangeAmount);
                    outputResponse.exchange_rate = currencyExchanger.getExchangeRate(currencyExchanger.TargetCurrency);
                    outputResponse.exchange_amount = currencyExchanger.getExchangedAmount(currencyExchanger.TargetCurrency);
                }
                else
                {
                    outputResponse.response_message = AppConstants.strConvertionInputsNotSupplied;
                }

            }
            catch (Exception ex)
            {
                outputResponse.response_message = AppConstants.strConvertionFailed;
            }

            return Request.CreateResponse(HttpStatusCode.OK, outputResponse);
        }
    }
}
