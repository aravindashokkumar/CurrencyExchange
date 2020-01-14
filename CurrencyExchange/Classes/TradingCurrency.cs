using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Classes
{
    interface ITradingCurrency
    {
        double getExchangeRate(Currency targetCurrency);
        double getExchangedAmount(Currency targetCurrency);
    }
}
