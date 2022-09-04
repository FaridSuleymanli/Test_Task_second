using System;

namespace ProductStockAPİ.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
            
        }
    }
}