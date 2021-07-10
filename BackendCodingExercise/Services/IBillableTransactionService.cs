using BillableTransactionDatabase.Models;
using System;
using System.Collections.Generic;

namespace BackendCodingExercise.Services
{
    public interface IBillableTransactionService
    {
        Transaction RegisterTransaction(Transaction transaction);
        Transaction UpdateBillingStatus(string id, string transactionStatus);
        IEnumerable<Transaction> GenerateInvoicesByDateRange(DateTime startDate, DateTime endDate);
    }
}
