namespace Todo.Shared.Exceptions
{
    public abstract class BaseException : Exception
    {
        protected BaseException(string message) : base(message)
        {
            Code = string.Empty;
            StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
        }

        protected BaseException(string message, Exception inner) : base(message, inner)
        {
            Code = string.Empty;
            StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
        }

        protected BaseException()
        {
            Code = string.Empty;
            StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
        }

        public string Code { get; protected init; }
        public int StatusCode { get; protected init; }

        public override string ToString()
        {
            return $"Code: {Code} | Message: {Message}";
        }
    }
}
