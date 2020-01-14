using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace CurrencyExchange.Utils
{
    public static class AppConstants
    {
        public const int
            intSuccess = 0,
            intConvertionNotAvailable = -10,
            intConvertionInputsNotSupplied = -11,
            intConvertionFailed = -90;

        public const string
            strSuccess = "Success",
            strConvertionNotAvailable = "Convertion Not Available.",
            strConvertionFailed = "Convertion Failed.",
            strConvertionInputsNotSupplied = "Insufficient inputs for conversion.";

        public const string
            strSourceCurrency = "source",
            strTargetCurrency = "target",
            strExchangeAmount = "amount";
        public const string
            strExchangeRateFileInfo = "/Content/json/rates.json";
    }
}