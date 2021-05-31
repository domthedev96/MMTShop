using System;

namespace MMTShop.Common.CustomExceptions
{
    public class ProductServiceException : Exception
    {
        public ProductServiceException() : base()
        {

        }
        public ProductServiceException(string message) : base(message)
        {

        }
        public ProductServiceException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
