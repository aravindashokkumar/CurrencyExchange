using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyExchange.Models
{
    public class CurrencyExchangeOutput
    {
        public string response_message { get; set; }
        public double exchange_rate { get; set; }
        public double exchange_amount { get; set; }
    }
}