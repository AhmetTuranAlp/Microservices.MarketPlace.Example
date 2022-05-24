﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Microservices.MarketPlace.Example.CommonUses.Result
{
    public static class StaticValue
    {
        public static string _productNotFound = "Product not found";

        public static int _notFoundId = 404;
        public static int _successReturnModelId = 200;
        public static int _successReturnNotModelId = 204;
    }
}
