using System;

namespace Log4Error
{
    public class ErrorMessage : Attribute
    {
        public ErrorMessage(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}