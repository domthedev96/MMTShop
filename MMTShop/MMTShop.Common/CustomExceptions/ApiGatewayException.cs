using System;
using System.Collections.Generic;
using System.Text;

namespace MMTShop.Common.CustomExceptions
{
    public class ApiGatewayException : Exception
    {
        public ApiGatewayException() : base()
        {

        }
        public ApiGatewayException(string message) : base(message)
        {

        }
        public ApiGatewayException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
