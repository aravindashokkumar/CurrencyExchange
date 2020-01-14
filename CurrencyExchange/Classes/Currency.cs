using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyExchange
{
    public class Currency
    {
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }


        int id;
        string name;
    }
}