using BillableTransactionDatabase.Models;
using System.Collections.Generic;

namespace BillableTransactionDatabase.Repository
{
    public interface IBillableTransactionRepository
    {
        void Create(Transaction user);
        Transaction UpdateBillingStatus(string id, string status);
        IEnumerable<Transaction> GetBillableTransactionsByDateRange();
    }
}
