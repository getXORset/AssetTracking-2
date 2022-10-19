using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking_2
{
    //The class Calculator calculates between different currencies
    internal class Calculator
    {
        public Calculator()
        {
        }

        //The method ExchangeCounter returns the price in the local currency
        public decimal ExchangeCounter(decimal price_usd, string currency)
        {
            decimal exchangerate = 1.00m;

            switch (currency)
            {
                case "EUR":
                    exchangerate = 1.02m;
                    break;
                case "SEK":
                    exchangerate = 11.23m;
                    break;
                case "USD":
                    exchangerate = 1.00m;

                    break;
            }
            decimal price_local_today = price_usd * exchangerate;
            return price_local_today;
        }
    }
}
