using BillableTransactions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCodingExercise.Services
{
    public interface IBillableTransactionService
    {
        Transaction RegisterTransaction(Transaction transaction);
        Transaction UpdateBillingStatus(string id, Transaction transaction);
        Transaction GenerateInvoicesByDateRange(DateTime startDate, DateTime endDate);
    }
}
