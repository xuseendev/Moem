namespace MoeSystem.Server.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string name, object key) : base(name)
        {

        }
    }
}
