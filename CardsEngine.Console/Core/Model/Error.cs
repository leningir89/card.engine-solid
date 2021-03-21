using System.Collections.Generic;

namespace CardsEngine.Console.Core.Model
{
    public class Error
    {
        public int HttpCode { get; set; }
        public string HttpMessage { get; set; }
        public string DeveloperMessage { get; set; }
        public IList<string> ValidationErrors { get; set; } 
    }
}
