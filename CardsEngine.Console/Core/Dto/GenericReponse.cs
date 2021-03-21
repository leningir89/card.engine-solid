using CardsEngine.Console.Core.Model;

namespace CardsEngine.Console.Core.Dto
{
    public class GenericReponse<T>
    {
        public GenericReponse()
        {
        }

        public GenericReponse(T data, Error error)
        {
            Data = data;
            Error = error;
        }

        public T Data { get; set; }
        public Error Error { get; set; }
    }
}
