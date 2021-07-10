using System;

namespace BillableTransactionDatabase.Exceptions
{
    public class CrudOperationException : Exception
    {
        public int Code { get; }

        public CrudOperationException()
        {
        }

        public CrudOperationException(string message)
            : base(message)
        {
        }

        public CrudOperationException(int code, string message)
                     : base(string.Format(message))
        {
            Code = code;
        }

        public CrudOperationException(int code, string message, Exception innerException)
                              : base(string.Format(message), innerException)
        {
            Code = code;
        }
    }
}
