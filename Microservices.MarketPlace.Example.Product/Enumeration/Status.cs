using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Microservices.MarketPlace.Example.Product.Enumeration
{
    public class Status
    {
        public enum StatusType : int
        {
            [Description("Silindi")]
            Deleted = 0,
            [Description("Aktif")]
            Active = 1,
            [Description("Pasif")]
            Passive = 2,
            [Description("Yeni Kayıt")]
            NewRecord = 3
        }
    }
}
