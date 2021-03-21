using CardsEngine.Console.Core.Model;
using System;
using System.Collections.Generic;
using System.Net;

namespace CardsEngine.Console.Core.Helpers
{
    public static class GenerateErrorHelper
    {
        public static Error SetError(int httpCode, string httpMessage, string developerMessage, string[] validationErrors)
        {
            return new Error
            {
                HttpCode = httpCode,
                HttpMessage = httpMessage,
                DeveloperMessage = developerMessage,
                ValidationErrors = validationErrors
            };
        }
        public static Error SetError(string httpMessages)
        {
            return new Error
            {
                HttpCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                HttpMessage = httpMessages,
                ValidationErrors = new List<string>()
            };
        }
    }
}
