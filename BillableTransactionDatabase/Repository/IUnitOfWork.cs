namespace BillableTransactionDatabase.Repository
{
    public interface IUnitOfWork
    {
        IBillableTransactionRepository BillableTransaction { get; }
        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();
        void Save();
    }
}
