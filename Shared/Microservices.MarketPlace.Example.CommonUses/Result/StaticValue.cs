using System;
using System.Collections.Generic;
using System.Text;

namespace Microservices.MarketPlace.Example.CommonUses.Result
{
    public static class StaticValue
    {
        #region return message
        public static string _error = "error";
        public static string _productNotFound = "Product not found";
        public static string _imageNotFound = "Image not found";
        public static string _basketNotFound = "Basket not found";
        public static string _imageEmpty = "Image is empty";
        public static string _emailorPasswordIncorrect = "Email or Password Incorrect";
        public static string _basketCouldNot = "Basket could not update or save";
        #endregion

        #region return code
        public static int _notFoundId = 404;
        public static int _badRequest = 400;
        public static int _couldNot = 400;
        public static int _successReturnModelId = 200;
        public static int _successReturnNotModelId = 204;
        #endregion


    }
}
