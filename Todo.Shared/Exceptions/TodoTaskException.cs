namespace Todo.Shared.Exceptions
{
    public class TodoTaskException : BaseException
    {
        public TodoTaskException(string message ) : base( message ) { }
        public TodoTaskException(string message, Exception inner) : base(message, inner) { }
        public TodoTaskException() : base() { }
    }
}
