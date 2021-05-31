using System;

namespace MMTShop.Common.CustomExceptions
{
    public class CategoryServiceException : Exception
    {
        public CategoryServiceException() : base()
        {

        }
        public CategoryServiceException(string message) : base(message)
        {

        }
        public CategoryServiceException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
