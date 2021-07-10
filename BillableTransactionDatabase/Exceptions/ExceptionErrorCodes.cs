namespace BillableTransactionDatabase.Exceptions
{
    public enum ExceptionErrorCodes
    {
        InvalidData = 400,
        Forbidden = 403,
        NotFound = 404,
        ConflictData = 409,
        PreconditionFailed = 412,
        Locked = 423,
        InternalServerError = 500
    }
}
