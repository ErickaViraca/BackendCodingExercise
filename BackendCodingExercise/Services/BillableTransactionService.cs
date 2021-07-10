using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillableTransactions.Models;

namespace BackendCodingExercise.Services
{
    public class BillableTransactionService : IBillableTransactionService
    {
        public Transaction GenerateInvoicesByDateRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Transaction RegisterProfile(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Transaction UpdateBillingStatus(string id, Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
