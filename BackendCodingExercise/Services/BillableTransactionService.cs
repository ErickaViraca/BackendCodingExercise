using System;
using BillableTransactionDatabase.Repository;
using BillableTransactions.Models;
using Microsoft.Extensions.Logging;

namespace BackendCodingExercise.Services
{
    public class BillableTransactionService : IBillableTransactionService
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<BillableTransactionService> _loggerBillableTransaction;

        public BillableTransactionService(IUnitOfWork uow, ILogger<BillableTransactionService> logger)
        {
            _loggerBillableTransaction = logger;
            _uow = uow;
        }
        public Transaction GenerateInvoicesByDateRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Transaction RegisterTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Transaction UpdateBillingStatus(string id, Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
