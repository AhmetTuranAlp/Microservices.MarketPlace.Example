using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Microservices.MarketPlace.Example.Product.Enumeration
{
    public static class Payment
    {
        public enum PaymentType : int
        {
            [Description("Kredi Kartı Online Ödeme")]
            CreditCardOnline = 0,
            [Description("Kredi Kartı Kapıda Ödeme")]
            CreditCardAtTheDoor = 1,
            [Description("Kapıda Nakit Ödeme")]
            CashAtTheDoor = 2
        }
    }
}
