using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Microservices.MarketPlace.Example.Product.Enumeration
{
    public class Currency
    {
        public enum CurrencyType
        {
            [Description("TL")]
            TRY = 0,
            [Description("USD")]
            USD = 1,
            [Description("EURO")]
            EURO = 2,
        }

    }
}
